using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace aoc202431;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var numbers = new List<int>();

        var solution = new Solution();

        long result = 0;
        while(input is not null)
        {
            result += solution.GetSumOfAllMuls(input);
            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}
