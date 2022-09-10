namespace bms_data_streamer
{
    using System.Collections.Generic;

    public class TemperatureSensor : ISensor
    {
        private const string SensorName = "Temperature";

        public string GetSensorType()
        {
            return SensorName;
        }

        public IList<double> FetchReadings()
        {
            return ReadingsGenerator.GenerateFiftyReadingsWithinGivenRange(0, 45);
        }
    }
}
