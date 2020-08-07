using Microsoft.AspNetCore.Mvc;
using Sneuss.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

  }
}