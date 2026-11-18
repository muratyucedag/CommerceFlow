using CommerceFlow.Entities.Entities;

namespace CommerceFlow.DataAccess.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer? GetCustomerByEmail(string email);
    }
}