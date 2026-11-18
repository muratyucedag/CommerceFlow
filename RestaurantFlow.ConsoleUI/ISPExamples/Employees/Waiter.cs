
using RestaurantFlow.ConsoleUI.ISPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.ISPExamples.Employees
{
    public class Waiter : IOrderService
    {
        public string FullName { get; set; } = "";
        public int TotalOrders { get; private set; }
        public int LastOrderTable { get; private set; }

        public void ServeFood(int tableNumber)
        {
            Console.WriteLine("===== YEMEK SERVİSİ =====");

            if (tableNumber <= 0)
            {
                Console.WriteLine("Geçersiz masa numarası.");
                return;
            }

            if (tableNumber != LastOrderTable)
            {
                Console.WriteLine("Bu masa için kayıtlı sipariş bulunamadı.");
                return;
            }

            Console.WriteLine("Garson: " + FullName);
            Console.WriteLine("Masa No: " + tableNumber);
            Console.WriteLine("Hazırlanan yemekler kontrol edildi.");
            Console.WriteLine("Yemekler masaya servis edildi.");
        }

        public void TakeOrder(int tableNumber, string foodName, int quantity)
        {
            Console.WriteLine("===== SİPARİŞ ALMA =====");

            if (tableNumber <= 0)
            {
                Console.WriteLine("Geçersiz masa numarası.");
                return;
            }

            if (string.IsNullOrWhiteSpace(foodName))
            {
                Console.WriteLine("Yemek adı boş olamaz.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Sipariş miktarı geçersiz.");
                return;
            }

            TotalOrders++;
            LastOrderTable = tableNumber;

            Console.WriteLine("Garson: " + FullName);
            Console.WriteLine("Masa No: " + tableNumber);
            Console.WriteLine("Yemek: " + foodName);
            Console.WriteLine("Adet: " + quantity);
            Console.WriteLine("Sipariş mutfağa iletildi.");
            Console.WriteLine("Toplam Sipariş Sayısı: " + TotalOrders);
        }
    }
}
