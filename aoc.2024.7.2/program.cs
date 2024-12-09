using System;
using System.Linq;

namespace aoc202472;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        var line = Console.ReadLine();

        long result = 0;

        while(line is not null)
        {
            var sumAndNumbers = line.Split(":");
            var sum = long.Parse(sumAndNumbers.First());
            var numbers = sumAndNumbers.Last().Trim().Split(" ").Select(long.Parse).ToList();

            if(solution.IsSumPassable(sum, numbers))
            {
                result = result + sum;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}
