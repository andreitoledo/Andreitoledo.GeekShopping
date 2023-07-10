namespace Andreitoledo.GeekShopping.Web.Models
{
    public class CartVOViewModel
    {

        public CartHeaderVOViewModel CartHeader { get; set; }

        public IEnumerable<CartDetailVOViewModel> CartDetails { get; set; }
    }
}
