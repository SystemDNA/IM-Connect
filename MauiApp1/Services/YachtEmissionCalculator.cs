namespace MauiApp1.Services
{
    public class YachtEmissionCalculator
    {
        // Your existing code...

        public class EmissionInput
        {
            public double DistanceTravelledNm { get; set; }
            public double FuelConsumptionLPH { get; set; }
            public double AverageSpeedKnots { get; set; }
            public string FuelType { get; set; } = "Diesel";
        }

        public class EmissionResult
        {
            public double TotalFuelConsumedL { get; set; }
            public double TotalCO2EmissionsKg { get; set; }
        }

        public static EmissionResult CalculateCO2Emissions(EmissionInput input)
        {
            var factors = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Diesel", 2.65 },
                { "Petrol", 2.31 },
                { "LNG", 2.75 }
            };

            if (input.AverageSpeedKnots <= 0)
                throw new ArgumentException("Average speed must be greater than zero.");
            if (!factors.TryGetValue(input.FuelType, out double factor))
                throw new ArgumentException($"Unsupported fuel type: {input.FuelType}");

            double travelTimeHrs = input.DistanceTravelledNm / input.AverageSpeedKnots;
            double totalFuel = travelTimeHrs * input.FuelConsumptionLPH;
            double totalCO2 = totalFuel * factor;

            return new EmissionResult
            {
                TotalFuelConsumedL = Math.Round(totalFuel, 2),
                TotalCO2EmissionsKg = Math.Round(totalCO2, 2)
            };
        }
    }
}
