
namespace CommerceFlow.ConsoleUI.HotelExamples
{
    public class HouseKeeper : HotelEmployee
    {
        // Kat hizmetlerine özgü özellikler
        public int AssignedFloor { get; set; }
        public int DailyRoomTarget { get; set; }
        public int CleanedRoomCount { get; private set; }


        // Personel odası tahsisi
        public void AssignStaffRoom(string roomNumber)
        {
            StaffRoom = roomNumber;
            Console.WriteLine("Personel odası tahsis edildi.");
        }

        // Vardiya belirleme
        public void AssignShift(string newShift)
        {
            Shift = newShift;
            Console.WriteLine("Vardiya güncellendi.");
        }

        // Oda temizleme işlemi
        public void CleanRoom(int roomNumber)
        {
            if (roomNumber <= 100)
            {
                Console.WriteLine("Geçersiz oda numarası.");
                return;
            }

            CleanedRoomCount++;

            Console.WriteLine($"{roomNumber} numaralı oda temizlendi.");
        }



        // Günlük temizlik durumunu görüntüleme
        public void ShowCleaningStatus()
        {
            Console.WriteLine($"Günlük Hedef: {DailyRoomTarget}");
            Console.WriteLine($"Temizlenen Oda: {CleanedRoomCount}");
            Console.WriteLine($"Kalan Oda: {Math.Max(0, DailyRoomTarget - CleanedRoomCount)}");
        }

        // Personel bilgilerini görüntüleme
        public void ShowHouseKeeperInformation()
        {
            ShowEmployeeInformation();

            Console.WriteLine($"Sorumlu Kat: {AssignedFloor}");

            ShowAccommodationInformation();
            ShowWorkingInformation();
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} görevli olduğu kata çıktı.");
            Console.WriteLine("Odaların durumunu kontrol etti.");
            Console.WriteLine("Temizlik işlemlerine başladı.");
        }
    }
}
