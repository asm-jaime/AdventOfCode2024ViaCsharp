using System.Collections.Generic;

namespace aoc202471;

class Solution
{
    bool CanCombineSum(long sum, long currentSum, List<long> numbers, int currentIndex)
    {
        if(currentIndex == numbers.Count && currentSum == sum)
        {
            return true;
        }
        if(currentIndex >= numbers.Count)
        {
            return false;
        }
        if(currentSum > sum)
        {
            return false;
        }

        var isNextPlus = CanCombineSum(sum, currentSum + numbers[currentIndex], numbers, currentIndex + 1);
        var isNextMultiple = CanCombineSum(sum, currentSum * numbers[currentIndex], numbers, currentIndex + 1);

        return isNextPlus || isNextMultiple;
    }

    public bool IsSumPassable(long sum, List<long> numbers)
    {
        return CanCombineSum(sum, 0, numbers, 0);
    }
}
