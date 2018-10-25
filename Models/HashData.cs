using System;

namespace HashApi.Models
{
  public class HashData
  {
    public int id { get; set; }

    public string hashText { get; set; }

    public string description { get; set; }

    public long timeCost { get; set; }

    public bool deleted { get; set; }
  }
}