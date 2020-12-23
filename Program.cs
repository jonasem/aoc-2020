using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var answerLines = File.ReadAllLines("input/day6");

var groupAnswers = answerLines.Aggregate(new string[] { "" }, (answers, line) => {
    if(line.Length == 0) { answers = answers.Append("").ToArray(); }
    answers[answers.Length - 1] = answers[answers.Length - 1] + " " + line;
    return answers;
});


// part 1
var sum = groupAnswers.Select(answers => answers.Replace(" ", "").Distinct().Count())
    .Sum();

Console.WriteLine(sum);


// part 2
var intersectionSum = groupAnswers.Select(answers => answers
    .Trim()
    .Split(" ")
    .Select(answer => answer.ToCharArray())
    .Aggregate("abcdefghijklmnopqrstuvwxyz".ToCharArray(), (overlap, answer) => answer.Intersect(overlap).ToArray()))
    .Select(answer => answer.Length)
    .Sum();

Console.WriteLine(intersectionSum);
