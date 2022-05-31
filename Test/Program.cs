using System;
using System.Numerics;
using HexOperations;

namespace Test 
{
    internal class Program 
    {
        static void Main()
        {
            Conventor tool = new();

            BigInteger bigEndianValue;
            BigInteger littleEndianValue;
            Console.Write($" Type your HEX value -> ");
            string hexValue = Console.ReadLine();

            bigEndianValue = tool.HexToBigEndian(hexValue);
            Console.WriteLine($"bigEndianValue {bigEndianValue} ");
            littleEndianValue = tool.HexToLittleEndian(hexValue);
            Console.WriteLine($"littleEndianValue {littleEndianValue} ");
            string compare = tool.BigEndianToHex(bigEndianValue);
            Console.WriteLine($"compare {compare} ");
            string compare1 = tool.LittleEndianToHex(littleEndianValue, int.Parse(Console.ReadLine())); //Потрібно ввести бітову довжину значення
            Console.WriteLine($"compare1 {compare1} ");

            if (compare == hexValue)
            {
                Console.WriteLine($"The line 'compare' equals the line 'hexValue' ");
            }
            else 
            {
                Console.WriteLine($" Something went wrong... ");
            }

            if (compare1 == hexValue)
            {
                Console.WriteLine($"The line 'compare1' equals the line 'hexValue' ");
            }
            else
            {
                Console.WriteLine($" Something went wrong... ");
            }
        }
    }
}