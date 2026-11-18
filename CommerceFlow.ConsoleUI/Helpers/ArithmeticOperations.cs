namespace CommerceFlow.ConsoleUI.Helpers
{
    public class ArithmeticOperations
    {
        public void AddNumbers(int x1, int x2)
        {
            int x3 = x1 + x2;
            Console.WriteLine("Sonuç: " + x3);
        }

        public void Cikar(int x1, int x2)
        {
            int x3 = x1 - x2;
            Console.WriteLine("Sonuç: " + x3);
        }

        public void Carp(int s1,int s2,int s3)
        {
            int s4 = s1 * s2 * s3;
            Console.WriteLine("Sonuç: " + s4);
        }
    }
}
