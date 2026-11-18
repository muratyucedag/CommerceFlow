
namespace RestaurantFlow.ConsoleUI.ISPExamples.BadExamples
{
    public class BadChef : IRestaurantEmployee
    {
        public string ChefName { get; set; } = "";
        public void PrepareFood(string foodName)
        {
            if (string.IsNullOrWhiteSpace(foodName))
            {
                Console.WriteLine("Yemek adı boş olamaz.");
                return;
            }

            Console.WriteLine("Aşçı: " + ChefName);
            Console.WriteLine("Hazırlanan Yemek: " + foodName);
            Console.WriteLine("Malzemeler kontrol edildi.");
            Console.WriteLine("Pişirme işlemi başladı.");
            Console.WriteLine("Yemek servise hazırlandı.");
        }

        public void PrintReceipt(int orderId)
        {
            throw new NotSupportedException("Aşçı ödeme fişi oluşturamaz.");
        }

        public void ProcessPayment(decimal amount)
        {
            throw new NotSupportedException("Aşçı ödeme alamaz.");
        }

        public void ServeFood(int tableNumber)
        {
            throw new NotSupportedException("Aşçı masa servisi yapamaz.");
        }

        public void TakeOrder(int tableNumber, string foodName)
        {
            throw new NotImplementedException("Aşçı müşteri siparişi alamaz.");
        }
    }
}
