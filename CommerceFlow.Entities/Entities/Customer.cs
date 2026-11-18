namespace CommerceFlow.Entities.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerSurname { get; set; } = "";
        public string CustomerEmail { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string District { get; set; } = "";
        public string City { get; set; } = "";
        public List<Order> Orders { get; set; }
    }
}
