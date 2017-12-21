using System;
using Xunit;

namespace AdventOfCode.Solutions.Day1
{
    public class RobotCaptcha
    {
        public int SumContiguous(string input)
        {
            return Sum(input, currentPosition => currentPosition + 1 == input.Length ? 0 : currentPosition + 1);
        }

        public int SumOpposites(string input)
        {
            return Sum(input, currentPosition =>
            {
                var oppositePosition = currentPosition + input.Length / 2;

                return oppositePosition < input.Length ? oppositePosition : oppositePosition - input.Length;
            });
        }

        private static int Sum(string input, Func<int, int> targetPosition)
        {
            var total = 0;

            for (var position = 0; position < input.Length; position++)
            {
                var currentInteger = input[position].ToString();

                var targetInteger = input[targetPosition(position)].ToString();

                if (currentInteger == targetInteger) total += int.Parse(currentInteger);
            }

            return total;
        }
    }

    public class RobotCaptchaShould
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1234", 0)]
        [InlineData("1111", 4)]
        [InlineData("91212129", 9)]
        public void SumIdenticalDigitsWhichAreContiguous(string input, int expected)
        {
            var captcha = new RobotCaptcha();

            var total = captcha.SumContiguous(input);

            Assert.Equal(expected, total);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        public void SumIdenticalDigitsWhichAreOpposite(string input, int expected)
        {
            var captcha = new RobotCaptcha();

            var total = captcha.SumOpposites(input);

            Assert.Equal(expected, total);
        }
    }
}
