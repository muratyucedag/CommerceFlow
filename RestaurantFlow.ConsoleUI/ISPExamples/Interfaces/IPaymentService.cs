
namespace RestaurantFlow.ConsoleUI.ISPExamples.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(decimal amount, decimal receivedAmount);
        void PrintReceipt(int orderId, decimal amount);
    }
}
