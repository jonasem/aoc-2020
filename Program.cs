using System;
using System.IO;
using System.Linq;


var lines = File.ReadAllLines("input/day2");
var passwordLines = lines.Select(ParseLine);

Console.WriteLine("Day 2");
Console.WriteLine(passwordLines.Where(PassesPolicy2).Count());

static bool PassesPolicy(PasswordLine line) {
    var hits = line.password.Where(character => character == line.letter).Count();
    return line.min <= hits && line.max >= hits;
}

static bool PassesPolicy2(PasswordLine line) {
    return line.letter == line.password[line.min - 1] ^line.letter == line.password[line.max - 1];
}


static PasswordLine ParseLine(string line) {
    var parts = line.Split(" ");
    var limits = parts[0].Split("-").Select(part => Convert.ToInt32(part)).ToArray();
    return new PasswordLine(limits[0], limits[1], parts[1].First(), parts[2]);
}

record PasswordLine(int min, int max, char letter, string password);

