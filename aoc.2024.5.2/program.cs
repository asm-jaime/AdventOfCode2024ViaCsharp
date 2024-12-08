using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc202451;

class Program
{
    static void Main(string[] args)
    {
        long result = 0;
        var solution = new Solution();

        var rules = new List<(int, int)>();
        var line = Console.ReadLine();
        while(line is not "")
        {
            var numsString = line.Split('|');
            rules.Add((int.Parse(numsString.First()), int.Parse(numsString.Last())));
            line = Console.ReadLine();
        }

        line = Console.ReadLine();
        while(line is not null)
        {
            var section = line.Split(",").Select(int.Parse).ToList();
            result = result + solution.GetMiddlePageCorrectedOrderedSection(rules, section);
            line = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}
