using Census.Contracts.Validation.Attributes;
using Shouldly;
using Xunit;

namespace Census.Tests
{
    public class AccessCodeTests
    {
        [Fact]
        public void WhenGeneratingANumericAccessCode_ThatCodeShouldVerifySuccessfully()
        {
            var calculator = new AccessTokenCalculator();
            var code = calculator.GenerateULongAccessToken();
            calculator.IsValid(code).ShouldBeTrue();
        }

        [Fact]
        public void WhenGeneratingANumericAccessCode_AndMessingWithTheChecksum_ThatCodeShouldNotVerifySuccessfully()
        {
            var calculator = new AccessTokenCalculator();
            var code = calculator.GenerateULongAccessToken();
            code++;
            calculator.IsValid(code).ShouldBeFalse();
        }

        [Fact]
        public void WhenGeneratingAnAccessCode_ThatCodeShouldVerifySuccessfully()
        {
            var calculator = new AccessTokenCalculator();
            var code = calculator.GenerateAccessToken();
            calculator.IsValid(code).ShouldBeTrue();
        }
    }
}