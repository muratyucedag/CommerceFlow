using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
    }
}
