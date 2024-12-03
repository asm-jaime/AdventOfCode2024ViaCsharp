using System.Collections.Generic;
using System.Linq;

namespace aoc202412;

class Solution
{
    internal int Calculate(IList<int> first, IList<int> second)
    {
        var sumByNumber = second.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Sum());

        return first.Select(num =>
        {
            sumByNumber.TryGetValue(num, out int value);
            return value;
        }).Sum();
    }
}
