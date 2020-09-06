using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class TenentController : Controller
    {
        private ApplicationDbContext _context;

        public TenentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Property/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tenent
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create Tenent
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var apartments = _context.Apartment.ToList();
            var viewModel = new TenentFormViewModel
            {
                Tenent = new Tenent(),
                Apartments = apartments
            };
            return View("TenentForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Tenent tenent)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new TenentFormViewModel
                {
                    Tenent = tenent
                };

                return View("TenentForm", viewModel);
            }
            if (tenent.Id == 0)
            {
                tenent.CreatedAt = DateTime.Now;
                tenent.ModifiedAt = DateTime.Now;
                tenent.TenentFrom = DateTime.Now;
                tenent.CreatedBy = "";
                tenent.ModifiedBy = "";
                _context.Tenent.Add(tenent);

            }
            else
            {
                var selectedTenent = _context.Tenent.Single(m => m.Id == tenent.Id);
                selectedTenent.Name = tenent.Name;
                selectedTenent.NicNo = tenent.NicNo;
                selectedTenent.PhoneNumber = tenent.PhoneNumber;
                selectedTenent.EmailAddress = tenent.EmailAddress;
                selectedTenent.ModifiedAt = DateTime.Now;
                selectedTenent.ModifiedBy = "";

            }

            _context.SaveChanges();

            return RedirectToAction("index", "Tenent");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var tenent = _context.Tenent.SingleOrDefault(c => c.Id == id);
            if (tenent == null)
                return HttpNotFound();
            var viewModel = new TenentFormViewModel
            {
                Tenent = tenent

            };
            return View("TenentForm", viewModel);
        }

    }
}