namespace bms_data_streamer
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class CommandProcessor : ICommandProcessor
    {
        private readonly IDictionary<string, Action<Action<string>>> _CommandsActionsMap;

        private readonly IList<ISensor> _Sensors;

        private readonly ISender _Sender;

        public CommandProcessor(IList<ISensor> sensors, ISender sender)
        {
            _Sensors = sensors;

            _Sender = sender;

            _CommandsActionsMap = new ConcurrentDictionary<string, Action<Action<string>>>();

            _CommandsActionsMap.Add(StreamerCommands.Commands[0], ExecuteSenderCommand);
        }

        public void ProcessGivenCommand(string command, Action<string> printerAction)
        {
            if (StreamerCommands.Commands.Contains(command))
            {
                ExecuteCommand(command, printerAction);

                return;
            }

            printerAction?.Invoke("Command is invalid\n\n");
        }

        private void ExecuteCommand(string command, Action<string> printerAction)
        {
            _CommandsActionsMap[command]?.Invoke(printerAction);
        }

        private void ExecuteSenderCommand(Action<string> printerAction)
        {
            printerAction?.Invoke(_Sender.FormatSenderOutput(_Sender.FetchReadingsFromSensors(_Sensors)));
        }
    }
}
