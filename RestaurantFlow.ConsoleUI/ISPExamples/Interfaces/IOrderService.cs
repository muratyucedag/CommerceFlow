
namespace RestaurantFlow.ConsoleUI.ISPExamples.Interfaces
{
    public interface IOrderService
    {
        void TakeOrder(int tableNumber, string foodName, int quantity);
        void ServeFood(int tableNumber);
    }
}
