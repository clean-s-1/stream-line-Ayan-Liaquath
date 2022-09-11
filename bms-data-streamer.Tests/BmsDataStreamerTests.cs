namespace bms_data_streamer.Tests
{
    using Xunit;

    public class BmsDataStreamerTests
    {
        private readonly MockCommandProcessor _MockCommandProcessor;

        private readonly MockConsoleReader _MockReader;

        private readonly IBmsDataStreamer _BmsDataStreamer;

        private string _DataPrinted;

        private int _FunctionCallCount;

        public BmsDataStreamerTests()
        {
            _MockCommandProcessor = new MockCommandProcessor();

            _BmsDataStreamer = new BmsDataStreamer(_MockCommandProcessor);

            _MockReader = new MockConsoleReader();

            _DataPrinted = string.Empty;

            _FunctionCallCount = 0;
        }

        [Fact]
        public void TestRunStreamerWithValidCommand()
        {
            _BmsDataStreamer.RunStreamer(MockPrinterAction, _MockReader);

            Assert.Equal(2, _MockReader.Count);

            Assert.Equal(1, _MockCommandProcessor.ProcessFuncCallCount);

            Assert.Equal("test-command", _MockCommandProcessor.Command);

            Assert.Equal(3, _FunctionCallCount);

            Assert.Equal("BMS Data Streamer\n\nPress Enter to exit....\nEnter command: Press Enter to exit....\nEnter command: ", _DataPrinted);
        }

        [Fact]
        public void TestRunStreamerWithExitCommand()
        {
            _MockReader.Count++;

            _BmsDataStreamer.RunStreamer(MockPrinterAction, _MockReader);

            Assert.Equal(2, _MockReader.Count);

            Assert.Equal(0, _MockCommandProcessor.ProcessFuncCallCount);

            Assert.Null(_MockCommandProcessor.Command);

            Assert.Equal(2, _FunctionCallCount);

            Assert.Equal("BMS Data Streamer\n\nPress Enter to exit....\nEnter command: ", _DataPrinted);
        }

        [Fact]
        public void TestRunStreamerWithInvalidPrinterAction()
        {
            _BmsDataStreamer.RunStreamer(null, _MockReader);

            Assert.Equal(0, _MockReader.Count);

            Assert.Equal(0, _MockCommandProcessor.ProcessFuncCallCount);

            Assert.Null(_MockCommandProcessor.Command);

            Assert.Equal(0, _FunctionCallCount);

            Assert.Equal(string.Empty, _DataPrinted);
        }

        [Fact]
        public void TestRunStreamerWithInvalidConsoleReader()
        {
            _BmsDataStreamer.RunStreamer(MockPrinterAction, null);

            Assert.Equal(0, _MockReader.Count);

            Assert.Equal(0, _MockCommandProcessor.ProcessFuncCallCount);

            Assert.Null(_MockCommandProcessor.Command);

            Assert.Equal(2, _FunctionCallCount);

            Assert.Equal("BMS Data Streamer\n\nPress Enter to exit....\nEnter command: ", _DataPrinted);
        }

        private void MockPrinterAction(string data)
        {
            _DataPrinted += data;

            _FunctionCallCount++;
        }
    }
}
