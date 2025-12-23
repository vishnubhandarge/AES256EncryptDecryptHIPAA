using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoDesk_Bhandarge_Soft.Services
{
    public class AesCryptoService
    {
        public string Encrypt(string value, string keyText, string ivText)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            byte[] key = Encoding.UTF8.GetBytes(keyText);
            byte[] iv  = Encoding.UTF8.GetBytes(ivText);

            if (key.Length != 32)
                throw new CryptographicException("Key must be exactly 32 characters.");

            if (iv.Length != 12)
                throw new CryptographicException("IV must be exactly 12 characters.");

            byte[] plaintext = Encoding.UTF8.GetBytes(value);
            byte[] ciphertext = new byte[plaintext.Length];
            byte[] tag = new byte[16];

            using var aesGcm = new AesGcm(key);
            aesGcm.Encrypt(iv, plaintext, ciphertext, tag);

            byte[] combined = new byte[iv.Length + tag.Length + ciphertext.Length];
            Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
            Buffer.BlockCopy(tag, 0, combined, iv.Length, tag.Length);
            Buffer.BlockCopy(ciphertext, 0, combined, iv.Length + tag.Length, ciphertext.Length);

            return Convert.ToBase64String(combined);
        }

        public string Decrypt(string value, string keyText)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            byte[] key = Encoding.UTF8.GetBytes(keyText);

            if (key.Length != 32)
                throw new CryptographicException("Key must be exactly 32 characters.");

            byte[] combined = Convert.FromBase64String(value.Replace(" ", "+"));

            if (combined.Length < 29)
                throw new CryptographicException("Invalid payload.");

            byte[] iv = new byte[12];
            byte[] tag = new byte[16];
            byte[] ciphertext = new byte[combined.Length - 28];
            byte[] plaintext = new byte[ciphertext.Length];

            Buffer.BlockCopy(combined, 0, iv, 0, 12);
            Buffer.BlockCopy(combined, 12, tag, 0, 16);
            Buffer.BlockCopy(combined, 28, ciphertext, 0, ciphertext.Length);

            using var aesGcm = new AesGcm(key);
            aesGcm.Decrypt(iv, ciphertext, tag, plaintext);

            return Encoding.UTF8.GetString(plaintext);
        }

    }
}
