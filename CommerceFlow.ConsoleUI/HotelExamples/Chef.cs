
namespace CommerceFlow.ConsoleUI.HotelExamples
{
    public class Chef : HotelEmployee
    { 
        // Aşçıya özgü özellikler
        public string Specialty { get; set; } = "";
        public string KitchenSection { get; set; } = "";
        public int ExperienceYears { get; set; }
        public bool HasHygieneCertificate { get; set; }


        // Aşçının görevini gerçekleştirmesi
        public void PrepareMeal(string mealName)
        {
            Console.WriteLine($"{FullName} tarafından {mealName} hazırlandı.");
        }

        // Protected üyelere erişim
        public void AssignStaffRoom(string roomNumber)
        {
            StaffRoom = roomNumber;
            Console.WriteLine("Personel odası tahsis edildi.");
        }

        public void ChangeShift(string newShift)
        {
            Shift = newShift;
            Console.WriteLine("Aşçının vardiyası güncellendi.");
        }

        // Aşçı bilgilerini görüntüleme
        public void ShowChefInformation()
        {
            ShowEmployeeInformation();

            Console.WriteLine($"Uzmanlık: {Specialty}");
            Console.WriteLine($"Mutfak Bölümü: {KitchenSection}");
            Console.WriteLine($"Deneyim: {ExperienceYears} yıl");
            Console.WriteLine($"Hijyen Sertifikası: {HasHygieneCertificate}");

            ShowAccommodationInformation();
            ShowWorkingInformation();
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} mutfağa geçti.");
            Console.WriteLine("Malzemeler kontrol edildi.");
            Console.WriteLine("Yemek hazırlıkları başladı.");
        }

        public override void StartShift()
        {
            Console.WriteLine($"{FullName} mutfak vardiyasını başlattı.");
        }
    }
}