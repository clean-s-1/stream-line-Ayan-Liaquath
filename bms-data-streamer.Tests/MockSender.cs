namespace bms_data_streamer.Tests
{
    using System.Collections.Generic;

    internal class MockSender : ISender
    {
        private readonly ISender _Sender;

        public MockSender()
        {
            _Sender = new Sender();
        }

        public IDictionary<string, IList<double>> FetchReadingsFromSensors(IList<ISensor> sensors)
        {
            return new Dictionary<string, IList<double>> { { sensors[0].GetSensorType(), sensors[0].FetchReadings() } };
        }

        public string FormatSenderOutput(IDictionary<string, IList<double>> senderOutput)
        {
            return _Sender.FormatSenderOutput(senderOutput);
        }
    }
}
