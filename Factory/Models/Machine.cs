using System.Collections.Generic;

namespace Sneuss.Models
{
  public class Machine
  {
    public Machine ()
    {
      this.Engineers = new HashSet<EngineerMachine>();
    }
    public int MachineId {get;set;}
    public string Name {get;set;}
    public string Details {get;set;}
    public string Status {get;set;} = "Operational";
    public ICollection<EngineerMachine> Engineers {get;}
  }
}