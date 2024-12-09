using System;
using System.Collections.Generic;

namespace aoc202482;

public class Solution
{
    private Dictionary<char, List<(int y, int x)>> GetNodes(char[][] map)
    {
        Dictionary<char, List<(int y, int x)>> nodes = [];

        for(int y = 0; y < map.Length; y++)
        {
            for(int x = 0; x < map[y].Length; x++)
            {
                char ch = map[y][x];
                if(ch != '.')
                {
                    if(nodes.ContainsKey(ch) is false)
                    {
                        nodes[ch] = [];
                    }
                    nodes[ch].Add((y, x));
                }
            }
        }

        return nodes;
    }
    private double Distance((int y, int x) p1, (int y, int x) p2)
    {
        double dy = p1.y - p2.y;
        double dx = p1.x - p2.x;
        return Math.Sqrt(dy * dy + dx * dx);
    }

    public int CalculateUniqueLocations(char[][] map)
    {
        var nodes = GetNodes(map);

        HashSet<(int y, int x)> result = [];


        for(int y = 0; y < map.Length; y++)
        {
            for(int x = 0; x < map[y].Length; x++)
            {
                bool foundAntinodeHere = false;
                foreach(var keyValueNode in nodes)
                {
                    var kvn = keyValueNode.Value;
                    for(int idNode1 = 0; idNode1 < kvn.Count; idNode1++)
                    {
                        var v1 = kvn[idNode1];
                        for(int idNode2 = idNode1 + 1; idNode2 < kvn.Count; idNode2++)
                        {
                            var v2 = kvn[idNode2];

                            (int y, int x) dv = (v2.y - v1.y, v2.x - v1.x);
                            (int y, int x) dc = (y - v1.y, x - v1.x);
                            (int y, int x) dcPerpendicular = (-dc.x, dc.y);

                            int dot = dcPerpendicular.y * dv.y + dcPerpendicular.x * dv.x;
                            if(dot == 0)
                            {
                                result.Add((y, x));

                                double d1 = Distance((y, x), v1);
                                double d2 = Distance((y, x), v2);

                                if(Math.Abs(d1 - 2 * d2) < 0.001 || Math.Abs(d2 - 2 * d1) < 0.001)
                                {
                                    foundAntinodeHere = true;
                                    break;
                                }
                            }
                        }
                        if(foundAntinodeHere) break;
                    }
                    if(foundAntinodeHere) break;
                }
            }
        }

        return result.Count;
    }
}

