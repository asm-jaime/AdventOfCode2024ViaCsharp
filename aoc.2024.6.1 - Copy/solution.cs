using System.Collections.Generic;

namespace aoc202461;

class Solution
{
    private readonly (int dy, int dx)[] DirectionMoves =
    {
            (-1, 0), // up
            (0,  1), // right
            (1,  0), // down
            (0, -1), // left
        };

    private int CurrentDirection = 0; // 0=up, 1=right, 2=down, 3=left

    private int GetNextDirection => (CurrentDirection + 1) % DirectionMoves.Length;

    private readonly HashSet<(int, int)> Visited = [];

    private (int y, int x) GetStartPosition(char[][] map)
    {
        for(int y = 0; y < map.Length; y++)
        {
            for(int x = 0; x < map[y].Length; x++)
            {
                if(map[y][x] is '^') return (y, x);
            }
        }

        return (-1, -1);

    }

    internal int GeDistinctPositonsBeforeLeaving(char[][] map)
    {

        var (startY, startX) = GetStartPosition(map);

        Visited.Add((startY, startX));

        int currentY = startY;
        int currentX = startX;

        while(true)
        {
            (int dy, int dx) = DirectionMoves[CurrentDirection];
            int nextY = currentY + dy;
            int nextX = currentX + dx;

            if(nextY < 0 || nextY >= map.Length || nextX < 0 || nextX >= map[nextY].Length)
            {
                break;
            }

            if(map[nextY][nextX] == '#')
            {
                CurrentDirection = GetNextDirection;
                continue;
            }

            currentY = nextY;
            currentX = nextX;
            Visited.Add((currentY, currentX));
        }

        return Visited.Count;
    }
}
