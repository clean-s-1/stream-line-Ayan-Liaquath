namespace bms_data_streamer.Tests
{
    using System.Collections.Generic;

    using Xunit;

    public class SenderTests
    {
        private readonly ISender _Sender;

        private readonly IList<ISensor> _Sensors;

        public SenderTests()
        {
            _Sender = new Sender();

            _Sensors = new List<ISensor>
            {
                new TemperatureSensor(),
                new ChargeRateSensor()
            };
        }

        [Fact]
        public void TestFetchReadingsWithTwoSensors()
        {
            var readings = _Sender.FetchReadingsFromSensors(_Sensors);

            Assert.Equal(2, readings.Count);

            AssertSensorNames(readings);

            AssertSensorReadingCount(readings);
        }

        [Fact]
        public void TestFetchReadingsWithOneSensor()
        {
            _Sensors.RemoveAt(_Sensors.Count - 1);

            Assert.Null(_Sender.FetchReadingsFromSensors(_Sensors));
        }

        [Fact]
        public void TestFetchReadingsWithInvalidReadings()
        {
            var readings = _Sender.FetchReadingsFromSensors(new List<ISensor> { new MockSensor1(), new MockSensor2() });

            Assert.Equal(0, readings.Count);
        }

        [Fact]
        public void TestFetchReadingsWithNoSensors()
        {
            Assert.Null(_Sender.FetchReadingsFromSensors(new List<ISensor>()));

            Assert.Null(_Sender.FetchReadingsFromSensors(null));
        }

        [Fact]
        public void TestFormatSenderOutput()
        {
            var mockSensor2 = new MockSensor2();

            var formattedOutput = _Sender.FormatSenderOutput(new Dictionary<string, IList<double>>
            {
                { mockSensor2.GetSensorType(), mockSensor2.FetchReadings() }
            });

            Assert.Equal($"{mockSensor2.GetSensorType()}: {mockSensor2.FetchReadings()[0]},{mockSensor2.FetchReadings()[1]}\n\n", formattedOutput);
        }

        [Fact]
        public void TestFormatSenderOutputWithInvalidReadings()
        {
            var mockSensor1 = new MockSensor1();

            var formattedOutput = _Sender.FormatSenderOutput(new Dictionary<string, IList<double>>
            {
                { mockSensor1.GetSensorType(), mockSensor1.FetchReadings() }
            });

            Assert.Equal($"{mockSensor1.GetSensorType()}: \n\n", formattedOutput);
        }

        [Fact]
        public void TestFormatSenderOutputWithInvalidInput()
        {
            Assert.Equal(string.Empty, _Sender.FormatSenderOutput(new Dictionary<string, IList<double>>()));

            Assert.Equal(string.Empty, _Sender.FormatSenderOutput(null));
        }

        private static void AssertSensorReadingCount(IDictionary<string, IList<double>> readings)
        {
            foreach (var sensorReadings in readings.Values)
            {
                Assert.Equal(50, sensorReadings.Count);
            }
        }

        private void AssertSensorNames(IDictionary<string, IList<double>> readings)
        {
            foreach (var sensor in _Sensors)
            {
                Assert.True(readings.Keys.Contains(sensor.GetSensorType()));
            }
        }
    }
}
