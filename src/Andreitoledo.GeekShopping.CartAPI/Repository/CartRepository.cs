﻿using Andreitoledo.GeekShopping.CartAPI.Data.ValueObjects;
using Andreitoledo.GeekShopping.CartAPI.Model.Context;
using AutoMapper;

namespace Andreitoledo.GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CartRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartVO> FindCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCart(long cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public Task<CartVO> SaveOrUpdateCart(CartVO cart)
        {
            throw new NotImplementedException();
        }
    }
}
