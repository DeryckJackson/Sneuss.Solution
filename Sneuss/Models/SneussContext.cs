using Microsoft.EntityFrameworkCore;

namespace Sneuss.Models
{
  public class SneussContext : DbContext
  {
    
    
    public SneussContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}