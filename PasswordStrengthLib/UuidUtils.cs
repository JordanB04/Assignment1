using System;

namespace PasswordStrengthLib
{
    /// <summary>
    /// Utilities for working with UUIDs.
    /// </summary>
    public static class UuidUtils
    {
        /// <summary>
        /// Generates a Version 4 UUID (random) per RFC 4122.
        /// </summary>
        /// <returns>A string like xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx where y ∈ {8,9,a,b}.</returns>
        public static string GenerateV4()
        {
            // Guid.NewGuid() produces a version 4 UUID in .NET
            return Guid.NewGuid().ToString();
        }
    }
}
