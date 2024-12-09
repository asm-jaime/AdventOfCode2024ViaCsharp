using System.Collections.Generic;
using System.Linq;

namespace aoc202462;

class Solution
{
    private readonly (int dy, int dx)[] DirectionMoves =
    {
            (-1, 0), // up
            (0,  1), // right
            (1,  0), // down
            (0, -1), // left
        };

    private const int StartDirection = 0;

    private int GetNextDirection(int dir) => (dir + 1) % DirectionMoves.Length;

    
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

    public int CountLoopObstructionPositions(char[][] map)
    {
        var (startY, startX) = GetStartPosition(map);

        int rows = map.Length;
        int cols = map[0].Length;

        int loopCount = 0;

        for(int y = 0; y < rows; y++)
        {
            for(int x = 0; x < cols; x++)
            {
                if(y == startY && x == startX) continue;
                if(map[y][x] != '.') continue;

                map[y][x] = '#';
                if(SimulateForLoop(map, startY, startX, StartDirection)) loopCount++;
                map[y][x] = '.';

            }
        }

        return loopCount;
    }

    private bool SimulateForLoop(char[][] map, int startY, int startX, int direction)
    {
        int currentY = startY;
        int currentX = startX;
        int currentDirection = direction;

        var visitedStates = new HashSet<(int y, int x, int d)>();

        while(true)
        {
            var state = (currentY, currentX, currentDirection);

            if(visitedStates.Add(state) is false) return true;

            (int dy, int dx) = DirectionMoves[currentDirection];
            int nextY = currentY + dy;
            int nextX = currentX + dx;

            if(nextY < 0 || nextY >= map.Length || nextX < 0 || nextX >= map.First().Length) return false;

            if(map[nextY][nextX] == '#')
            {
                currentDirection = GetNextDirection(currentDirection);
                continue;
            }

            currentY = nextY;
            currentX = nextX;
        }
    }
}
