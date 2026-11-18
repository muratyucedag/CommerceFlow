using LogisticsApp.ConsoleUI.Services;

NationalCargo nationalCargo = new NationalCargo();

nationalCargo.SenderCity = "İstanbul";
nationalCargo.ReceiverCity = "Ankara";
nationalCargo.TransferCenter = "Ankara Merkez";

Console.WriteLine("=== KARGO İŞLEMLERİ ===");

nationalCargo.CreateShipment();
nationalCargo.TrackShipment();

Console.WriteLine();

Console.WriteLine("=== BİLDİRİM İŞLEMLERİ ===");

nationalCargo.SendSms("05551234567");

Console.WriteLine();

nationalCargo.SendEmail("musteri@example.com");

Console.ReadLine();