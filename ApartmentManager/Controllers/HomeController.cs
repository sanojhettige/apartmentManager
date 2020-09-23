using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ApartmentManager.Models;

namespace ApartmentManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            int propTotal = _context.Property.Count();
            int aptTotal = _context.Apartment.Count();
            int owners = _context.Owner.Count();
            int tenants = _context.Tenent.Count();
            int totalDue = 0;
            int totalVacant = _context.Apartment.Where(a => a.OwnerId == null).Count();
            ViewData["propTotal"] = propTotal.ToString();
            ViewData["aptTotal"] = aptTotal.ToString();
            ViewData["ownerTotal"] = owners.ToString();
            ViewData["tenantTotal"] = tenants.ToString();
            ViewData["totalDue"] = totalDue.ToString();
            ViewData["totalVacant"] = totalVacant.ToString();


            if (User.IsInRole("Admin"))
                return View();
            else
                return View("../Account/Login");
        }
    }
}