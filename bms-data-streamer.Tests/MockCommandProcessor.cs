namespace bms_data_streamer.Tests
{
    using System;

    internal class MockCommandProcessor : ICommandProcessor
    {
        public string Command { get; private set; }

        public int ProcessFuncCallCount { get; private set; }

        public void ProcessGivenCommand(string command, Action<string> printerAction)
        {
            Command = command;
            ProcessFuncCallCount++;
        }
    }
}
