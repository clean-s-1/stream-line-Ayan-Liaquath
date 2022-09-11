namespace bms_data_streamer
{
    using System;

    public class BmsDataStreamer : IBmsDataStreamer
    {
        private readonly ICommandProcessor _CommandProcessor;

        public BmsDataStreamer(
            ICommandProcessor commandProcessor)
        {
            _CommandProcessor = commandProcessor;
        }

        public void RunStreamer(Action<string> printerAction, IConsoleReader consoleReader)
        {
            if (printerAction == null)
            {
                return;
            }

            printerAction.Invoke("BMS Data Streamer\n\n");

            RunCommandLoop(printerAction, consoleReader);
        }

        private void RunCommandLoop(Action<string> printerAction, IConsoleReader consoleReader)
        {
            while (true)
            {
                printerAction.Invoke("Press Enter to exit....\nEnter command: ");

                if (GetCommand(consoleReader, out var command))
                {
                    break;
                }

                _CommandProcessor.ProcessGivenCommand(command, printerAction);
            }
        }

        private bool GetCommand(IConsoleReader consoleReader, out string command)
        {
            command = consoleReader?.GetInput();

            if (string.IsNullOrEmpty(command))
            {
                return true;
            }

            return false;
        }
    }
}
