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

  }
}