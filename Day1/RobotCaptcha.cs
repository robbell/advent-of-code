using Xunit;

namespace Day1
{
    public class RobotCaptcha
    {
        public int SumContiguous(string input)
        {
            var total = 0;

            for (var position = 0; position < input.Length; position++)
            {
                var currentInteger = input[position].ToString();

                var nextInteger = input[position + 1 == input.Length ? 0 : position + 1].ToString();

                if (currentInteger == nextInteger) total += int.Parse(currentInteger);
            }

            return total;
        }

        public int SumOpposites(string input)
        {
            var total = 0;

            for (var position = 0; position < input.Length; position++)
            {
                var currentInteger = input[position].ToString();

                var proposedPosition = position + input.Length / 2;

                var targetInteger = input[proposedPosition < input.Length ? proposedPosition : proposedPosition - input.Length].ToString();

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
