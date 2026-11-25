namespace CommerceFlow.Business.Reports
{
    public class OrderStatusReport
    {
        public int TotalOrders { get; set; }

        public int PreparingOrders { get; set; }
        public int ShippingOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }

        public double PreparingRate { get; set; }
        public double ShippingRate { get; set; }
        public double DeliveredRate { get; set; }
        public double CancelledRate { get; set; }
    }
}
