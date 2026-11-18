using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.InheritanceExamples
{
    public class Vehicle
    {
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public int ProductionYear { get; set; }
        public string PlateNumber { get; set; } = "";
        public int CurrentSpeed { get; private set; }

        public void Start()
        {
            Console.WriteLine($"{Brand} {Model} çalıştırıldı.");
        }

        public void Accelerate(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Hız artışı pozitif olmalıdır.");
                return;
            }

            CurrentSpeed += amount;

            Console.WriteLine($"Güncel hız: {CurrentSpeed} km/sa");
        }

        public void Brake(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fren miktarı pozitif olmalıdır.");
                return;
            }

            CurrentSpeed = Math.Max(0, CurrentSpeed - amount);

            Console.WriteLine($"Fren yapıldı. Güncel hız: {CurrentSpeed} km/sa");
        }

        public void Stop()
        {
            CurrentSpeed = 0;
            Console.WriteLine("Araç durduruldu.");
        }


        public void ShowVehicleInformation()
        {
            Console.WriteLine($"Marka: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Üretim Yılı: {ProductionYear}");
            Console.WriteLine($"Plaka: {PlateNumber}");
        }

    }
}
