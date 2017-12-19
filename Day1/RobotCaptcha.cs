using Xunit;

namespace Day1
{
    public class RobotCaptcha
    {
        public int Sum(string input)
        {
            return 0;
        }
    }

    public class RobotCaptchaShould
    {
        [Fact]
        public void SumIdenticalDigitsWhichAreContiguous()
        {
            const string input = "1224";

            var captcha = new RobotCaptcha();

            var total = captcha.Sum(input);

            Assert.Equal(4, total);
        }
    }
}
