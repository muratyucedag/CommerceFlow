namespace CommerceFlow.ConsoleUI.Helpers
{
    public class OverLoadingExamples
    {
        public int TotalSum(int a, int b)
        {
            return a + b;
        }

        public int TotalSum(int a, int b, int c)
        {
            return (a + b + c);
        }

        public int TotalSum(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }

        public string PersonCard(string name, string surname)
        {
            return name + " " + surname;
        }

        public string PersonCard(string name, string surname, string email)
        {
            return name + " " + surname + " " + email;
        }
    }
}
