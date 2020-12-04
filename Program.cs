using System;
using System.IO;
using System.Linq;

namespace aoc_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"input/day1");
            var numbers = lines
                .Select(line => Convert.ToInt32(line))
                .OrderBy(number => number);

            var match = numbers.First(number => numbers
                .Where(pairedNumber => pairedNumber <= 2020 - number)
                .Any(pairedNumber => number == 2020 - pairedNumber));

            var pairedNumber = 2020 - match;

            Console.WriteLine($"{match} og {pairedNumber}, produkt = {match * pairedNumber} ");

        }
    }
}
