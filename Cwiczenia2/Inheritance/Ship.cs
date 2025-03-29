using System;
using System.Collections.Generic;
using System.Linq;

namespace Cwiczenia2.Inheritance
{
    public class Ship
    {
        public string Name { get; }
        public double MaxSpeedKnots { get; }
        public int MaxContainers { get; }
        public double MaxWeightTons { get; }

        private List<Container> containers = new();

        public Ship(string name, double maxSpeedKnots, int maxContainers, double maxWeightTons)
        {
            Name = name;
            MaxSpeedKnots = maxSpeedKnots;
            MaxContainers = maxContainers;
            MaxWeightTons = maxWeightTons;
        }

        public bool LoadContainer(Container container)
        {
            if (containers.Count >= MaxContainers)
            {
                Console.WriteLine("Za dużo kontenerów.");
                return false;
            }

            double currentWeightTons = containers.Sum(c => (c.TareWeight + c.CargoMass) / 1000.0);
            double newWeightTons = (container.TareWeight + container.CargoMass) / 1000.0;

            if (currentWeightTons + newWeightTons > MaxWeightTons)
            {
                Console.WriteLine("Przekroczono maksymalną wagę.");
                return false;
            }

            containers.Add(container);
            return true;
        }

        public void LoadContainers(List<Container> containerList)
        {
            foreach (var c in containerList)
            {
                LoadContainer(c);
            }
        }

        public void UnloadContainer(string serialNumber)
        {
            containers.RemoveAll(c => c.SerialNumber == serialNumber);
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            int index = containers.FindIndex(c => c.SerialNumber == serialNumber);
            if (index != -1)
                containers[index] = newContainer;
        }

        public void TransferContainerTo(Ship otherShip, string serialNumber)
        {
            var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null && otherShip.LoadContainer(container))
            {
                containers.Remove(container);
            }
        }

        public void PrintContainerInfo(string serialNumber)
        {
            var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Console.WriteLine(container.ToString());
            }
            else
            {
                Console.WriteLine($"Kontener {serialNumber} nie istnieje na statku.");
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Statek: {Name}");
            Console.WriteLine($"Max kontenery: {MaxContainers}, Max masa: {MaxWeightTons}t, Max prędkość: {MaxSpeedKnots} węzłów");
            Console.WriteLine($"Liczba kontenerów: {containers.Count}");
            foreach (var c in containers)
            {
                Console.WriteLine($" - {c.SerialNumber} ({c.GetType().Name})");
            }
        }
    }
}