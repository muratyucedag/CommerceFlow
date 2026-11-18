
namespace RestaurantFlow.ConsoleUI.ISPExamples.Interfaces
{
    public interface IKitchenService
    {
        void PrepareFood(string foodName, int quantity);
        void CheckKitchenStock(string ingredient, int stockQuantity);
    }
}
