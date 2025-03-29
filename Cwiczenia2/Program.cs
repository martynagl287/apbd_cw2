using System;
using Cwiczenia2.Inheritance;

namespace Cwiczenia2.Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ship ship = new("Baltic Carrier", 25.0, 5, 150);

                var container1 = new RefrigeratedContainer(260, 3000, 600, 27000, "bananas", 14);
                var container2 = new LiquidContainer(250, 2000, 550, 24000, true);
                var container3 = new GasContainer(250, 2500, 600, 20000, 10);

                container1.LoadCargo(13000);
                container2.LoadCargo(12000);
                container3.LoadCargo(19000);

                ship.LoadContainer(container1);
                ship.LoadContainer(container2);
                ship.LoadContainer(container3);

                ship.PrintShipInfo();
            }
            catch (OverfillException ex)
            {
                Console.WriteLine($"Przepełnienie: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd uruchomienia: {ex.Message}");
            }
        }
    }
}