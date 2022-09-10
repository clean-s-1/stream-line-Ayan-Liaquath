namespace bms_data_streamer
{
    using System;

    public interface ICommandProcessor
    {
        void ProcessGivenCommand(string command, Action<string> printerAction);
    }
}
