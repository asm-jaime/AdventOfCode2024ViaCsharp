using System.Linq;
using System.Text.RegularExpressions;

namespace aoc202432;

partial class Solution
{
    [GeneratedRegex(@"do\(\)|don't\(\)|mul\(\d+,\d+\)")]
    private partial Regex AllTerms();

    [GeneratedRegex(@"mul\(|\)")]
    private partial Regex Mul();

    private static bool MulEnabled = true;

    internal long GetSumOfAllMuls(string inputStr)
    {
        long result = 0;

        var matches = AllTerms().Matches(inputStr);
        foreach(Match match in matches)
        {
            var value = match.Value;
            if(value.Contains("don't()"))
            {
                MulEnabled = false;
            }
            else if(value.Contains("do()"))
            {
                MulEnabled = true;
            }
            else if(MulEnabled)
            {
                var numbersString = Mul().Replace(match.Value, "");
                var numbersInts = numbersString.Split(",").Select(int.Parse);
                var (first, second) = (numbersInts.First(), numbersInts.Last());
                result = result + first * second;
            }
        }

        return result;
    }

}
