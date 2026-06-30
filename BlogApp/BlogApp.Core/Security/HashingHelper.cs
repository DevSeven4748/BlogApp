using System.Security.Cryptography;
using System.Text;

namespace BlogApp.Core.Security
{
    public static class HashingHelper
    {
        public static HashResult CreatePasswordHash(string password)
        {
            using HMACSHA512 hmac = new();

            byte[] passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return new HashResult { Hash = passwordHash, Salt = passwordSalt };


        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}

public class HashResult
    {
        public byte[] Hash { get; set; } = Array.Empty<byte>();
        public byte[] Salt { get; set; } = Array.Empty<byte>();

    }

