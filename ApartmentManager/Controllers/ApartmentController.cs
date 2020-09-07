using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class ApartmentController : Controller
    {
        private ApplicationDbContext _context;

        public ApartmentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Apartments/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Apartment
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create Apartment
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(int Id)
        {
            //var owners = _context.Owner.ToList();
            var types = _context.ApartmentType.ToList();
            var apartment = new Apartment();
            apartment.PropertyId = Id;
            var viewModel = new ApartmentFormViewModel
            {
                Apartment = apartment,
                ApartmentTypes = types
            };
            return View("ApartmentForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Apartment apartment)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new ApartmentFormViewModel
                {
                    Apartment = apartment
                };

                return View("ApartmentForm", viewModel);
            }
            if (apartment.Id == 0)
            {
                apartment.CreatedAt = DateTime.Now;
                apartment.ModifiedAt = DateTime.Now;
                apartment.CreatedBy = "";
                apartment.ModifiedBy = "";
                _context.Apartment.Add(apartment);

            }
            else
            {
                var selectedApartment = _context.Apartment.Single(m => m.Id == apartment.Id);
                selectedApartment.PropertyId = apartment.PropertyId;
                selectedApartment.FloorNo = apartment.FloorNo;
                selectedApartment.UnitNo = apartment.UnitNo;
                selectedApartment.ModifiedAt = DateTime.Now;
                selectedApartment.ModifiedBy = "";

            }

            _context.SaveChanges();

            if(apartment.PropertyId > 0)
                return RedirectToAction("index", "Property/Apartments/" + apartment.PropertyId);

            return RedirectToAction("index", "Apartment");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var apartment = _context.Apartment.SingleOrDefault(c => c.Id == id);
            if (apartment == null)
                return HttpNotFound();
            //var owners = _context.Owner.ToList();
            var types = _context.ApartmentType.ToList();
            var viewModel = new ApartmentFormViewModel
            {
                Apartment = apartment,
                ApartmentTypes = types
            };
            return View("ApartmentForm", viewModel);
        }
    }
}