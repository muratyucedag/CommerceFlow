using CommerceFlow.Business.Reports;

namespace CommerceFlow.Business.Abstract
{
    public interface IReportService
    {
        GeneralStatisticsReport GetGeneralStatistics();
        OrderStatusReport GetOrderStatusReport();
        SalesReport GetSalesReport();
        StockReport GetStockReport();
        CategoryProductReport GetCategoryProductReport();
    }
}
