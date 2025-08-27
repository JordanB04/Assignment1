using Xunit;
using PasswordStrengthLib;

namespace PasswordStrengthLib.Tests
{
    public class PasswordCheckerTests
    {
        [Theory]
        [InlineData("", "INELIGIBLE")]
        [InlineData("abc", "WEAK")]
        [InlineData("ABC", "WEAK")]
        [InlineData("12345", "WEAK")]
        [InlineData("!!!!", "WEAK")]
        [InlineData("abc123", "MEDIUM")]
        [InlineData("Abc123", "MEDIUM")]
        [InlineData("Abc123!", "STRONG")]
        public void CheckStrength_ReturnsExpected(string password, string expected)
        {
            var result = PasswordChecker.CheckStrength(password);
            Assert.Equal(expected, result);
        }
    }
}
