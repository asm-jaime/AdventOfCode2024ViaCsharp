using System.Collections.Generic;

namespace aoc202472;

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
        if(isNextPlus) return true;

        var isNextMultiple = CanCombineSum(sum, currentSum * numbers[currentIndex], numbers, currentIndex + 1);
        if(isNextMultiple) return true;

        var isNextConcat = CanCombineSum(sum, long.Parse($"{currentSum}{numbers[currentIndex]}"), numbers, currentIndex + 1);
        if(isNextConcat) return true;

        return false;
    }

    public bool IsSumPassable(long sum, List<long> numbers)
    {
        return CanCombineSum(sum, 0, numbers, 0);
    }
}
