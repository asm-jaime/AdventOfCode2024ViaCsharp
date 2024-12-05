using System;
using System.Collections.Generic;

namespace aoc202441;

class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine();

        var numbers = new List<char[]>();

        var solution = new Solution();

        while(line is not null)
        {
            numbers.Add(line.ToCharArray());
            line = Console.ReadLine();
        }

        var result = solution.CountAllXMAS(numbers.ToArray());

        Console.WriteLine(result);
    }
}
