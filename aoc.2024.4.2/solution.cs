using System;

namespace aoc202442;

partial class Solution
{
    const string MAS = "MAS";
    const string SAM = "SAM";

    private ((int, int), (int, int), (int, int), (int, int), (int, int)) GetCrossIndexes(int x, int y) =>
         ((x - 1, y - 1), (x + 1, y - 1), (x, y), (x - 1, y + 1), (x + 1, y + 1));

    private bool IsMASorSAM(char[][] grid, (int x, int y) pos1, (int x, int y) pos2, (int x, int y) pos3)
    {
        char c1 = grid[pos1.y][pos1.x];
        char c2 = grid[pos2.y][pos2.x];
        char c3 = grid[pos3.y][pos3.x];

        string s = $"{c1}{c2}{c3}";

        return s.Equals(MAS)  || s.Equals(SAM);
    }

    internal int CountCrossMAS(char[][] grid)
    {
        int count = 0;

        for(int y = 1; y < grid.Length - 1; y++)
        {
            for(int x = 1; x < grid[y].Length - 1; x++)
            {
                var (leftUp, rightUp, center, leftDown, rightDown) = GetCrossIndexes(x, y);
                bool firstDiagonal = IsMASorSAM(grid, leftUp, center, rightDown);
                bool secondDiagonal = IsMASorSAM(grid, rightUp, center, leftDown);

                if(firstDiagonal && secondDiagonal) count++;
            }
        }

        return count;
    }
}
