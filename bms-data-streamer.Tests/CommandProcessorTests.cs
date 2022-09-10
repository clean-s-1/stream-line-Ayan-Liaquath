namespace bms_data_streamer.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class CommandProcessorTests
    {
        private readonly ICommandProcessor _CommandProcessor;

        private string _PrinterData;

        private int _PrinterFunctionCall;

        public CommandProcessorTests()
        {
            _CommandProcessor = new CommandProcessor(
                new List<ISensor> { new MockSensor2() },
                new MockSender());

            _PrinterData = null;

            _PrinterFunctionCall = 0;
        }

        [Fact]
        public void TestProcessGivenCommandWithSenderCommand()
        {
            _CommandProcessor.ProcessGivenCommand(StreamerCommands.Commands[0], MockPrinter);

            Assert.Equal("MockSensor2: 2,5\n\n", _PrinterData);

            Assert.Equal(1, _PrinterFunctionCall);
        }

        [Fact]
        public void TestProcessGivenCommandWithInvalidCommand()
        {
            _CommandProcessor.ProcessGivenCommand(string.Empty, MockPrinter);

            Assert.Equal("Command is invalid\n\n", _PrinterData);

            Assert.Equal(1, _PrinterFunctionCall);
        }

        [Fact]
        public void TestProcessGivenCommandWithInvalidPrinterAction()
        {
            _CommandProcessor.ProcessGivenCommand(StreamerCommands.Commands[0], null);

            Assert.Null(_PrinterData);

            Assert.Equal(0, _PrinterFunctionCall);
        }

        private void MockPrinter(string dataToPrint)
        {
            _PrinterData = dataToPrint;

            _PrinterFunctionCall++;
        }
    }
}
