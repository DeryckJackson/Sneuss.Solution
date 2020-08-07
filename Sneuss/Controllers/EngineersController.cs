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
  }
}