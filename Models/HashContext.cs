using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HashApi.Models
{

  public class HashContext : DbContext
  {
    public HashContext(DbContextOptions options) : base(options) { }

    public DbSet<HashData> Hashes { get; set; }
  }

}