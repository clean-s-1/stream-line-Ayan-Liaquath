namespace bms_data_streamer
{
    using System.Collections.Generic;

    public interface ISensor
    {
        string GetSensorType();

        IList<double> FetchReadings();
    }
}
