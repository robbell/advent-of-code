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
            var lines = input.Split(Environment.NewLine);

            var parsedIntegers = lines
                .Select(line => line
                    .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

            var evenlyDivisible = parsedIntegers.Select(integerRow => FindEvenlyDivisible(integerRow.ToList()));

            return evenlyDivisible.Select(e => e.Item1 / e.Item2).Sum();
        }

        private (int, int) FindEvenlyDivisible(IList<int> orderedIntegers)
        {
            for (var divisorIndex = 0; divisorIndex < orderedIntegers.Count; divisorIndex++)
            {
                for (var dividendIndex = 0; dividendIndex < orderedIntegers.Count; dividendIndex++)
                {
                    if (dividendIndex == divisorIndex) continue;

                    if (orderedIntegers[divisorIndex] % orderedIntegers[dividendIndex] == 0)
                        return (orderedIntegers[divisorIndex], orderedIntegers[dividendIndex]);
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