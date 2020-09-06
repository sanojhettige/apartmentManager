using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Property/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Category
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create Category
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new ApartmentTypeFormViewModel
            {
                ApartmentType = new ApartmentType()
            };
            return View("CategoryForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(ApartmentType category)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new ApartmentTypeFormViewModel
                {
                    ApartmentType = category
                };

                return View("CategoryForm", viewModel);
            }
            if (category.Id == 0)
            {
                category.CreatedAt = DateTime.Now;
                category.ModifiedAt = DateTime.Now;
                category.CreatedBy = "";
                category.ModifiedBy = "";
                _context.ApartmentType.Add(category);

            }
            else
            {
                var selectedCategory = _context.ApartmentType.Single(m => m.Id == category.Id);
                selectedCategory.Name = category.Name;
                selectedCategory.SquareFeets = category.SquareFeets;
                selectedCategory.NumRooms = category.NumRooms;
                selectedCategory.NumBathRooms = category.NumBathRooms;
                selectedCategory.MaintenanceCharge = category.MaintenanceCharge;
                selectedCategory.ModifiedAt = DateTime.Now;
                selectedCategory.ModifiedBy = "";

            }

            _context.SaveChanges();

            return RedirectToAction("index", "Category");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var category = _context.ApartmentType.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();
            var viewModel = new ApartmentTypeFormViewModel
            {
                ApartmentType = category

            };
            return View("CategoryForm", viewModel);
        }

    }
}