using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc20241;

class Solution
{
    internal int Calculate(IList<int> first, IList<int> second)
    {
        var ordered = second.OrderBy(num => num).ToList();
        return first.OrderBy(num => num).Select((num, i) => Math.Abs(num - ordered[i])).Sum();
    }
}
