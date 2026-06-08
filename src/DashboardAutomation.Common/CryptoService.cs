

namespace DashboardAutomation.Common
{
  public class CryptoService
  {
    public CryptoService(string? key = null, string? iv = null)
    {
      _key = key ?? GenerateKey();
      _iv = iv ?? GenerateKey()[..16];
    }


    #region Properties

    private string _key;
    private string _iv;

    public string Key => _key;
    public string IV => _iv;

    #endregion

    #region Methods

    public string GenerateKey()
    {
      Aes rijAlg = Aes.Create();
      rijAlg.GenerateKey();
      var key = Convert.ToBase64String(rijAlg.Key);
      rijAlg.Dispose();
      return key.Length > 32 ? key.Substring(0, 32) : key;
    }

    public string Encrypt(string str)
        => Encrypt(str, _key, _iv);

    public string Decrypt(string str)
        => Decrypt(str, _key, _iv);

    public string EncryptDynamic(string str)
    {
      var key = GenerateKey();
      var enc = Encrypt(str, key, "dFG65?:sdfPG*((#");
      var output = string.Empty;
      for (int i = 0; i < key.Length; i++)
        output += $"{(char)new Random().Next(65, 122)}{key[i]}";
      output += "." + enc;
      return output;
    }

    public string DecryptDynamic(string str)
    {
      var hideKey = str.Split('.')[0];
      var key = string.Empty;
      for (int i = 1; i < hideKey.Length; i += 2)
        key += hideKey[i];
      return Decrypt(str.Split('.')[1], key, "dFG65?:sdfPG*((#");
    }

    private string Encrypt(string str, string key, string iv)
    {
      byte[] encrypted;
      using (Aes rijAlg = Aes.Create())
      {
        rijAlg.Key = GetBytes(key);
        rijAlg.IV = GetBytes(iv);
        ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

        using (MemoryStream msEncrypt = new MemoryStream())
        {
          using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
          {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
              swEncrypt.Write(str);
            }
            encrypted = msEncrypt.ToArray();
          }
        }
      }
      return Convert.ToBase64String(encrypted);
    }

    private string Decrypt(string str, string key, string iv)
    {
      string plaintext = string.Empty;
      try
      {
        using (Aes rijAlg = Aes.Create())
        {
          rijAlg.Key = GetBytes(key);
          rijAlg.IV = GetBytes(iv);

          ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

          using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(str)))
          {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
              using (StreamReader srDecrypt = new StreamReader(csDecrypt))
              {
                plaintext = srDecrypt.ReadToEnd();
              }
            }
          }
        }
      }
      catch { }

      return plaintext;
    }

    private byte[] GetBytes(string str)
    {
      return Encoding.UTF8.GetBytes(str);
    }

    #endregion


  }
}
