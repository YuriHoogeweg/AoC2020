using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _1
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
            var expenses = (await File.ReadAllLinesAsync(InputFilePath))
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            var expense = expenses.First(x => expenses.Any(y => x + y == 2020));

            return expense * (2020 - expense);
        }

        // Pretty rough implementation
        private async Task<int> Part2()
        {
            var expenses = (await File.ReadAllLinesAsync(InputFilePath))
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            for (var i = 0; i < expenses.Count; i++)
            {
                var expenseA = expenses[i];

                for (var j = 0; j < expenses.Count; j++)
                {
                    if (i == j)
                        continue;

                    var expenseB = expenses[j];

                    for (var k = 0; k < expenses.Count; k++)
                    {
                        if (k == j || k == i)
                            continue;

                        var expenseC = expenses[k];

                        if (expenseA + expenseB + expenseC == 2020)
                        {
                            return expenseA * expenseB * expenseC;
                        }
                    }
                }
            }

            throw new ArgumentException("Not found");
        }
    }
}
