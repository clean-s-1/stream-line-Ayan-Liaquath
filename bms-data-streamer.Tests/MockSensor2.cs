namespace bms_data_streamer.Tests
{
    using System.Collections.Generic;

    internal class MockSensor2 : ISensor
    {
        public string GetSensorType() { return "MockSensor2"; }

        public IList<double> FetchReadings()
        {
            return new List<double> { 2, 5 };
        }
    }
}
