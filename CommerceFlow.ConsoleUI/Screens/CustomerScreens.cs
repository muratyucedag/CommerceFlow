using CommerceFlow.Business.Abstract;
using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.Screens
{
    public class CustomerScreens
    {
        private readonly ICustomerService _customerService;
        public CustomerScreens(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void ShowCustomers()
        {
            ConsoleRestaurantDesign.WriteHeader("Müşteri Listesi");
            List<Customer> customers = _customerService.GetAllCustomers();

            if (customers.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Kayıtlı müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"ID",-5} {"AD SOYAD",-24} {"E-POSTA",-32} {"ŞEHİR",-18}");
            Console.WriteLine(new string('-', 85));
            Console.ResetColor();

            foreach (Customer customer in customers)
            {
                string fullName = customer.CustomerName + " " + customer.CustomerSurname;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {customer.CustomerId,-5}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" {fullName,-24} " + $"{customer.CustomerEmail,-32} " + $"{customer.City,-18}");
            }

            Console.ResetColor();

            Console.WriteLine(new string('-', 85));
            ConsoleRestaurantDesign.WriteSuccess($"Toplam {customers.Count} müşteri listelendi.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowCustomerDetail()
        {
            ConsoleRestaurantDesign.WriteHeader("Müşteri Detayı");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int customerId) || customerId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir müşteri ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen ID değerine ait müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ------------------------------------------------");
            Console.WriteLine("                  MÜŞTERİ BİLGİLERİ");
            Console.WriteLine("  ------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri ID    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ad            : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Soyad         : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerSurname);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  E-Posta       : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerEmail);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Telefon       : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerPhone);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İlçe          : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.District);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Şehir         : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.City);

            Console.ResetColor();

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Müşteri bilgileri başarıyla getirildi.");

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void AddCustomer()
        {
            ConsoleRestaurantDesign.WriteHeader("Yeni Müşteri Ekle");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("  Müşteri Adı    : ");
            Console.ResetColor();
            string? name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri Soyadı : ");
            Console.ResetColor();
            string? surname = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  E-Posta Adresi : ");
            Console.ResetColor();
            string? email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Telefon        : ");
            Console.ResetColor();
            string? phone = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İlçe           : ");
            Console.ResetColor();
            string? district = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Şehir          : ");
            Console.ResetColor();
            string? city = Console.ReadLine();

            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(district) || string.IsNullOrWhiteSpace(city))
            {
                ConsoleRestaurantDesign.WriteError("Müşteri bilgileri boş bırakılamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer customer = new Customer
            {
                CustomerName = name.Trim(),
                CustomerSurname = surname.Trim(),
                CustomerEmail = email.Trim(),
                CustomerPhone = phone.Trim(),
                District = district.Trim(),
                City = city.Trim()
            };

            ConsoleRestaurantDesign.WriteInfo("Müşteri kaydı oluşturuluyor...");
            _customerService.AddCustomer(customer);
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void DeleteCustomer()
        {
            ConsoleRestaurantDesign.WriteHeader("Müşteri Silme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Silinecek Müşteri ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int customerId) || customerId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir müşteri ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                ConsoleRestaurantDesign.WriteError("Silinecek müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("              SİLİNECEK MÜŞTERİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Müşteri ID : {customer.CustomerId}");
            Console.WriteLine($"  Ad         : {customer.CustomerName}");
            Console.WriteLine($"  Soyad      : {customer.CustomerSurname}");
            Console.WriteLine($"  E-Posta    : {customer.CustomerEmail}");
            Console.WriteLine($"  Telefon    : {customer.CustomerPhone}");
            Console.WriteLine($"  İlçe       : {customer.District}");
            Console.WriteLine($"  Şehir      : {customer.City}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  Bu müşteriyi silmek istediğinize emin misiniz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Müşteri silme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            try
            {
                _customerService.DeleteCustomer(customerId);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                ConsoleRestaurantDesign.WriteError("Müşteri silinemedi. Müşteriye ait sipariş kayıtları bulunuyor olabilir.");
            }

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void UpdateCustomer()
        {
            ConsoleRestaurantDesign.WriteHeader("Müşteri Güncelleme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Güncellenecek Müşteri ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int customerId) || customerId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir müşteri ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                ConsoleRestaurantDesign.WriteError("Güncellenecek müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ----------------------------------------------");
            Console.WriteLine("             MEVCUT MÜŞTERİ BİLGİLERİ");
            Console.WriteLine("  ----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Müşteri ID : {customer.CustomerId}");
            Console.WriteLine($"  Ad         : {customer.CustomerName}");
            Console.WriteLine($"  Soyad      : {customer.CustomerSurname}");
            Console.WriteLine($"  E-Posta    : {customer.CustomerEmail}");
            Console.WriteLine($"  Telefon    : {customer.CustomerPhone}");
            Console.WriteLine($"  İlçe       : {customer.District}");
            Console.WriteLine($"  Şehir      : {customer.City}");

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteInfo("Değiştirmek istemediğiniz alanları boş bırakabilirsiniz.");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Ad         : ");
            Console.ResetColor();
            string? name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Soyad      : ");
            Console.ResetColor();
            string? surname = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni E-Posta    : ");
            Console.ResetColor();
            string? email = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Telefon    : ");
            Console.ResetColor();
            string? phone = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni İlçe       : ");
            Console.ResetColor();
            string? district = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Şehir      : ");
            Console.ResetColor();
            string? city = Console.ReadLine();

            // Mevcut bilgileri geçici olarak saklayalım.
            string oldName = customer.CustomerName;
            string oldSurname = customer.CustomerSurname;
            string oldEmail = customer.CustomerEmail;
            string oldPhone = customer.CustomerPhone;
            string oldDistrict = customer.District;
            string oldCity = customer.City;

            // Boş bırakılmayan alanları güncelleyelim.
            if (!string.IsNullOrWhiteSpace(name))
                customer.CustomerName = name.Trim();

            if (!string.IsNullOrWhiteSpace(surname))
                customer.CustomerSurname = surname.Trim();

            if (!string.IsNullOrWhiteSpace(email))
                customer.CustomerEmail = email.Trim();

            if (!string.IsNullOrWhiteSpace(phone))
                customer.CustomerPhone = phone.Trim();

            if (!string.IsNullOrWhiteSpace(district))
                customer.District = district.Trim();

            if (!string.IsNullOrWhiteSpace(city))
                customer.City = city.Trim();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------------- GÜNCELLEME ÖZETİ --------------");
            Console.ResetColor();

            Console.WriteLine($"  Ad      : {oldName} -> {customer.CustomerName}");
            Console.WriteLine($"  Soyad   : {oldSurname} -> {customer.CustomerSurname}");
            Console.WriteLine($"  E-Posta : {oldEmail} -> {customer.CustomerEmail}");
            Console.WriteLine($"  Telefon : {oldPhone} -> {customer.CustomerPhone}");
            Console.WriteLine($"  İlçe    : {oldDistrict} -> {customer.District}");
            Console.WriteLine($"  Şehir   : {oldCity} -> {customer.City}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Değişiklikleri kaydetmek istiyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Müşteri güncelleme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            _customerService.UpdateCustomer(customer);

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void SearchCustomerByEmail()
        {
            ConsoleRestaurantDesign.WriteHeader("E-Posta ile Müşteri Arama");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri E-Posta Adresi: ");
            Console.ResetColor();

            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleRestaurantDesign.WriteError("E-posta adresi boş bırakılamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerByEmail(email.Trim());

            if (customer == null)
            {
                ConsoleRestaurantDesign.WriteError("Bu e-posta adresine ait müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("  ------------------------------------------------");
            Console.WriteLine("                MÜŞTERİ ARAMA SONUCU");
            Console.WriteLine("  ------------------------------------------------");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri ID    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ad            : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Soyad         : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerSurname);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  E-Posta       : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerEmail);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Telefon       : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.CustomerPhone);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İlçe          : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.District);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Şehir         : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(customer.City);

            Console.ResetColor();

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Müşteri başarıyla bulundu.");

            ConsoleRestaurantDesign.WaitForKey();
        }




        public void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu işlem daha sonra geliştirilecek.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
