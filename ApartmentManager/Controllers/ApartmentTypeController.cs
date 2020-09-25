using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class ApartmentTypeController : Controller
    {
        private ApplicationDbContext _context;

        public ApartmentTypeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ApartmentType/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ApartmentType
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create ApartmentType
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new ApartmentTypeFormViewModel
            {
                ApartmentType = new ApartmentType()
            };
            return View("ApartmentTypeForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(ApartmentType apartmentType)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new ApartmentTypeFormViewModel
                {
                    ApartmentType = apartmentType
                };

                return View("ApartmentTypeForm", viewModel);
            }
            try
            {
                if (apartmentType.Id == 0)
                {
                    apartmentType.CreatedAt = DateTime.Now;
                    apartmentType.ModifiedAt = DateTime.Now;
                    apartmentType.CreatedBy = "";
                    apartmentType.ModifiedBy = "";
                    _context.ApartmentType.Add(apartmentType);

                }
                else
                {
                    var selectedType = _context.ApartmentType.Single(m => m.Id == apartmentType.Id);
                    selectedType.Name = apartmentType.Name;
                    selectedType.SquareFeets = apartmentType.SquareFeets;
                    selectedType.NumRooms = apartmentType.NumRooms;
                    selectedType.NumBathRooms = apartmentType.NumBathRooms;
                    selectedType.MaintenanceCharge = apartmentType.MaintenanceCharge;
                    selectedType.ModifiedAt = DateTime.Now;
                    selectedType.ModifiedBy = "";

                }

                _context.SaveChanges();

                return RedirectToAction("index", "ApartmentType");

            } catch(Exception e)
            {
                return RedirectToAction("index", "ApartmentType");
            }
            
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var apartmentType = _context.ApartmentType.SingleOrDefault(c => c.Id == id);
            if (apartmentType == null)
                return HttpNotFound();
            var viewModel = new ApartmentTypeFormViewModel
            {
                ApartmentType = apartmentType

            };
            return View("ApartmentTypeForm", viewModel);
        }

    }
}