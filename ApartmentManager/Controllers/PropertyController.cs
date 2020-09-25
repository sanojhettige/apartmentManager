using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext _context;

        public PropertyController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Property/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Property
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create Property
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new PropertyFormViewModel
            {
                Property = new Property()
            };
            return View("PropertyForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Property property)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new PropertyFormViewModel
                {
                    Property = property
                };

                return View("PropertyForm", viewModel);
            }
            try
            {
                if (property.Id == 0)
                {
                    property.CreatedAt = DateTime.Now;
                    property.ModifiedAt = DateTime.Now;
                    property.CreatedBy = 1;
                    property.ModifiedBy = 1;
                    _context.Property.Add(property);

                }
                else
                {
                    var selectedPprty = _context.Property.Single(m => m.Id == property.Id);
                    selectedPprty.PropertyName = property.PropertyName;
                    selectedPprty.Address = property.Address;
                    selectedPprty.PhoneNumber = property.PhoneNumber;
                    selectedPprty.EmailAddress = property.EmailAddress;
                    selectedPprty.FaxNumber = property.FaxNumber;
                    selectedPprty.NumFloors = property.NumFloors;
                    selectedPprty.NumUnits = property.NumUnits;
                    selectedPprty.OtherAmenities = property.OtherAmenities;
                    selectedPprty.ModifiedAt = DateTime.Now;
                    selectedPprty.ModifiedBy = 1;

                }

                _context.SaveChanges();

                return RedirectToAction("index", "Property");

            } catch(Exception e)
            {
                return RedirectToAction("index", "Property");
            }
            
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var property = _context.Property.SingleOrDefault(c => c.Id == id);
            if (property == null)
                return HttpNotFound();
            var viewModel = new PropertyFormViewModel
            {
                Property = property

            };
            return View("PropertyForm", viewModel);
        }

    }
}