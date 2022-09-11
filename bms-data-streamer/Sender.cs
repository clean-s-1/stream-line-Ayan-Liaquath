namespace bms_data_streamer
{
    using System.Collections.Generic;

    public class Sender : ISender
    {
        public IDictionary<string, IList<double>> FetchReadingsFromSensors(IList<ISensor> sensors)
        {
            if (sensors != null && sensors.Count > 1)
            {
                return ProcessSensorData(sensors);
            }

            return null;
        }

        public string FormatSenderOutput(IDictionary<string, IList<double>> senderOutput)
        {
            var formattedOutput = string.Empty;

            if (senderOutput != null)
            {
                formattedOutput = FormatOutput(senderOutput);
            }

            return formattedOutput;
        }

        private static IDictionary<string, IList<double>> ProcessSensorData(IList<ISensor> sensors)
        {
            var readings = new Dictionary<string, IList<double>>();

            for (int index = 0; index < sensors.Count; index++)
            {
                var sensorReadings = sensors[index].FetchReadings();

                if (VerifySensorReadings(sensorReadings))
                {
                    readings.Add(sensors[index].GetSensorType(), sensorReadings);
                }
            }

            return readings;
        }

        private static bool VerifySensorReadings(IList<double> sensorReadings)
        {
            return sensorReadings != null && sensorReadings.Count == 50;
        }

        private static string FormatOutput(IDictionary<string, IList<double>> senderOutput)
        {
            var output = string.Empty;

            foreach (var sensorData in senderOutput)
            {
                output += $"{sensorData.Key}: ";

                output += FormatSensorReadings(sensorData);

                output += "\n\n";
            }

            return output;
        }

        private static string FormatSensorReadings(
            KeyValuePair<string, IList<double>> sensorData)
        {
            var formattedReadings = string.Empty;

            for (var index = 0; index < sensorData.Value?.Count; index++)
            {
                formattedReadings += sensorData.Value[index];

                formattedReadings = CheckAndAddDelimiterBetweenReadings(
                    sensorData.Value.Count, index, formattedReadings);
            }

            return formattedReadings;
        }

        private static string CheckAndAddDelimiterBetweenReadings(
            int readingsCount, int index, string formattedReadings)
        {
            if (index < readingsCount - 1)
            {
                formattedReadings += ",";
            }

            return formattedReadings;
        }
    }
}
