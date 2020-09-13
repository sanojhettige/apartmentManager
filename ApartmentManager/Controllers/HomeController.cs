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
            var propTotal = _context.Property.Count();
            var aptTotal = _context.Apartment.Count();
            var owners = _context.Owner.Count();
            var tenents = _context.Tenent.Count();
            ViewData["propTotal"] = propTotal;


            if (User.IsInRole("Admin"))
                return View();
            else
                return View("../Account/Login");
        }
    }
}