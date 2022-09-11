namespace bms_data_streamer.Tests
{
    using System.Collections.Generic;

    internal class MockSensor1 : ISensor
    {
        public string GetSensorType() { return "MockSensor1"; }

        public IList<double> FetchReadings()
        {
            return null;
        }
    }
}
