using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.HotelRoomExamples
{
    public class StandardRoom : Room
    {
        public bool HasTelevision { get; set; }
        public bool HasMiniBar { get; set; }

        public override void ProvideRoomService()
        {
            Console.WriteLine("Standart oda hizmetleri hazırlanıyor.");
            Console.WriteLine("Günlük temizlik gerçekleştiriliyor.");
            Console.WriteLine("Temel oda ihtiyaçları kontrol ediliyor.");
        }

        public void ShowStandardRoomFeatures()
        {
            Console.WriteLine("Oda Türü: Standard Room");
            Console.WriteLine("Televizyon: " + HasTelevision);
            Console.WriteLine("Mini Bar: " + HasMiniBar);
        }
    }
}
