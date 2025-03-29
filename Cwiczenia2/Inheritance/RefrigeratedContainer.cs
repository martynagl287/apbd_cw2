using System;

namespace Cwiczenia2.Inheritance
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        public string ProductType { get; }
        public double Temperature { get; }

        public RefrigeratedContainer(double height, double tareWeight, double depth, double maxLoad, string productType, double temperature)
            : base(height, tareWeight, depth, maxLoad, "C")
        {
            ProductType = productType;
            Temperature = temperature;
        }

        public override void LoadCargo(double mass)
        {
            if (ProductTemperatureRequirements.ProductMinTemperatures.TryGetValue(ProductType.ToLower(), out double requiredTemp))
            {
                if (Temperature < requiredTemp)
                {
                    NotifyHazard($"Temperatura kontenera {SerialNumber} ({Temperature}°C) jest zbyt niska dla produktu '{ProductType}' (min: {requiredTemp}°C).");
                    throw new OverfillException($"Zbyt niska temperatura dla produktu '{ProductType}' w kontenerze {SerialNumber}.");
                }
            }
            else
            {
                NotifyHazard($"Nieznany typ produktu '{ProductType}' dla kontenera {SerialNumber} – brak danych o temperaturze.");
                throw new OverfillException($"Nieznany produkt '{ProductType}' – nie można go załadować.");
            }

            if (mass > MaxLoad)
            {
                NotifyHazard($"Próba przeładowania kontenera {SerialNumber} (Limit: {MaxLoad}kg, Ładunek: {mass}kg)");
                throw new OverfillException($"Ładunek przekracza dopuszczalną masę w kontenerze {SerialNumber}");
            }

            CargoMass = mass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD - REFRIGERATED] {message}");
        }
    }
}