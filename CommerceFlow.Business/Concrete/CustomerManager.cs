using CommerceFlow.Business.Abstract;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Müşteri bilgisi bulunamadı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerName) || string.IsNullOrWhiteSpace(customer.CustomerSurname))
            {
                Console.WriteLine("Müşteri adı ve soyadı boş olamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerEmail) || !customer.CustomerEmail.Contains("@"))
            {
                Console.WriteLine("Geçerli bir e-posta adresi giriniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerPhone))
            {
                Console.WriteLine("Telefon numarası boş olamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customer.City))
            {
                Console.WriteLine("Müşteri şehir bilgisi boş olamaz.");
                return;
            }

            customer.CustomerEmail = customer.CustomerEmail.Trim();

            Customer? existingCustomer = _customerRepository.GetCustomerByEmail(customer.CustomerEmail);

            if (existingCustomer != null)
            {
                Console.WriteLine("Bu e-posta adresiyle kayıtlı bir müşteri mevcut.");

                return;
            }

            _customerRepository.Insert(customer);

            Console.WriteLine("Müşteri başarıyla kaydedildi.");
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null || customer.CustomerId <= 0)
            {
                Console.WriteLine("Müşteri bilgileri geçersiz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerName) || string.IsNullOrWhiteSpace(customer.CustomerSurname) || string.IsNullOrWhiteSpace(customer.CustomerEmail) || !customer.CustomerEmail.Contains("@") || string.IsNullOrWhiteSpace(customer.CustomerPhone) || string.IsNullOrWhiteSpace(customer.City))
            {
                Console.WriteLine("Müşteri bilgileri eksik veya geçersiz.");
                return;
            }

            Customer? existingCustomer = _customerRepository.GetById(customer.CustomerId);

            if (existingCustomer == null)
            {
                Console.WriteLine("Güncellenecek müşteri bulunamadı.");
                return;
            }

            customer.CustomerEmail = customer.CustomerEmail.Trim();

            Customer? emailOwner = _customerRepository.GetCustomerByEmail(customer.CustomerEmail);

            if (emailOwner != null && emailOwner.CustomerId != customer.CustomerId)
            {
                Console.WriteLine("Bu e-posta başka bir müşteri tarafından kullanılıyor.");

                return;
            }

            _customerRepository.Update(customer);

            Console.WriteLine("Müşteri bilgileri güncellendi.");
        }

        public void DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Geçersiz müşteri ID değeri.");
                return;
            }

            Customer? customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                Console.WriteLine("Silinecek müşteri bulunamadı.");
                return;
            }

            _customerRepository.Delete(customer);

            Console.WriteLine("Müşteri başarıyla silindi.");
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer? GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _customerRepository.GetById(id);
        }

        public Customer? GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            return _customerRepository.GetCustomerByEmail(email.Trim());
        }
    }
}