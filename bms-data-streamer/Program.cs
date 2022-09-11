namespace bms_data_streamer
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var streamer = new BmsDataStreamer(new CommandProcessor(new List<ISensor> { new ChargeRateSensor(), new TemperatureSensor() }, new Sender()));
            streamer.RunStreamer(PrintOnConsole, new ConsoleReader());
        }

        private static void PrintOnConsole(string dataToPrint)
        {
            Console.Write(dataToPrint);
        }
    }
}
