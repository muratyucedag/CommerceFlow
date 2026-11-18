using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.HotelRoomExamples
{
    public class DeluxeRoom : Room
    {
        // Deluxe odaya özgü özellikler
        public bool HasBalcony { get; set; }
        public bool HasJacuzzi { get; set; }
        public bool HasSeaView { get; set; }
        public int RoomSize { get; set; }

        // Deluxe oda özelliklerini görüntüleme
        public void ShowDeluxeFeatures()
        {
            Console.WriteLine("Oda Türü: Deluxe Room");
            Console.WriteLine("Balkon: " + HasBalcony);
            Console.WriteLine("Jakuzi: " + HasJacuzzi);
            Console.WriteLine("Deniz Manzarası: " + HasSeaView);
            Console.WriteLine("Oda Büyüklüğü: " + RoomSize + " m²");
        }

        // Deluxe odaya özel hizmet
        public void RequestRoomService()
        {
            Console.WriteLine("Deluxe oda için oda servisi talebi oluşturuldu.");
        }

        public override void ProvideRoomService()
        {
            Console.WriteLine("Deluxe oda hizmetleri hazırlanıyor.");
            Console.WriteLine("Özel karşılama ikramı hazırlanıyor.");
            Console.WriteLine("Meyve tabağı odaya gönderiliyor.");
            Console.WriteLine("Deluxe konfor hizmetleri kontrol ediliyor.");
        }
    }
}
