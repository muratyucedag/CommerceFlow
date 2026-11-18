
namespace CommerceFlow.ConsoleUI.InheritanceExamples
{
    public class Truck : Vehicle
    {
        public decimal LoadCapacity { get; set; }
        public decimal CurrentLoad { get; private set; }

        public void LoadCargo(decimal weight)
        {
            if (weight <= 0)
            {
                Console.WriteLine("Yük ağırlığı pozitif olmalıdır.");
                return;
            }

            if (CurrentLoad + weight > LoadCapacity)
            {
                Console.WriteLine("Yük kapasitesi aşılıyor!");
                return;
            }

            CurrentLoad += weight;

            Console.WriteLine($"Yükleme tamamlandı. Mevcut yük: {CurrentLoad} ton");
        }

        public void ShowTruckInformation()
        {
            ShowVehicleInformation();

            Console.WriteLine($"Yük Kapasitesi: {LoadCapacity} ton");
            Console.WriteLine($"Mevcut Yük: {CurrentLoad} ton");
        }
    }
}
