namespace bms_data_streamer
{
    using System;
    using System.Collections.Generic;

    public class BmsDataStreamer
    {
        private const string CommandPipe = "|";

        static void Main()
        {
            var commandProcessor = new CommandProcessor(
                new List<ISensor>
                {
                    new TemperatureSensor(),
                    new ChargeRateSensor()
                },
                new Sender());

            PrintOnConsole("BMS Data Streamer\n\n");

            while (true)
            {
                PrintOnConsole("Enter command: ");

                var command = Console.ReadLine();

                commandProcessor.ProcessGivenCommand(command, PrintOnConsole);
            }
        }

        private static void PrintOnConsole(string dataToPrint)
        {
            Console.Write(dataToPrint);
        }
    }
}
