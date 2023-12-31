﻿using Andreitoledo.GeekShopping.CartAPI.Data.ValueObjects;
using Andreitoledo.GeekShopping.CartAPI.Messages;
using Andreitoledo.GeekShopping.CartAPI.RabbitMQSender;
using Andreitoledo.GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _cartRepository;
        private ICouponRepository _couponRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(ICartRepository cartRepository,
            ICouponRepository couponRepository,
            IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _rabbitMQMessageSender = rabbitMQMessageSender ?? throw new ArgumentNullException(nameof(rabbitMQMessageSender));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindById(string id)
        {
            var cart = await _cartRepository.FindCartByUserId(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(CartVO vo)
        {
            var status = await _cartRepository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(string userId)
        {
            var status = await _cartRepository.RemoveCoupon(userId);
            if (!status) return NotFound();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            string token = Request.Headers["Authorization"];
            // se o vo não esta nulo, mas se o UserId esta nulo
            if (vo?.UserId == null) return BadRequest();   
            
            var cart = await _cartRepository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();

            // valida alterações no coupon
            if (!string.IsNullOrEmpty(vo.CouponCode))
            {
                CouponVO coupon = await _couponRepository.GetCoupon(
                    vo.CouponCode, token);
                if (vo.DiscountAmount != coupon.DiscountAmount)
                {
                    // Precondition Failed - O cliente indicou nos seus cabeçalhos pré-condições que o servidor não atende                    
                    return StatusCode(412);
                }
            }

            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            //TASK RabbitMQ lógica aqui !!!
            _rabbitMQMessageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }

    }
}
