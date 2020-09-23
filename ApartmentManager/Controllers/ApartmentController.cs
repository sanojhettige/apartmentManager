using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace ApartmentManager.Controllers
{
    public class ApartmentController : Controller
    {
        private ApplicationDbContext _context;
        private string userId;

        public ApartmentController()
        {
            _context = new ApplicationDbContext();
            userId = "";//User.Identity.GetUserId();
        }

        // GET: Apartments/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Apartment
        public ActionResult Index()
        {
            var property = new Property();
            var owners = _context.Owner.ToList();
            var tenents = _context.Tenent.ToList();

            property.PropertyName = "";

            var viewModel = new ApartmentFormViewModel
            {
                Property = property,
                Owners = owners,
                Tenents = tenents
            };

            var activity = new Activity();
            activity.ActivityLog = "View Apartments Page";
            activity.UserId = userId;
            activity.CreatedAt = DateTime.Now;
            _context.Activity.Add(activity);

            if (User.IsInRole(RoleName.Admin))
                return View("index", viewModel);
            else
                return View("../Shared/NoPermission");
        }


        [Authorize(Roles = RoleName.Admin)]
        public ActionResult property(int id = 0)
        {
            var property = _context.Property.SingleOrDefault(c => c.Id == id);
            
            if (property == null)
                return HttpNotFound();
            else {
                var owners = _context.Owner.ToList();
                var tenents = _context.Tenent.ToList();
                var viewModel = new ApartmentFormViewModel
                {
                    Property = property,
                    Owners = owners,
                    Tenents = tenents
                };

                var activity = new Activity();
                activity.ActivityLog = "View Apartments Page";
                activity.UserId = userId;
                activity.CreatedAt = DateTime.Now;
                _context.Activity.Add(activity);

                return View("index", viewModel);
            }
            return RedirectToAction("index", "Apartment");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Assign(Apartment apartment)
        {
            if (apartment.Id > 0)
            {
                var selectedApartment = _context.Apartment.Single(m => m.Id == apartment.Id);
                
                if(apartment.OwnerId > 0)
                {
                    selectedApartment.OwnerId = apartment.OwnerId;
                }

                if (apartment.TenentId > 0 && selectedApartment.OwnerId > 0)
                {
                    selectedApartment.TenentId = apartment.TenentId;
                } else
                {

                }
                selectedApartment.ModifiedAt = DateTime.Now;
                selectedApartment.ModifiedBy = userId;
                _context.SaveChanges();

            }

            if (apartment.PropertyId > 0)
                return RedirectToAction("index", "Apartment/Property/" + apartment.PropertyId);

            return RedirectToAction("index", "Apartment");
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
                apartment.CreatedBy = userId;
                apartment.ModifiedBy = userId;
                _context.Apartment.Add(apartment);

            }
            else
            {
                var selectedApartment = _context.Apartment.Single(m => m.Id == apartment.Id);
                selectedApartment.PropertyId = apartment.PropertyId;
                selectedApartment.FloorNo = apartment.FloorNo;
                selectedApartment.UnitNo = apartment.UnitNo;
                selectedApartment.ModifiedAt = DateTime.Now;
                selectedApartment.ModifiedBy = userId;

            }

            _context.SaveChanges();

            if(apartment.PropertyId > 0)
                return RedirectToAction("index", "Apartment/Property/" + apartment.PropertyId);

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


        [Authorize(Roles = RoleName.Admin)]
        public ActionResult GenerateBill(int Id)
        {
            var apartment = _context.Apartment.SingleOrDefault(c => c.Id == Id);
            var invoice = new MaintenanceInvoice();
            if (apartment == null)
                return HttpNotFound();

            var aptType = _context.ApartmentType.SingleOrDefault(c => c.Id == apartment.ApartmentTypeId);

            invoice.ApartmentId = Id;
            invoice.MaintenanceCost = aptType.MaintenanceCharge;

            var viewModel = new ApartmentBillViewModel
            {
                MaintenanceInvoice = invoice
            };
            return View(viewModel);
        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult SaveBill(MaintenanceInvoice maintenanceInvoice)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new ApartmentBillViewModel
                {
                    MaintenanceInvoice = maintenanceInvoice
                };

                return View("GenerateBill", viewModel);
            }
            if (maintenanceInvoice.Id == 0)
            {
                maintenanceInvoice.CreatedAt = DateTime.Now;
                maintenanceInvoice.ModifiedAt = DateTime.Now;
                maintenanceInvoice.CreatedBy = userId;
                maintenanceInvoice.ModifiedBy = userId;
                maintenanceInvoice.Status = 1;
                _context.MaintenanceInvoice.Add(maintenanceInvoice);

            }
            else
            {
                var selectedInvoice = _context.MaintenanceInvoice.Single(m => m.Id == maintenanceInvoice.Id);
                selectedInvoice.MaintenanceCost = maintenanceInvoice.MaintenanceCost;
                selectedInvoice.ElectricityUnits = maintenanceInvoice.ElectricityUnits;
                selectedInvoice.ElectricityCost = maintenanceInvoice.ElectricityCost;
                selectedInvoice.WaterUnits = maintenanceInvoice.WaterUnits;
                selectedInvoice.WaterCost = maintenanceInvoice.WaterCost;
                selectedInvoice.GasUnits = maintenanceInvoice.GasUnits;
                selectedInvoice.GasCost = maintenanceInvoice.GasCost;
                selectedInvoice.OtherNotes = maintenanceInvoice.OtherNotes;
                selectedInvoice.OtherCost = maintenanceInvoice.OtherCost;
                selectedInvoice.ModifiedAt = DateTime.Now;
                selectedInvoice.ModifiedBy = userId;

            }

            _context.SaveChanges();

            return RedirectToAction("index", "Apartment");
        }
    }
}