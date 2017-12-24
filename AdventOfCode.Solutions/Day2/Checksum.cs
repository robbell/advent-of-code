using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Solutions.Day2
{
    public class Checksum
    {
        public int Sum(string input)
        {
            var total = 0;
            var lines = input.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var orderedIntegers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .OrderBy(i => i);

                var evenlyDivisible = FindEvenlyDivisible(orderedIntegers.ToList());

                total += evenlyDivisible.Item1 / evenlyDivisible.Item2;
            }

            return total;
        }

        private (int, int) FindEvenlyDivisible(IList<int> orderedIntegers)
        {
            for (var divisorIndex = 0; divisorIndex < orderedIntegers.Count(); divisorIndex++)
            {
                for (var dividentIndex = 0; dividentIndex < orderedIntegers.Count(); dividentIndex++)
                {
                    if (dividentIndex == divisorIndex) continue;

                    if (orderedIntegers[divisorIndex] % orderedIntegers[dividentIndex] == 0)
                        return (orderedIntegers[divisorIndex], orderedIntegers[dividentIndex]);
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
        public void CalculateTheDifferenceBetweenTheHighestAndLowestValues(string input, int expected)
        {
            var checksum = new Checksum();

            var result = checksum.Sum(input);

            result.ShouldBeEquivalentTo(expected);
        }
    }
}