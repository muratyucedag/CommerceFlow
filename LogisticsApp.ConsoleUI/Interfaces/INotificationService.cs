
namespace LogisticsApp.ConsoleUI.Interfaces
{
    public interface INotificationService
    {
        void SendSms(string phoneNumber);
        void SendEmail(string emailAddress);
    }
}
