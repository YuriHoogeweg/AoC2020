using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        private const string InputFilePath = "Input.txt";

        static void Main(string[] args)
        {
            var part1Result = new Program().Part1().GetAwaiter().GetResult();
            var part2Result = new Program().Part2().GetAwaiter().GetResult();

            Console.WriteLine($"Part 1: {part1Result}");
            Console.WriteLine($"Part 2: {part2Result}");
        }

        private async Task<int> Part1()
        {
            return await TreesOnSlope(3, 1);
        }

        private async Task<int> Part2()
        {
            var slopes = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2)
            };

            return await slopes.Select(async slope => await TreesOnSlope(slope.Item1, slope.Item2)).Aggregate(async (x, y) => await x * await y);
        }

        private async Task<int> TreesOnSlope(int xStep, int yStep)
        {
            var lines = await File.ReadAllLinesAsync(InputFilePath);
            var lineLength = lines.Min(x => x.Length);

            var x = 0;
            var y = 0;
            var treeCount = 0;

            while (x < lineLength && y + 1 < lines.Length)
            {
                x += xStep;
                y += yStep;

                if (x >= lines[y].Length)
                    x -= lines[y].Length;

                if (lines[y][x] == '#')
                    treeCount++;
            }

            return treeCount;
        }
    }
}
