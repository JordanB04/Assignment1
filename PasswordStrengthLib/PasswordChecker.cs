using System.Text.RegularExpressions;

namespace PasswordStrengthLib
{
    
 /// <summary>
/// Classifies password strength by counting how many of four criteria are met:
/// 1) at least one uppercase A–Z, 2) at least one lowercase a–z,
/// 3) at least one digit 0–9, 4) at least one non-alphanumeric symbol.
/// Also enforces a minimum length of 8 characters; shorter strings are INELIGIBLE.
/// </summary>
/// <param name="password">The input password string to evaluate.</param>
/// <returns>
/// "INELIGIBLE" if null/empty or length &lt; 8;
/// "WEAK" if exactly 1 criterion is met;
/// "MEDIUM" if 2 or 3 criteria are met;
/// "STRONG" if all 4 criteria are met.
/// </returns>
    public class PasswordChecker
    {
        public static string CheckStrength(string password)
        {

            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return "INELIGIBLE";

            int criteriaMet = 0;

            if (Regex.IsMatch(password, "[A-Z]")) criteriaMet++;
            if (Regex.IsMatch(password, "[a-z]")) criteriaMet++;
            if (Regex.IsMatch(password, "[0-9]")) criteriaMet++;
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) criteriaMet++;

            if (criteriaMet == 0) return "INELIGIBLE";
            if (criteriaMet == 1) return "WEAK";
            if (criteriaMet == 2 || criteriaMet == 3) return "MEDIUM";
            if (criteriaMet == 4) return "STRONG";

            return "INELIGIBLE";
        }
    }
}
