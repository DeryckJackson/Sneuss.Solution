using Microsoft.AspNetCore.Mvc;
using Sneuss.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace Sneuss.Controllers
{
  public class EngineersController : Controller
  {
    private readonly SneussContext _db;

    public EngineersController(SneussContext db)
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      var model = _db.Engineers
        .Include(eng => eng.Machines)
        .ThenInclude(join => join.Machine)
        .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer eng)
    {
      _db.Engineers.Add(eng);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
        .Include(eng => eng.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(eng => eng.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit (int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      ViewBag.Machines = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer eng)
    {
      _db.Entry(eng).State = EntityState.Modified; 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    { 
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Machine mach, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = mach.MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}