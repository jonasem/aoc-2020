using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var passportLines = File.ReadAllLines("input/day4");

var passports = passportLines.Aggregate(new string[] { "" }, (passports, line) => {
    if(line.Length == 0) { passports = passports.Append("").ToArray(); }
    passports[passports.Length - 1] = passports[passports.Length - 1] + " " + line;
    return passports;
});

(int x, Func<string, bool> y) = (1, (string d) => false);

var requiredFields = new (string policy, Func<string, bool> validate)[] {
    ("byr", password => isNumberBetween(password, 1920, 2002)),
    ("iyr", password => isNumberBetween(password, 2010, 2020)),
    ("eyr", password => isNumberBetween(password, 2020, 2030)),
    ("hgt", password => isHeightBetween(password)),
    ("hcl", password => matchesRegex(password, @"^#[a-f0-9]{6}$")),
    ("ecl", password => (new string[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}).Any(a => a == password)),
    ("pid", password => matchesRegex(password, @"^\d{9}$")),
    //  "cid",
};


var total = passports.Aggregate(0, (sum, passport) => {
    var parts = passport.Split(' ');
    var meetsRequirements = requiredFields.All(field => parts.Any(part => part.StartsWith(field.policy) && field.validate(part.Substring(4))));
    return sum + (meetsRequirements ? 1 : 0);
});

Console.WriteLine(total);

bool isNumberBetween(string number, int min, int max) {
    if(int.TryParse(number, out var num)) {
        return number.Length == 4 && num >= min && num <= max;
    }
    return false;
}

bool isHeightBetween(string number) {
    var type = number[^2..];
    
    if(int.TryParse(number[..^2], out var num)) {
        if (type == "cm") 
            return num >= 150 && num <= 193;
        return num >= 59 && num <= 76;
    }
    return false;
}

bool matchesRegex(string text, string pattern) {
    var rx = new Regex(pattern);
    return rx.IsMatch(text);
}