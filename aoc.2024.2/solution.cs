using System;
using System.Collections.Generic;

namespace aoc20242;

class Solution
{
    private static bool IsIn1to3(int number) => Math.Abs(number) is >= 1 and <= 3;

    internal bool Calculate(List<int> numbers)
    {
        var initialDiff = numbers[1] - numbers[0];
        if(IsIn1to3(initialDiff) is false) return false;

        int initialSign = Math.Sign(initialDiff);

        for(int i = 2; i < numbers.Count; i++)
        {
            var diff = numbers[i] - numbers[i - 1];

            if(IsIn1to3(diff) is false) return false;
            if(Math.Sign(diff) != initialSign) return false;
        }

        return true;
    }
}
