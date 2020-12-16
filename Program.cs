using System;
using System.IO;
using System.Linq;


var patternLines = File.ReadAllLines("input/day3");
var patternWidth = patternLines.First().Length;

var currentPosition = 0;

var total = patternLines.Skip(1).Aggregate(0, (sum, line) => {
    currentPosition = currentPosition + 3;
    var hit = line[currentPosition % patternWidth] == '#';
    return (hit ? 1 : 0) + sum;
});

Console.WriteLine(total);