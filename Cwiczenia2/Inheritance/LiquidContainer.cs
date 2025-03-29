namespace Cwiczenia2.Inheritance
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; }

        public LiquidContainer(double height, double tareWeight, double depth, double maxLoad, bool isHazardous)
            : base(height, tareWeight, depth, maxLoad, "L")
        {
            IsHazardous = isHazardous;
        }

        public override void LoadCargo(double mass)
        {
            double allowedCapacity = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

            if (mass > allowedCapacity)
            {
                NotifyHazard($"Próba przeładowania kontenera {SerialNumber} (Limit: {allowedCapacity}kg, Ładunek: {mass}kg)");
                throw new OverfillException($"Ładunek przekracza dopuszczalną masę w kontenerze {SerialNumber}");
            }

            CargoMass = mass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD - LIQUID] {message}");
        }
    }
}