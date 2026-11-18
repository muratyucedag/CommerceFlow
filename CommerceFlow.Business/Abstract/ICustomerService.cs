
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        Customer? GetCustomerByEmail(string email);
    }
}
