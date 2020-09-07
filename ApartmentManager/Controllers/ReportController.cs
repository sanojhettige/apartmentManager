using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext _context;

        public ReportController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Apartments/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Report
        public ActionResult Index()
        {
            return View();
        }


        // GET: DuePayments
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DuePayments()
        {
            var owners = _context.Owner.ToList();
            var apartments = _context.Apartment.ToList();
            
            var viewModel = new ReportFormViewModel
            {
                Apartments = apartments,
                Owners = owners
            };
            return View("DuePayments", viewModel);
        }

        // POST: SearchDues
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult SearchDues()
        {
            var owners = _context.Owner.ToList();
            var apartments = _context.Apartment.ToList();

            var viewModel = new ReportFormViewModel
            {
                Apartments = apartments,
                Owners = owners
            };

            return View("DuePayments", viewModel);
        }

        // GET: Apartments


        // GET: Owners


        // GET: Tenents
    }
}