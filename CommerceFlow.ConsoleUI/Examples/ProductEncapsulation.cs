
namespace CommerceFlow.ConsoleUI.Examples
{
    public class ProductEncapsulation
    {
        private decimal _price;
        public string ProductName { get; set; } = "";

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    Console.WriteLine("Ürün fiyatı negatif olamaz!");
                }
            }
        }
    }
}
