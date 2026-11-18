namespace RestaurantFlow.ConsoleUI.LSPExamples.Interfaces
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
    }
}
