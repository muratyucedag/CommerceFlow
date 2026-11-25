namespace CommerceFlow.Business.Reports
{
    public class CategoryProductReportItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
        public decimal StockValue { get; set; }
    }
}
