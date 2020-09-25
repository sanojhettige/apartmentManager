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
        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DuePayments()
        {
            var owners = _context.Owner.ToList();
            var apartments = _context.Apartment.ToList();
            var properties = _context.Property.ToList();
            
            var viewModel = new ReportFormViewModel
            {
                Apartments = apartments,
                Owners = owners,
                Properties = properties
            };
            return View("DuePayments", viewModel);
        }

        // POST: SearchDues
        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DuePayments(ReportFormViewModel model)
        {
            var owners = _context.Owner.ToList();
            var apartments = _context.Apartment.ToList();
            var properties = _context.Property.ToList();

            var viewModel = new ReportFormViewModel
            {
                Apartments = apartments,
                Owners = owners,
                Properties = properties,
                PropertyId = model.PropertyId,
                ApartmentId = model.ApartmentId,
                OwnerId = model.OwnerId
            };

            return View("DuePayments", viewModel);
        }

        // GET: /Report/AddDuePayment
        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult AddDuePayment()
        {
            return View();
        }


        // GET: /Report/DownloadDue
        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DownloadDue(int? Id)
        {
            return View();
        }


        // GET: Apartments
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Apartments(int? Id)
        {
            return View();
        }

        // GET: Owners
        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Owners()
        {
            return View();
        }


        // GET: Tenents
        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Tenants()
        {
            return View();
        }
    }
}