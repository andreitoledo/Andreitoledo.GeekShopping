namespace Andreitoledo.GeekShopping.Web.Models
{

    public class CartHeaderVOViewModel
    {
        public long Id { get; set; }

        public string UserId { get; set; }
        
        public string CouponCode { get; set; }

        public double PurchaseAmount { get; set; }
    }
}
