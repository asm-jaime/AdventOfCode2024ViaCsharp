using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc202422;

class Solution
{
    private static bool IsIn1to3(int number) => Math.Abs(number) is >= 1 and <= 3;

    internal bool IsLevelsSafe(List<int> levels)
    {
        var initialDiff = levels[1] - levels[0];
        if(IsIn1to3(initialDiff) is false) return false;

        int initialSign = Math.Sign(initialDiff);

        for(int i = 2; i < levels.Count; i++)
        {
            var diff = levels[i] - levels[i - 1];

            if(IsIn1to3(diff) is false) return false;
            if(Math.Sign(diff) != initialSign) return false;
        }

        return true;
    }

    internal bool IsLevelsSafeWithoutALevel(List<int> levels)
    {
        for(int i = 0; i < levels.Count; i++)
        {
            var levelsWithoutCurrent = levels.Where((level, levelId) => levelId != i).ToList();
            var isLevelsSafe = IsLevelsSafe(levelsWithoutCurrent);
            if(isLevelsSafe) return true;
        }

        return false;
    }
}
