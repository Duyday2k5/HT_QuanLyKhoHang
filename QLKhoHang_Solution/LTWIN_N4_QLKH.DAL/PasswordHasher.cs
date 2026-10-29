using System;
using System.Globalization;
using System.Security.Cryptography;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Mã hóa mật khẩu bằng PBKDF2-SHA256; không lưu mật khẩu dạng rõ.
    /// Định dạng lưu: PBKDF2-SHA256$iterations$salt$hash.
    /// </summary>
    internal static class PasswordHasher
    {
        private const int Iterations = 210000;
        private const int SaltLength = 16;
        private const int HashLength = 32;
        private const int MaximumAcceptedIterations = 1000000;

        internal static string Hash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] salt = new byte[SaltLength];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            byte[] derived;
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                derived = pbkdf2.GetBytes(HashLength);
            }

            return "PBKDF2-SHA256$" + Iterations.ToString(CultureInfo.InvariantCulture) +
                   "$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(derived);
        }

        internal static bool Verify(string password, string storedHash)
        {
            if (password == null || string.IsNullOrWhiteSpace(storedHash))
            {
                return false;
            }

            string[] parts = storedHash.Split('$');
            int iterations;
            if (parts.Length != 4 || parts[0] != "PBKDF2-SHA256" ||
                !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out iterations) ||
                iterations < 10000 || iterations > MaximumAcceptedIterations)
            {
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expected = Convert.FromBase64String(parts[3]);
                if (salt.Length < SaltLength || expected.Length != HashLength)
                {
                    return false;
                }

                byte[] actual;
                using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
                    password, salt, iterations, HashAlgorithmName.SHA256))
                {
                    actual = pbkdf2.GetBytes(expected.Length);
                }

                return FixedTimeEquals(actual, expected);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            int difference = 0;
            for (int i = 0; i < left.Length; i++)
            {
                difference |= left[i] ^ right[i];
            }

            return difference == 0;
        }
    }
}
