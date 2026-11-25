namespace CommerceFlow.Business.Reports
{
    public class SalesReport
    {
        public decimal TotalOrderAmount { get; set; }
        public decimal CompletedRevenue { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal CancelledAmount { get; set; }

        public decimal AverageOrderAmount { get; set; }
        public decimal HighestOrderAmount { get; set; }

        public int TotalOrders { get; set; }
        public int ValidOrders { get; set; }
    }
}
