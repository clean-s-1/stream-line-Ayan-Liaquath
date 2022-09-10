namespace bms_data_streamer
{
    using System.Collections.Generic;

    public class ChargeRateSensor : ISensor
    {
        private const string SensorType = "Charge Rate";

        public string GetSensorType()
        {
            return SensorType;
        }

        public IList<double> FetchReadings()
        {
            return ReadingsGenerator.GenerateFiftyReadingsWithinGivenRange(0, 1);
        }
    }
}
