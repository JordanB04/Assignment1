using System.Text.RegularExpressions;

namespace PasswordStrengthLib
{
    public class PasswordChecker
    {
        public static string CheckStrength(string password)
        {
            // ⬇️ Add this guard FIRST
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
