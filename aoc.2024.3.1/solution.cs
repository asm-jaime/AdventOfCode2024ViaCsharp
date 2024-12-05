using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc202431;

partial class Solution
{
    [GeneratedRegex(@"mul\(\d+,\d+\)")]
    private partial Regex AllMuls();

    [GeneratedRegex(@"mul\(|\)")]
    private partial Regex Mul();

    internal long GetSumOfAllMuls(string inputStr)
    {
        long result = 0;

        var matches = AllMuls().Matches(inputStr);
        foreach(Match match in matches)
        {
            var numbersString = Mul().Replace(match.Value, "");
            var numbersInts = numbersString.Split(",").Select(int.Parse);
            var (first, second) = (numbersInts.First(), numbersInts.Last());

            result = result + first * second;
        }

        return result;
    }

}
