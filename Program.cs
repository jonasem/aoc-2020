using System;
using System.IO;
using System.Linq;

var passportLines = File.ReadAllLines("input/day4");

var passports = passportLines.Aggregate(new string[] { "" }, (passports, line) => {
    
    if(line.Length == 0) { passports = passports.Append("").ToArray(); }
    passports[passports.Length - 1] = passports[passports.Length - 1] + " " + line;
    return passports;
});

var requiredFields = new [] {
    "byr",
    "iyr",
    "eyr",
    "hgt",
    "hcl",
    "ecl",
    "pid",
    //  "cid",
};

var total = passports.Aggregate(0, (sum, passport) => {
    var parts = passport.Split(' ');
    var meetsRequirements = requiredFields.All(field => parts.Any(part => part.StartsWith(field)));
    return sum + (meetsRequirements ? 1 : 0);
});

Console.WriteLine(total);

