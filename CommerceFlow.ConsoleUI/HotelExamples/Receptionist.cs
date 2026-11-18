using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.HotelExamples
{
    public class Receptionist : HotelEmployee
    {
        public void ShowRoom()
        {
            Console.WriteLine("Personel: " + FullName);
            Console.WriteLine("Oda Numarası: " + StaffRoom);
        }
    }
}
