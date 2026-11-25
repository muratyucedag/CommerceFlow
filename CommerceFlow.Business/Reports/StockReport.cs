namespace CommerceFlow.Business.Reports
{
    public class StockReport
    {
        public int TotalProducts { get; set; }
        public int TotalStock { get; set; }
        public decimal TotalStockValue { get; set; }

        public int OutOfStock { get; set; }
        public int LowStock { get; set; }
        public int SufficientStock { get; set; }

        public string? HighestStockProductName { get; set; }
        public int HighestStockQuantity { get; set; }

        public string? LowestStockProductName { get; set; }
        public int LowestStockQuantity { get; set; }
    }
}
