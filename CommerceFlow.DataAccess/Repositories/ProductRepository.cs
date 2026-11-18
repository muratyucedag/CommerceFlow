using CommerceFlow.DataAccess.Context;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public List<Product> GetLowStockProducts()
        {
            using var context = new CommerceFlowContext();
            return context.Products.Where(x => x.ProductStock < 10).ToList();
        }
    }
}
