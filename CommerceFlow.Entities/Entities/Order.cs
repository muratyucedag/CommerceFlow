namespace CommerceFlow.Entities.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = "";
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}