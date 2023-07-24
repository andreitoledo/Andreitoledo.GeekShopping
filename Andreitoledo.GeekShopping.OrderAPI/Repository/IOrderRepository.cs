using Andreitoledo.GeekShopping.OrderAPI.Model;

namespace Andreitoledo.GeekShopping.OrderAPI.Repository
{
    public interface IOrderRepository
    {

        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
