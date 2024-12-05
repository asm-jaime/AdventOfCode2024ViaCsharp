using System;

namespace aoc202441;

partial class Solution
{
    enum Direction
    {
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }

    static readonly int[] dx = { +0, +1, +1, +1, +0, -1, -1, -1 };
    static readonly int[] dy = { -1, -1, +0, +1, +1, +1, +0, -1 };

    const string Word = "XMAS";

    private static bool IsXMASOnDirection(char[][] grid, int y, int x, Direction direction)
    {
        int dirIndex = (int)direction;

        for(int k = 0; k < Word.Length; k++)
        {
            int newY = y + k * dy[dirIndex];
            int newX = x + k * dx[dirIndex];

            if(newX < 0 || newX >= grid[0].Length || newY < 0 || newY >= grid.Length)
            {
                return false;
            }

            if(grid[newY][newX] != Word[k])
            {
                return false;
            }
        }

        return true;
    }

    internal int CountAllXMAS(char[][] grid)
    {
        int count = 0;

        for(int y = 0; y < grid.Length; y++)
        {
            for(int x = 0; x < grid[y].Length; x++)
            {
                foreach(Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    if(IsXMASOnDirection(grid, y, x, dir))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}
