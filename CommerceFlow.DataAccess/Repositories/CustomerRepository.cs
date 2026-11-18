using CommerceFlow.DataAccess.Context;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public Customer? GetCustomerByEmail(string email)
        {
            using var context = new CommerceFlowContext();
            return context.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerEmail == email);
        }
    }
}
