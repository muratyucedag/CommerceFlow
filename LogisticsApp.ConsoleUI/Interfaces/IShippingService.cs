namespace LogisticsApp.ConsoleUI.Interfaces
{
    public interface IShippingService
    {
        void CreateShipment();
        void TrackShipment();
        void CancelShipment();
    }
}
