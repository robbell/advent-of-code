using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Solutions.Day2
{
    public class Checksum
    {
        public int Calculate(string input)
        {
            var rows = input.Split(Environment.NewLine);

            var parsedRows = rows
                .Select(row => row
                    .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

            var evenlyDivisible = parsedRows.Select(row => FindEvenlyDivisible(row.ToList()));

            return evenlyDivisible.Select(e => e.dividend / e.divisor).Sum();
        }

        private (int dividend, int divisor) FindEvenlyDivisible(IList<int> orderedIntegers)
        {
            for (var dividendIndex = 0; dividendIndex < orderedIntegers.Count; dividendIndex++)
            {
                for (var divisorIndex = 0; divisorIndex < orderedIntegers.Count; divisorIndex++)
                {
                    if (divisorIndex == dividendIndex) continue;

                    if (orderedIntegers[dividendIndex] % orderedIntegers[divisorIndex] == 0)
                        return (orderedIntegers[dividendIndex], orderedIntegers[divisorIndex]);
                }
            }

            return (0, 0);
        }
    }

    public class ChecksumShould
    {
        [Theory]
        [InlineData("5 9 2 8", 4)]
        [InlineData("9 4 7 3", 3)]
        [InlineData(@"3 8 6 5", 2)]
        [InlineData(@"3 8 6 5
                      3 8 6 5", 4)]
        public void CalculateTheDifferenceBetweenTheHighestAndLowestValues(string input, int expected)
        {
            var checksum = new Checksum();

            var result = checksum.Calculate(input);

            result.ShouldBeEquivalentTo(expected);
        }
    }
}