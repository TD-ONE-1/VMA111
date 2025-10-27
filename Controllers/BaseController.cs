using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string EncryptString(string plainText, string key)
        {
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16];
            Array.Copy(keyBytes, iv, iv.Length);

            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;
                aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] encryptedBytes = memoryStream.ToArray();
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
        }
        protected string DecryptString(string encryptedText, string key)
        {
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16];
            Array.Copy(keyBytes, iv, iv.Length);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;
                aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] decryptedBytes = memoryStream.ToArray();
                        return System.Text.Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }
        }
    }
}
