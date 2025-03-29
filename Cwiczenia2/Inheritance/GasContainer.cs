using System;
using Cwiczenia2.Inheritance;

namespace Cwiczenia2.Inheritance
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; }

        public GasContainer(double height, double tareWeight, double depth, double maxLoad, double pressure)
            : base(height, tareWeight, depth, maxLoad, "G")
        {
            Pressure = pressure;
        }

        public override void LoadCargo(double mass)
        {
            if (mass > MaxLoad)
            {
                NotifyHazard($"Próba przeładowania kontenera {SerialNumber}");
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
            }

            CargoMass = mass;
        }

        public override void UnloadCargo()
        {
            CargoMass *= 0.05;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD - GAS] {message}");
        }
    }
}