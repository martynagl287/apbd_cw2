using System.Collections.Generic;

namespace Cwiczenia2.Inheritance
{
    public static class ProductTemperatureRequirements
    {
        public static Dictionary<string, double> ProductMinTemperatures = new()
        {
            { "bananas", 13.3 },
            { "chocolate", 18.0 },
            { "fish", 2.0 },
            { "meat", -15.0 },
            { "ice cream", -18.0 },
            { "frozen pizza", -30.0 },
            { "cheese", 7.2 },
            { "sausages", 5.0 },
            { "butter", 20.5 },
            { "eggs", 19.0 }
        };
    }
}