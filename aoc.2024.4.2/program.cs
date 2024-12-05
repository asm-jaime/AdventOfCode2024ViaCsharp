using System;
using System.Collections.Generic;

namespace aoc202432;

class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine();
        var numbers = new List<int>();

        var solution = new Solution();

        long result = 0;
        while(line is not null)
        {
            result += solution.GetSumOfAllMuls(line);
            line = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}
