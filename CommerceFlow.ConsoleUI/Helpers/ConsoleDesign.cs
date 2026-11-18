namespace CommerceFlow.ConsoleUI.Helpers
{
    public class ConsoleDesign
    {
        public void ShowBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("             COMMERCEFLOW E-COMMERCE              ");
            Console.WriteLine("==================================================");
            Console.ResetColor();
            Console.WriteLine("          E-Ticaret Yönetim Simülasyonu           ");
            Console.WriteLine();
        }

        public void ShowSectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"              {title}");
            Console.WriteLine("========================================");

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
