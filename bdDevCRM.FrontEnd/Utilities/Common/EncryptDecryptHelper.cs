using System.Security.Cryptography;
using System.Text;

namespace bdDevCRM.FrontEnd.Utilities.Common;

public class EncryptDecryptHelper
{
  public static string Encrypt(string plainText)
  {
    string passPhrase = "#*!@";
    string saltValue = "123!@*";
    string hashAlgorithm = "MD5";
    int passwordIterations = 1;
    string initVector = "@1B2c3D4e5F6g7H8";
    int keySize = 256;

    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);


    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm,
      passwordIterations);


    byte[] keyBytes = password.GetBytes(keySize / 8);


    RijndaelManaged symmetricKey = new RijndaelManaged();

    symmetricKey.Mode = CipherMode.CBC;


    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

    MemoryStream memoryStream = new MemoryStream();


    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);


    cryptoStream.FlushFinalBlock();


    byte[] cipherTextBytes = memoryStream.ToArray();


    memoryStream.Close();
    cryptoStream.Close();


    string cipherText = Convert.ToBase64String(cipherTextBytes);

    return cipherText;
  }

  public static string Decrypt(string cipherText)
  {
    try
    {


      string passPhrase = "#*!@";
      string saltValue = "123!@*";
      string hashAlgorithm = "MD5";
      int passwordIterations = 1;
      string initVector = "@1B2c3D4e5F6g7H8";
      int keySize = 256;
      byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
      byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);


      byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

      PasswordDeriveBytes password = new PasswordDeriveBytes(
        passPhrase,
        saltValueBytes,
        hashAlgorithm,
        passwordIterations);


      byte[] keyBytes = password.GetBytes(keySize / 8);


      RijndaelManaged symmetricKey = new RijndaelManaged();


      symmetricKey.Mode = CipherMode.CBC;


      ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);


      MemoryStream memoryStream = new MemoryStream(cipherTextBytes);


      CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

      byte[] plainTextBytes = new byte[cipherTextBytes.Length];

      var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

      memoryStream.Close();
      cryptoStream.Close();


      string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
      return plainText;
    }
    catch (Exception)
    {
      return cipherText;
    }
  }
}