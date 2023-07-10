using Andreitoledo.GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andreitoledo.GeekShopping.CartAPI.Model
{
    [Table("cart_header")]
    public class CartHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("Coupon_Code")]
        public string CouponCode { get; set; }
    }
}
