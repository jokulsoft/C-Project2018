using System;
using TemperatureSensor;

namespace DLLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 0;
            TemperatureReader.SetTemperLimit(ref s);
            Console.WriteLine("{0}",s);
            Console.ReadLine();
        }
    }
}
