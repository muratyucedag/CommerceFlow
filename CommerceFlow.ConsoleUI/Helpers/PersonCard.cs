
namespace CommerceFlow.ConsoleUI.Helpers
{
    public class PersonCard
    {
        public void DescriptionPerson(string name,string surname,string district,string city)
        {
            Console.WriteLine("Müşteri Adı: " + name);
            Console.WriteLine("Müşteri Soyadı: " + surname);
            Console.WriteLine("Müşteri İlçe: " + district);
            Console.WriteLine("Müşteri Şehir: " + city);
        }
    }
}
