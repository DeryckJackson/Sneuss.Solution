using System.Collections.Generic;

namespace Sneuss.Models
{
  public class Engineer
  {
    public Engineer ()
    {
      this.Machines = new HashSet<EngineerMachine>();
    }
    public int EngineerId {get;set;}
    public string Name {get;set;}
    public string Details {get;set;}
    public ICollection<EngineerMachine> Machines {get;}
  }
}