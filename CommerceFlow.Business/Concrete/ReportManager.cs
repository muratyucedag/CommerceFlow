using CommerceFlow.Business.Abstract;
using CommerceFlow.Business.Reports;
using CommerceFlow.DataAccess.Interfaces;

namespace CommerceFlow.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public ReportManager(ICategoryRepository categoryRepository, ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public GeneralStatisticsReport GetGeneralStatistics()
        {
            var categories = _categoryRepository.GetAll();
            var customers = _customerRepository.GetAll();
            var products = _productRepository.GetAll();
            var orders = _orderRepository.GetAll();

            GeneralStatisticsReport report = new GeneralStatisticsReport
            {
                TotalCategories = categories.Count,
                TotalCustomers = customers.Count,
                TotalProducts = products.Count,
                TotalOrders = orders.Count,
                TotalStock = products.Sum(x => x.ProductStock),
                LowStockProducts = products.Count(x => x.ProductStock < 10),
                OutOfStockProducts = products.Count(x => x.ProductStock == 0)
            };

            return report;
        }
        public OrderStatusReport GetOrderStatusReport()
        {
            var orders = _orderRepository.GetAll();

            int totalOrders = orders.Count;

            int preparingOrders = orders.Count(x => x.OrderStatus == "Hazırlanıyor");
            int shippingOrders = orders.Count(x => x.OrderStatus == "Kargoda");
            int deliveredOrders = orders.Count(x => x.OrderStatus == "Teslim Edildi");
            int cancelledOrders = orders.Count(x => x.OrderStatus == "İptal Edildi");

            OrderStatusReport report = new OrderStatusReport
            {
                TotalOrders = totalOrders,

                PreparingOrders = preparingOrders,
                ShippingOrders = shippingOrders,
                DeliveredOrders = deliveredOrders,
                CancelledOrders = cancelledOrders,

                PreparingRate = totalOrders > 0 ? (double)preparingOrders / totalOrders * 100 : 0,
                ShippingRate = totalOrders > 0 ? (double)shippingOrders / totalOrders * 100 : 0,
                DeliveredRate = totalOrders > 0 ? (double)deliveredOrders / totalOrders * 100 : 0,
                CancelledRate = totalOrders > 0 ? (double)cancelledOrders / totalOrders * 100 : 0
            };
            return report;
        }
        public SalesReport GetSalesReport()
        {
            var orders = _orderRepository.GetAll();

            decimal totalOrderAmount = orders.Sum(x => x.OrderTotalPrice);
            decimal completedRevenue = orders.Where(x => x.OrderStatus == "Teslim Edildi").Sum(x => x.OrderTotalPrice);
            decimal pendingAmount = orders.Where(x => x.OrderStatus == "Hazırlanıyor" || x.OrderStatus == "Kargoda").Sum(x => x.OrderTotalPrice);
            decimal cancelledAmount = orders.Where(x => x.OrderStatus == "İptal Edildi").Sum(x => x.OrderTotalPrice);

            var validOrders = orders.Where(x => x.OrderStatus != "İptal Edildi").ToList();

            decimal averageOrderAmount = validOrders.Count > 0 ? validOrders.Average(x => x.OrderTotalPrice) : 0;

            decimal highestOrderAmount = orders.Count > 0 ? orders.Max(x => x.OrderTotalPrice) : 0;

            SalesReport report = new SalesReport
            {
                TotalOrderAmount = totalOrderAmount,
                CompletedRevenue = completedRevenue,
                PendingAmount = pendingAmount,
                CancelledAmount = cancelledAmount,
                AverageOrderAmount = averageOrderAmount,
                HighestOrderAmount = highestOrderAmount,
                TotalOrders = orders.Count,
                ValidOrders = validOrders.Count
            };

            return report;
        }
        public StockReport GetStockReport()
        {
            var products = _productRepository.GetAll();

            int totalProducts = products.Count;
            int totalStock = products.Sum(x => x.ProductStock);

            decimal totalStockValue = products.Sum(x => x.ProductPrice * x.ProductStock);
            int outOfStock = products.Count(x => x.ProductStock == 0);
            int lowStock = products.Count(x => x.ProductStock > 0 && x.ProductStock < 10);
            int sufficientStock = products.Count(x => x.ProductStock >= 10);
            var highestStockProduct = products.OrderByDescending(x => x.ProductStock).FirstOrDefault();
            var lowestStockProduct = products.OrderBy(x => x.ProductStock).FirstOrDefault();

            StockReport report = new StockReport
            {
                TotalProducts = totalProducts,
                TotalStock = totalStock,
                TotalStockValue = totalStockValue,

                OutOfStock = outOfStock,
                LowStock = lowStock,
                SufficientStock = sufficientStock,

                HighestStockProductName = highestStockProduct?.ProductName,
                HighestStockQuantity = highestStockProduct?.ProductStock ?? 0,

                LowestStockProductName = lowestStockProduct?.ProductName,
                LowestStockQuantity = lowestStockProduct?.ProductStock ?? 0
            };

            return report;
        }
        public CategoryProductReport GetCategoryProductReport()
        {
            var categories = _categoryRepository.GetAll();
            var products = _productRepository.GetAll();

            var productGroups = products
                .GroupBy(x => x.CategoryId)
                .ToDictionary(
                    x => x.Key,
                    x => new
                    {
                        ProductCount = x.Count(),
                        TotalStock = x.Sum(p => p.ProductStock),
                        StockValue = x.Sum(p => p.ProductPrice * p.ProductStock)
                    });

            List<CategoryProductReportItem> categoryItems = new List<CategoryProductReportItem>();

            foreach (var category in categories)
            {
                bool hasProducts = productGroups.TryGetValue(category.CategoryId, out var group);

                CategoryProductReportItem item = new CategoryProductReportItem
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    ProductCount = hasProducts ? group!.ProductCount : 0,
                    TotalStock = hasProducts ? group!.TotalStock : 0,
                    StockValue = hasProducts ? group!.StockValue : 0
                };

                categoryItems.Add(item);
            }

            CategoryProductReport report = new CategoryProductReport
            {
                Categories = categoryItems,
                TotalCategories = categories.Count,
                TotalProducts = products.Count,
                TotalStock = products.Sum(x => x.ProductStock),
                TotalStockValue = products.Sum(x => x.ProductPrice * x.ProductStock)
            };

            return report;
        }

    }
}
