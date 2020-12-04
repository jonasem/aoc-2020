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
            var numbers = lines.Select(line => Convert.ToInt32(line)).OrderBy(number => number);

            var match = numbers.First(number => HasMatch(numbers, 2020 - number));
            var secondMatch = FindMatch(numbers, 2020 - match);
            var thirdMatch = 2020 - match - secondMatch;

            Console.WriteLine($"{match} og {secondMatch} og {thirdMatch}, produkt = {match * secondMatch * thirdMatch} ");
        }


        static bool HasMatch(IOrderedEnumerable<int> numbers, int target) {
            return numbers.Any(number => numbers
                .Any(pairedNumber => number + pairedNumber == target));
        }

        static int FindMatch(IOrderedEnumerable<int> numbers, int target) {
            return numbers.FirstOrDefault(number => numbers
                .Any(pairedNumber => number + pairedNumber == target));
        }

    }
}
