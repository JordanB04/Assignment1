using System;
using System.Text.RegularExpressions;

namespace PasswordStrengthLib
{
    public class PasswordChecker
    {
        public static string CheckStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
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
            if (password.Length < 8) return "INELGIBLE";

            return "INELIGIBLE";
        }
    }
}
