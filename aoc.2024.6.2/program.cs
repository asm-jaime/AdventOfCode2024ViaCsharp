using System;
using System.Collections.Generic;

namespace aoc202462;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        var map = new List<char[]>();
        var line = Console.ReadLine();

        while(line is not null)
        {
            var chars = line.ToCharArray();
            map.Add(chars);

            line = Console.ReadLine();
        }

        var result = solution.CountLoopObstructionPositions(map.ToArray());

        Console.WriteLine(result);
    }
}
