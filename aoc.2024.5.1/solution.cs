using System;
using System.Collections.Generic;

namespace aoc202451;

class Solution
{
    internal long GetMiddlePageFromCorrectOrderedSection(List<(int left, int right)> rules, List<int> section)
    {
        var pageIndex = new Dictionary<int, int>();
        for(int i = 0; i < section.Count; i++)
        {
            pageIndex[section[i]] = i;
        }

        foreach(var (left, right) in rules)
        {
            if(pageIndex.ContainsKey(left) && pageIndex.ContainsKey(right))
            {
                if(pageIndex[left] >= pageIndex[right])
                {
                    return 0;
                }
            }
        }

        int middleIndex = section.Count / 2;
        return section[middleIndex];
    }
}
