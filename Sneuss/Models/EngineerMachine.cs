namespace Sneuss.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId {get; set;}
    public int EngineerId {get; set;}
    public int MahchineId {get; set;}
    public Engineer Engineer {get; set;}
    public Machine Machine {get; set;}
  }
}