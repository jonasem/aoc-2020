using System;
using System.IO;
using System.Linq;

var placementStrings = File.ReadAllLines("input/day5");
var placements = placementStrings.Select(placement => new Placement(placement[..7], placement[7..]));

Console.WriteLine(placements.Max(placement => placement.SeatId));

Console.WriteLine(new Placement("BFFFBBF", "RRR").ToString()); //: row 70, column 7, seat ID 567.
Console.WriteLine(new Placement("FFFBBBF", "RRR").ToString()); //: row 14, column 7, seat ID 119.
Console.WriteLine(new Placement("BBFFBBF", "RLL").ToString()); //: row 102, column 4, seat ID 820.

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