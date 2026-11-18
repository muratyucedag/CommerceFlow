
namespace CommerceFlow.ConsoleUI.HotelExamples
{
    public class HotelEmployee
    {
        // PUBLIC - Genel personel bilgileri
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Position { get; set; } = "";
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;


        // PRIVATE - Maaş bilgileri
        private decimal Salary = 45000;
        private decimal Bonus = 0;

        // PROTECTED - Personel çalışma ve konaklama bilgileri
        protected string StaffRoom = "P-205";
        protected string StaffCorridor = "B Blok - Personel Katı";
        protected string Shift = "08:00 - 16:00";
        protected int WeeklyWorkingHours = 45;
        protected int AnnualLeaveDays = 14;


        // PUBLIC METHODS
        public void ShowEmployeeInformation()
        {
            Console.WriteLine("Personel No: " + EmployeeId);
            Console.WriteLine("Ad Soyad: " + FullName);
            Console.WriteLine("Departman: " + Department);
            Console.WriteLine("Pozisyon: " + Position);
            Console.WriteLine("İşe Giriş Tarihi: " + HireDate.ToShortDateString());
            Console.WriteLine("Durum: " + (IsActive ? "Aktif" : "Pasif"));
        }

        public void ShowSalaryInformation()
        {
            Console.WriteLine("Maaş: " + Salary + " TL");
            Console.WriteLine("Prim: " + Bonus + " TL");
            Console.WriteLine("Toplam: " + (Salary + Bonus) + " TL");
        }

        public void IncreaseSalary(decimal amount)
        {
            if (amount > 0)
            {
                Salary += amount;
                Console.WriteLine("Maaş artışı gerçekleştirildi.");
            }
        }
        public void AddBonus(decimal amount)
        {
            if (amount > 0)
            {
                Bonus += amount;
                Console.WriteLine("Personel primi eklendi.");
            }
        }

        // PROTECTED METHODS
        protected void ShowAccommodationInformation()
        {
            Console.WriteLine("Personel Odası: " + StaffRoom);
            Console.WriteLine("Personel Koridoru: " + StaffCorridor);
        }

        protected void ShowWorkingInformation()
        {
            Console.WriteLine("Vardiya: " + Shift);
            Console.WriteLine("Haftalık Çalışma: " + WeeklyWorkingHours + " saat");
            Console.WriteLine("Yıllık İzin: " + AnnualLeaveDays + " gün");
        }

        public virtual void PerformDuty()
        {
            Console.WriteLine($"{FullName} genel otel görevlerini yapıyor.");
        }
        public virtual void StartShift()
        {
            Console.WriteLine($"{FullName} mesaiye başladı.");
        }
    }
}
