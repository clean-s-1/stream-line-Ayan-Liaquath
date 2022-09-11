namespace bms_data_streamer
{
    using System;

    internal class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
