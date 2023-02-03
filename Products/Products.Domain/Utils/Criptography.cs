using System.Security.Cryptography;
using System.Text;

namespace Products.Domain.Utils
{
    public static class Criptography
    {
        private static byte[] bIV =
        {
        0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC
        };

        private const string cryptoKey =
        "SinEPRSY4isklOMMTKi4ym3m2ZtOcNQSNaN4KBVd61Q=";
        public static byte[] Encrypt(string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                byte[] bKey = Convert.FromBase64String(cryptoKey);
                byte[] bText = new UTF8Encoding().GetBytes(text);

                Rijndael rijndael = new RijndaelManaged();

                rijndael.KeySize = 256;

                MemoryStream mStream = new MemoryStream();

                CryptoStream encryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateEncryptor(bKey, bIV),
                    CryptoStreamMode.Write);

                encryptor.Write(bText, 0, bText.Length);

                encryptor.FlushFinalBlock();

                return mStream.ToArray();
            }
            else
            {
                return null;
            }
        }
    }

}
