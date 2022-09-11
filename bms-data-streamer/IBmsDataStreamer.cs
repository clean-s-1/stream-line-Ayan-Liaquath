namespace bms_data_streamer
{
    using System;

    public interface IBmsDataStreamer
    {
        void RunStreamer(Action<string> printerAction, IConsoleReader consoleReader);
    }
}
