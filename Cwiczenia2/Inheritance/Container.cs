using System;

namespace  Cwiczenia2.Inheritance
{
    public abstract class Container
    {
        private static int counter = 1;
        public string SerialNumber { get; }
        public double CargoMass { get; protected set; }
        public double Height { get; }
        public double TareWeight { get; }
        public double Depth { get; }
        public double MaxLoad { get; }

        protected Container(double height, double tareWeight, double depth, double maxLoad, string typeCode)
        {
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxLoad = maxLoad;
            CargoMass = 0;

            SerialNumber = GenerateSerialNumber(typeCode);
        }

        private string GenerateSerialNumber(string typeCode)
        {
            return $"KON-{typeCode}-{counter++}";
        }

        public virtual void LoadCargo(double mass)
        {
            if (mass > MaxLoad)
                throw new OverfillException($"Masa {mass}kg przekracza ładowność {MaxLoad}kg");

            CargoMass = mass;
        }

        public virtual void UnloadCargo()
        {
            CargoMass = 0;
        }
    }
}