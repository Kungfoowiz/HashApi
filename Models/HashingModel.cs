using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace HashApi.Models
{

  public class HashingModel
  {

    public HashData Generate256Hash(string input, string description)
    {
      var stopwatch = Stopwatch.StartNew();

      var salt = new byte[256 / 8];
      RandomNumberGenerator.Create().GetBytes(salt);

      var hashText = Convert.ToBase64String(KeyDerivation.Pbkdf2(RandomString(8), salt, KeyDerivationPrf.HMACSHA256, 10000, 256 / 8));

      var hashData = new HashData
      {
        //id = new Random().Next(),
        description = RandomString(200),
        hashText = hashText,
        deleted = false
      };

      stopwatch.Stop();

      hashData.timeCost = stopwatch.ElapsedMilliseconds;

      return hashData;
    }

    private string RandomString(int size)
    {
      var builder = new StringBuilder();
      var random = new Random();
      
      for (int i = 0; i < size; i++)
      {
        builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
      }

      return builder.ToString();
    }

  }

}