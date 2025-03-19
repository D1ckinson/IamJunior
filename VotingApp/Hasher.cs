using System.Security.Cryptography;

namespace VotingApp
{
    public class Hasher : IHasher
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public Hasher(HashAlgorithm hashAlgorithm)
        {
            hashAlgorithm.ThrowIfNull();
            _hashAlgorithm = hashAlgorithm;
        }

        public string Hash(string data)
        {
            byte[] buffer = BitConverter.GetBytes(data.GetHashCode());
            byte[] hash = _hashAlgorithm.ComputeHash(buffer);

            return string.Concat(hash);
        }
    }
}
