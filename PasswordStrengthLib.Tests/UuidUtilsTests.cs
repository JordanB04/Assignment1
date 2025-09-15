using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace PasswordStrengthLib.Tests
{
    public class UuidUtilsTests
    {
        private static readonly Regex V4Pattern =
            new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-4[0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$",
                      RegexOptions.Compiled);

        [Fact]
        public void GenerateV4_MatchesV4Format()
        {
            var id = UuidUtils.GenerateV4();
            Assert.True(V4Pattern.IsMatch(id), $"UUID not v4 format: {id}");

            // Check version nibble explicitly (char at index 14 is '4')
            Assert.Equal('4', char.ToLowerInvariant(id[14]));

            // Check variant nibble explicitly (char at index 19 ∈ {8,9,a,b})
            char variant = char.ToLowerInvariant(id[19]);
            Assert.Contains(variant.ToString(), new[] { "8", "9", "a", "b" });
        }

        [Fact]
        public void GenerateV4_ProducesDifferentValues()
        {
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < 100; i++)
            {
                var id = UuidUtils.GenerateV4();
                Assert.True(seen.Add(id), $"Duplicate UUID generated: {id}");
                Assert.True(V4Pattern.IsMatch(id), $"Bad UUID format: {id}");
            }
        }
    }
}
