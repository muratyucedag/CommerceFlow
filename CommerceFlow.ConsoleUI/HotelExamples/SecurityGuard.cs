using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.HotelExamples
{
    public class SecurityGuard : HotelEmployee
    {
        // Güvenlik görevlisine özgü özellikler
        public string SecurityArea { get; set; } = "";
        public bool HasSecurityCertificate { get; set; }
        public int IncidentCount { get; private set; }


        // Görev bölgesi belirleme
        public void AssignSecurityArea(string area)
        {
            SecurityArea = area;
            Console.WriteLine("Güvenlik bölgesi belirlendi.");
        }

        // Olay kaydı oluşturma
        public void ReportIncident(string description)
        {
            IncidentCount++;

            Console.WriteLine("Güvenlik olayı kaydedildi.");
            Console.WriteLine("Olay: " + description);
            Console.WriteLine("Toplam Olay: " + IncidentCount);
        }

        // Protected alanın kullanımı
        public void ChangeShift(string newShift)
        {
            Shift = newShift;
            Console.WriteLine("Güvenlik vardiyası güncellendi.");
        }

        // Virtual metodun yeniden uygulanması
        public override void StartShift()
        {
            Console.WriteLine($"{FullName} güvenlik vardiyasını başlattı.");
            Console.WriteLine("Güvenlik ekipmanları kontrol edildi.");
        }

        // Polymorphism için override
        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} güvenlik noktasına geçti.");
            Console.WriteLine($"{SecurityArea} bölgesinde devriye başladı.");
            Console.WriteLine("Giriş ve çıkış kontrolleri gerçekleştiriliyor.");
        }

        // Güvenlik personeli bilgileri
        public void ShowSecurityInformation()
        {
            ShowEmployeeInformation();
            Console.WriteLine("Güvenlik Bölgesi: " + SecurityArea);
            Console.WriteLine("Güvenlik Sertifikası: " + HasSecurityCertificate);
            Console.WriteLine("Olay Sayısı: " + IncidentCount);
            ShowWorkingInformation();
        }
    }
}
