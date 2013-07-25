using System;
using System.Text;
using System.Security.Cryptography;

namespace DotNet_Token_Auth
{
  /// <summary>
  /// A simple utility class to make encrypting
  /// data easier.
  /// </summary>
  public class Encryptor
  {
    public Encryptor()
    {
    }

    /// <summary>
    /// Encrypt the specified data using the provided key. The
    /// encrypted data will be returned as a base 64 encoded
    /// string.
    /// </summary>
    /// <param name="data">The data string to encrypt.</param>
    /// <param name="key">The key to use for encryption.</param>
    public static String Encrypt(String data, String key) {
      // Generate an initialization vector.
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
      byte[] iv = new byte[16];
      rng.GetNonZeroBytes(iv);

      byte[] dataBytes = Encoding.ASCII.GetBytes(data);
      byte[] toEncryptBytes = new byte[iv.Length + dataBytes.Length];

      // Build the data to encrypt using the iv and the source data.
      System.Array.Copy(iv, 0, toEncryptBytes, 0, iv.Length);
      System.Array.Copy(dataBytes, 0, toEncryptBytes, iv.Length, dataBytes.Length);

      RijndaelManaged cipher = new RijndaelManaged();
      cipher.KeySize = 128;
      cipher.BlockSize = 128;
      cipher.Mode = CipherMode.CBC;
      cipher.Padding = PaddingMode.PKCS7;
      cipher.IV = iv;
      cipher.Key = Encoding.ASCII.GetBytes(key);

      ICryptoTransform crypto = cipher.CreateEncryptor();
      byte[] encryptedData = crypto.TransformFinalBlock(toEncryptBytes, 0, toEncryptBytes.Length);

      return System.Convert.ToBase64String (encryptedData);
    }
  }
}

