using Microsoft.EntityFrameworkCore;

namespace Sneuss.Models
{
  public class SneussContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines {get; set; }
    public DbSet<EngineerMachine> EngineerMachine {get; set; }
    
    public SneussContext(DbContextOptions options) : base(options) { }
  }
}