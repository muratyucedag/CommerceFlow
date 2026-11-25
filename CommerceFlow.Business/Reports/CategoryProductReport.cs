namespace CommerceFlow.Business.Reports
{
    public class CategoryProductReport
    {
        public List<CategoryProductReportItem> Categories { get; set; } = new List<CategoryProductReportItem>();

        public int TotalCategories { get; set; }
        public int TotalProducts { get; set; }
        public int TotalStock { get; set; }
        public decimal TotalStockValue { get; set; }
    }
}
