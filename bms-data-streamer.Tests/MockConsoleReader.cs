namespace bms_data_streamer.Tests
{
    internal class MockConsoleReader : IConsoleReader
    {
        public int Count { get; set; }

        public string GetInput()
        {
            Count++;

            return Count <= 1 ? "test-command" : string.Empty;
        }
    }
}
