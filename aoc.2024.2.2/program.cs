using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace aoc202422;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var numbers = new List<int>();

        var solution = new Solution();

        var result = 0;
        while(input is not null)
        {
            var numbersStr = input.Split(" ");
            numbers = numbersStr.Select(int.Parse).ToList();

            var isLineSafe = solution.IsLevelsSafe(numbers) || solution.IsLevelsSafeWithoutALevel(numbers);
            if(isLineSafe) result++;

            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}
