using System;
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

                total += orderedIntegers.Last() - orderedIntegers.First();
            }

            return total;
        }
    }

    public class ChecksumShould
    {
        [Theory]
        [InlineData("1 2 3", 2)]
        [InlineData("9 6 2", 7)]
        [InlineData(@"9 6 2
                      1 4 4", 10)]
        public void CalculateTheDifferenceBetweenTheHighestAndLowestValues(string input, int expected)
        {
            var checksum = new Checksum();

            var result = checksum.Sum(input);

            result.ShouldBeEquivalentTo(expected);
        }
    }
}