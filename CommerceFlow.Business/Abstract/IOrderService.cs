
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Abstract
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void UpdateOrderStatus(int orderId, string status);
        void CancelOrder(int orderId);
        List<Order> GetAllOrders();
        Order? GetOrderById(int id);
    }
}
