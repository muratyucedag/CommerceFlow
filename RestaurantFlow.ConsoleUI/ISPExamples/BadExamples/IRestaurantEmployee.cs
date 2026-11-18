using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFlow.ConsoleUI.ISPExamples.BadExamples
{
    public interface IRestaurantEmployee
    {
        void TakeOrder(int tableNumber, string foodName);

        void PrepareFood(string foodName);

        void ServeFood(int tableNumber);

        void ProcessPayment(decimal amount);

        void PrintReceipt(int orderId);
    }
}
