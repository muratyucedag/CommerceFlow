using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.InheritanceExamples
{
    public class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool HasSunroof { get; set; }

        public void OpenTrunk()
        {
            Console.WriteLine($"{Brand} {Model} bagajı açıldı.");
        }

        public void ActivateAirConditioner()
        {
            Console.WriteLine("Klima çalıştırıldı.");
        }

        public void ShowCarInformation()
        {
            ShowVehicleInformation();

            Console.WriteLine($"Kapı Sayısı: {DoorCount}");
            Console.WriteLine($"Bagaj Hacmi: {TrunkCapacity} litre");
            Console.WriteLine($"Sunroof: {(HasSunroof ? "Var" : "Yok")}");
        }
    }
}
