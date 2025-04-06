using System.Security.Cryptography;

namespace AliceProject.Helpers
{
    public class PasswordHandling
    {
        private readonly int _saltSize = 16;
        private readonly int _hashSize = 32;
        private readonly int _iterations = 100000;

        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);
            return $"{Convert.ToHexString(hash)}-Alice-{Convert.ToHexString(salt)}";
        }
        public bool Verify(string password, string passwordHash)
        {
            string[] parts = passwordHash.Split("-Alice-");
            var hash = Convert.FromHexString(parts[0]);
            var salt = Convert.FromHexString(parts[1]);
            var inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);
            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
