using CommerceFlow.Business.Results;

namespace CommerceFlow.ConsoleUI.Helpers
{
    public static class ConsoleRestaurantDesign
    {
        public static void WriteHeader(string title)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==================================================");
            Console.WriteLine("                 COMMERCE FLOW                    ");
            Console.WriteLine("==================================================");

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  " + title.ToUpper());
            Console.ResetColor();

            Console.WriteLine();
        }
        public static void WriteMenuItem(int number, string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  [" + number + "] ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(title);

            Console.ResetColor();
        }
        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  " + message);
            Console.ResetColor();
        }
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  " + message);
            Console.ResetColor();
        }
        public static void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  " + message);
            Console.ResetColor();
        }
        public static void WaitForKey()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Devam etmek için bir tuşa basınız...");
            Console.ResetColor();

            Console.ReadKey(true);
        }
        public static void WriteResult(ServiceResult result)
        {
            if (result.IsSuccess)
            {
                WriteSuccess(result.Message);
            }
            else
            {
                WriteError(result.Message);
            }
        }

    }
}
