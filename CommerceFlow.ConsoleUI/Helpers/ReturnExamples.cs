namespace CommerceFlow.ConsoleUI.Helpers
{
    public class ReturnExamples
    {
        public int TotalSum(int s1, int s2)
        {
            int s3 = s1 + s2;
            return s3;
        }

        public int TotalSum2(int a, int b, int c)
        {
            int d = a + b + c;
            return d;
        }

        public string GetFullName(string name, string surname)
        {
            return name + " " + surname;
        }

        public string GetProductInformation(string productName, decimal price)
        {
            return "Ürün Adı: " + productName + " " + "Fiyat: " + price;
        }
    }
}
