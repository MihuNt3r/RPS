using System;
using System.Security.Cryptography;
using System.Text;

namespace RPS
{
    public static class Random
    {
        public static string GetKey()
        {
            byte[] bytes = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetBytes(bytes);

            return Convert.ToHexString(bytes);
        }

        public static string GetRandomMove(string[] moves)
        {
            int rand = RandomNumberGenerator.GetInt32(moves.Length);

            return moves[rand]; // Get random move from an array of moves 
        }

        public static string GetHMAC(string move, string key)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(move));
            return Convert.ToHexString(hash);
        }
    }
}
