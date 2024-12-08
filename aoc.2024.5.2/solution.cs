using System.Collections.Generic;
using System.Linq;

namespace aoc202451;

class Solution
{
    private bool IsMiddlePageFromCorrectOrderedSection(List<(int left, int right)> rules, List<int> section)
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
                    return false;
                }
            }
        }

        return true;
    }
    private List<int> TopologicalSortOrdering(List<(int left, int right)> rules, List<int> section)
    {
        var pages = new HashSet<int>(section);
        var filteredRules = rules.Where(r => pages.Contains(r.left) && pages.Contains(r.right)).ToList();

        var adjacency = new Dictionary<int, List<int>>();
        var inDegree = new Dictionary<int, int>();

        foreach(var p in pages)
        {
            adjacency[p] = new List<int>();
            inDegree[p] = 0;
        }

        foreach(var (left, right) in filteredRules)
        {
            adjacency[left].Add(right);
            inDegree[right]++;
        }

        var queue = new Queue<int>();
        foreach(var p in pages)
        {
            if(inDegree[p] == 0)
            {
                queue.Enqueue(p);
            }
        }

        var sorted = new List<int>();
        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            sorted.Add(current);

            foreach(var next in adjacency[current])
            {
                inDegree[next]--;
                if(inDegree[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }

        return sorted;
    }

    public long GetMiddlePageCorrectedOrderedSection(List<(int, int)> rules, List<int> section)
    {
        var isCorrect = IsMiddlePageFromCorrectOrderedSection(rules, section);

        if(isCorrect is false)
        {
            var correctedOrder = TopologicalSortOrdering(rules, section);
            return correctedOrder[correctedOrder.Count / 2];
        }

        return 0;
    }
}
