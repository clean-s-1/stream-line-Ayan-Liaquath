namespace bms_data_streamer
{
    using System.Collections.Generic;

    public interface ISender
    {
        IDictionary<string, IList<double>> FetchReadingsFromSensors(IList<ISensor> sensors);

        string FormatSenderOutput(IDictionary<string, IList<double>> senderOutput);
    }
}
