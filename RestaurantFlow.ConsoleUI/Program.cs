
using RestaurantFlow.ConsoleUI.DIPExamples.Services;

SmsService smsService = new SmsService();

OrderManager orderManager = new OrderManager(smsService);

orderManager.CreateOrder(1001, "Ahmet Yılmaz", "05551234567", "Hamburger Menü", 2, 350);

Console.WriteLine();

orderManager.ShowOrderSummary();


EmailService emailService = new EmailService();

emailService.SenderEmail = "siparis@restaurantflow.com";
emailService.EmailSubject = "Siparişiniz Alındı";

orderManager.CreateOrder(1002, "Zeynep Demir", "zeynep@example.com", "Pizza Menü", 3, 400);

Console.WriteLine();

orderManager.ShowOrderSummary();

Console.ReadLine();

Console.ReadLine();
