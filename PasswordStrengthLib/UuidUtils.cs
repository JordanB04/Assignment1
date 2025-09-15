using System;

namespace PasswordStrengthLib
{
    /// <summary>
    /// Utilities for working with UUIDs.
    /// </summary>
    public static class UuidUtils
    {
        // <summary>
        /// Generates a Version 4 UUID (random) per RFC 4122.
        /// Uses <see cref="Guid.NewGuid"/> which sets the version nibble to '4'
        /// and the variant nibble to one of {8,9,A,B}.
        /// </summary>
        /// <returns>
        /// UUID string in canonical form: xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx
        /// where y ∈ {8,9,a,b}.
        /// </returns>
        public static string GenerateV4()
        {
            // Guid.NewGuid() produces a version 4 UUID in .NET
            return Guid.NewGuid().ToString();
        }
    }
}
