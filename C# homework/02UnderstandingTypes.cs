/*
using System;

namespace _02UnderstandingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sbyte: Bytes = {0}, Min = {1}, Max = {2}", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("byte: Bytes = {0}, Min = {1}, Max = {2}", sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("short: Bytes = {0}, Min = {1}, Max = {2}", sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("ushort: Bytes = {0}, Min = {1}, Max = {2}", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("int: Bytes = {0}, Min = {1}, Max = {2}", sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("uint: Bytes = {0}, Min = {1}, Max = {2}", sizeof(uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine("long: Bytes = {0}, Min = {1}, Max = {2}", sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("ulong: Bytes = {0}, Min = {1}, Max = {2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("float: Bytes = {0}, Min = {1}, Max = {2}", sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("double: Bytes = {0}, Min = {1}, Max = {2}", sizeof(double), double.MinValue, double.MaxValue);
            Console.WriteLine("decimal: Bytes = {0}, Min = {1}, Max = {2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue);

            Console.ReadLine();
        }
    }
}
*/

//Write program to enter an integer number of centuries and convert it to years, days, hours,minutes, seconds, milliseconds, microseconds, nanoseconds.
/*
using System;

namespace CenturyConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of centuries:");
            int centuries = int.Parse(Console.ReadLine());

            // Defining the values for conversions
            int years = centuries * 100;
            int days = (int)(years * 365.2425); // Average days per year accounting for leap years
            long hours = days * 24L;
            long minutes = hours * 60L;
            long seconds = minutes * 60L;
            long milliseconds = seconds * 1000L;
            long microseconds = milliseconds * 1000L;
            decimal nanoseconds = (decimal)microseconds * 1000M;

            // Outputting the result
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

            // Keeping the console open
            Console.ReadLine();
        }
    }
}*/