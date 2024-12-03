using System;
using System.Collections.Generic;
using System.Threading;

namespace aoc20241;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var first = new List<int>();
        var second = new List<int>();

        while(input is not null)
        {
            int leftNumber, rightNumber;
            string[] numbersStr = input.Split("   ");
            leftNumber = int.Parse(numbersStr[0]);
            rightNumber = int.Parse(numbersStr[1]);

            first.Add(leftNumber);
            second.Add(rightNumber);

            input = Console.ReadLine();
        }

        var solution = new Solution();
        int result = solution.Calculate(first, second);

        Console.WriteLine(result);
    }
}