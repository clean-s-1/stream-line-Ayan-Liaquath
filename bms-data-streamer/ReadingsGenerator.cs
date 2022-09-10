namespace bms_data_streamer
{
    using System;
    using System.Collections.Generic;

    public static class ReadingsGenerator
    {
        public static IList<double> GenerateFiftyReadingsWithinGivenRange(double minValue, double maxValue)
        {
            var readings = new List<double>();

            var randomGenerator = new Random();

            for (var count = 0; count < 50; count++)
            {
                readings.Add(Math.Round(randomGenerator.NextDouble() * (maxValue - minValue) + minValue, 2));
            }

            return readings;
        }
    }
}
