using Application.Configuration.ExtentionsExtractor;
using System.Security.Cryptography;
using System.Text;

namespace Application.Configuration.Helpers
{
    public class Encryptor
    {
        public static string Encrypt(string text)
        {
            using (Aes aesAlg = Aes.Create())
            {
                //Clé statique pour le chiffrement AES (16, 24 ou 32 bytes pour AES-128, AES-192, ou AES-256)
                aesAlg.Key = Encoding.UTF8.GetBytes(ApplicationConfigExtractor.GetAesKey());
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }

            }
        }

        //Décryptage des données
        public static string Decrypt(string cryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cryptedText);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ApplicationConfigExtractor.GetAesKey());
                byte[] iv = new byte[aesAlg.IV.Length];
                Array.Copy(cipherBytes, iv, iv.Length);
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes, iv.Length, cipherBytes.Length - iv.Length))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
