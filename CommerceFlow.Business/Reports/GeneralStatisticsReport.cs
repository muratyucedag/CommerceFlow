namespace CommerceFlow.Business.Reports
{
    public class GeneralStatisticsReport
    {
        public int TotalCategories { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public int TotalStock { get; set; }
        public int LowStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
    }
}
