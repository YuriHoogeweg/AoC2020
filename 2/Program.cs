using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _2.PasswordPolicies;

namespace _2
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
            var lines = await File.ReadAllLinesAsync(InputFilePath);

            return lines.ToList().Count(line =>
            {
                var passwordPolicy = new OldPasswordPolicy(line);
                var password = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1);

                var numRepetitions = password.Count(x => x == passwordPolicy.Character);
                return numRepetitions >= passwordPolicy.RepetitionsMin
                       && numRepetitions <= passwordPolicy.RepetitionsMax;
            });
        }

        private async Task<int> Part2()
        {
            var lines = await File.ReadAllLinesAsync(InputFilePath);

            return lines.ToList().Count(line =>
            {
                var passwordPolicy = new CurrentPasswordPolicy(line);
                var password = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1);

                return (password[passwordPolicy.Index1] == passwordPolicy.Character) != 
                       (password[passwordPolicy.Index2] == passwordPolicy.Character);
            });
        }
    }
}
