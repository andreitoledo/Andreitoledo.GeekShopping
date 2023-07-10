namespace Andreitoledo.GeekShopping.Web.Models
{

    public class CartDetailVOViewModel
    {
        public long Id { get; set; }

        public long CartHeaderId { get; set; }

        public CartHeaderVOViewModel CartHeader { get; set; }

        public long ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public int Count { get; set; }


    }
}
