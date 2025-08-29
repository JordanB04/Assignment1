using Xunit;
using PasswordStrengthLib;

namespace PasswordStrengthLib.Tests
{
    public class PasswordCheckerTests
    {
        // Updated: all "positive" samples are now length >= 8
        [Theory]
        [InlineData("", "INELIGIBLE")]            // empty -> ineligible
        [InlineData("abcdefgh", "WEAK")]          // only lowercase (8)
        [InlineData("ABCDEFGH", "WEAK")]          // only uppercase (8)
        [InlineData("12345678", "WEAK")]          // only numbers (8)
        [InlineData("!!!!@@@@", "WEAK")]          // only symbols (8)
        [InlineData("abc12345", "MEDIUM")]        // lowercase + number (8)
        [InlineData("Abcdef12", "MEDIUM")]        // upper + lower + number (8)
        [InlineData("Abc1234!", "STRONG")]        // upper + lower + number + symbol (8)
        public void CheckStrength_ReturnsExpected(string password, string expected)
        {
            var result = PasswordChecker.CheckStrength(password);
            Assert.Equal(expected, result);
        }

        // Explicit tests for the new min-length rule
        [Theory]
        [InlineData("Abc1$", "INELIGIBLE")]       // 5 chars but otherwise "strong"
        [InlineData("abc123", "INELIGIBLE")]      // 6 chars (used to be MEDIUM)
        [InlineData("Abc123!", "INELIGIBLE")]     // 7 chars (used to be STRONG)
        public void ShortPasswords_AreIneligible(string password, string expected)
        {
            var result = PasswordChecker.CheckStrength(password);
            Assert.Equal(expected, result);
        }
    }
}
