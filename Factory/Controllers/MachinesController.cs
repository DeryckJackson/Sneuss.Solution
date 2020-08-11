using Microsoft.AspNetCore.Mvc;
using Sneuss.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Sneuss.Controllers
{
  public class MachinesController : Controller
  {
    private readonly SneussContext _db;

    public MachinesController(SneussContext db)
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine mach)
    {
      _db.Machines.Add(mach);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(mach => mach.Engineers)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(mach => mach.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit (int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      ViewBag.Engineers = new SelectList(_db.Machines, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine mach)
    {
      _db.Entry(mach).State = EntityState.Modified; 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    { 
      Machine thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Engineer eng, int MachineId)
    {
      if (MachineId != 0 && eng.EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {MachineId = MachineId, EngineerId = eng.EngineerId});
        _db.SaveChanges();
      }
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