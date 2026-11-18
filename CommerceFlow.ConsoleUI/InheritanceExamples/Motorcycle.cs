namespace CommerceFlow.ConsoleUI.InheritanceExamples
{
    public class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSideCase { get; set; }

        public void ActivateHeadlight()
        {
            Console.WriteLine("Motosiklet farı açıldı.");
        }

        public void ShowMotorcycleInformation()
        {
            ShowVehicleInformation();

            Console.WriteLine($"Motor Hacmi: {EngineCapacity} cc");
            Console.WriteLine($"Yan Çanta: {(HasSideCase ? "Var" : "Yok")}");
        }
    }
}
