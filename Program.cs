using System;
using System.IO;
using System.Linq;


var patternLines = File.ReadAllLines("input/day3");

var slopes = new [] {(1, 1), (1, 3), (1, 5), (1, 7), (2, 1)};
var total = slopes.Aggregate(1L, (product, slope) => product * slopeHits(patternLines, slope.Item1, slope.Item2));

Console.WriteLine(total);

static int slopeHits(string[] patternLines, int verticalIncrement, int horizontalIncrement) {
    var horizontalPosition = 0;
    var patternWidth = patternLines.First().Length;

    return patternLines
        .Skip(verticalIncrement)
        .Where((_, index) => index % verticalIncrement == 0)
        .Aggregate(0, (sum, line) => {
            horizontalPosition += horizontalIncrement;
            var hit = line[horizontalPosition % patternWidth] == '#';
            return (hit ? 1 : 0) + sum;
        });
}
