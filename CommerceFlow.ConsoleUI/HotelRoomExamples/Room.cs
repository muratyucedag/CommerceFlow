using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.HotelRoomExamples
{
    public abstract class Room
    {
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;


        public void ShowRoomInformation()
        {
            Console.WriteLine("Oda No: " + RoomNumber);
            Console.WriteLine("Kat: " + FloorNumber);
            Console.WriteLine("Gecelik Fiyat: " + PricePerNight);
            Console.WriteLine("Kapasite: " + Capacity);
            Console.WriteLine("Durum: " + (IsAvailable ? "Müsait" : "Dolu"));
        }

        public void ReserveRoom()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine("Oda rezervasyonu oluşturuldu.");
            }
            else
            {
                Console.WriteLine("Oda müsait değil.");
            }
        }

        // Abstract Method
        public abstract void ProvideRoomService();
    }
}