using System;
using System.IO;
using System.Linq;

var placementStrings = File.ReadAllLines("input/day5");
var placements = placementStrings.Select(placement => new Placement(placement[..7], placement[7..]));

var ordered = placements.OrderBy(placement => placement.SeatId);
var candidate = placements.First();
foreach (var item in ordered)
{
    if (item.SeatId == candidate.SeatId + 2) { 
        Console.WriteLine(item.SeatId - 1);
        break;
    }
    candidate = item;
}

record Placement(string depth, string width) {
    public int Row { get { 
        return depth.Aggregate((min: 0, max: 127), (range, letter) => (
            min: range.min + (letter == 'B' ? (range.max + 1 - range.min)/ 2 : 0), 
            max: range.max - (letter == 'F' ? (range.max + 1 - range.min)/ 2 : 0)
        )).min;
    } }

    public int Column { get { 
        return width.Aggregate((min: 0, max: 7), (range, letter) => (
            min: range.min + (letter == 'R' ? (range.max + 1 - range.min)/ 2 : 0), 
            max: range.max - (letter == 'L' ? (range.max + 1 - range.min)/ 2 : 0)
        )).min;
    } }

    public int SeatId { get { return Row * 8  + Column; }}

    public override string ToString()
    {
        return $"r: {Row} c: {Column} s: {SeatId}";
    }

}