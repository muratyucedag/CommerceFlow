using RestaurantFlow.ConsoleUI.ISPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.ISPExamples.Employees
{
    public class Chef : IKitchenService
    {
        public string FullName { get; set; } = "";
        public string Specialty { get; set; } = "";
        public int PreparedMealCount { get; private set; }

        public void CheckKitchenStock(string ingredient, int stockQuantity)
        {
            Console.WriteLine("===== MUTFAK STOK KONTROLÜ =====");

            if (string.IsNullOrWhiteSpace(ingredient))
            {
                Console.WriteLine("Malzeme adı boş olamaz.");
                return;
            }

            Console.WriteLine("Malzeme: " + ingredient);
            Console.WriteLine("Stok Miktarı: " + stockQuantity);

            if (stockQuantity < 0)
            {
                Console.WriteLine("Geçersiz stok miktarı.");
            }
            else if (stockQuantity < 5)
            {
                Console.WriteLine("Stok kritik seviyede.");
                Console.WriteLine("Yeni malzeme siparişi gerekli.");
            }
            else
            {
                Console.WriteLine("Stok seviyesi yeterli.");
            }
        }

        public void PrepareFood(string foodName, int quantity)
        {
            Console.WriteLine("===== YEMEK HAZIRLAMA =====");

            if (string.IsNullOrWhiteSpace(foodName))
            {
                Console.WriteLine("Yemek adı boş olamaz.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Hazırlanacak miktar geçersiz.");
                return;
            }

            Console.WriteLine("Aşçı: " + FullName);
            Console.WriteLine("Uzmanlık: " + Specialty);
            Console.WriteLine("Yemek: " + foodName);
            Console.WriteLine("Adet: " + quantity);

            Console.WriteLine("Malzemeler hazırlanıyor.");
            Console.WriteLine("Pişirme süreci başlatıldı.");
            Console.WriteLine("Porsiyonlar hazırlanıyor.");

            PreparedMealCount += quantity;

            Console.WriteLine("Yemekler servise hazır.");
            Console.WriteLine("Hazırlanan Toplam Porsiyon: " + PreparedMealCount);
        }
    }
}
