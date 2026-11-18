using CommerceFlow.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetLowStockProducts();
    }
}
