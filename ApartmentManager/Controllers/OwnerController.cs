using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class OwnerController : Controller
    {
        private ApplicationDbContext _context;

        public OwnerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Property/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Owner
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }

        // GET: Create Owner
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new OwnerFormViewModel
            {
                Owner = new Owner()
            };
            return View("OwnerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Owner owner)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new OwnerFormViewModel
                {
                    Owner = owner
                };

                return View("OwnerForm", viewModel);
            }
            try
            {
                if (owner.Id == 0)
                {
                    owner.CreatedAt = DateTime.Now;
                    owner.ModifiedAt = DateTime.Now;
                    owner.CreatedBy = "";
                    owner.ModifiedBy = "";
                    _context.Owner.Add(owner);

                }
                else
                {
                    var selectedOwner = _context.Owner.Single(m => m.Id == owner.Id);
                    selectedOwner.Name = owner.Name;
                    selectedOwner.NicNo = owner.NicNo;
                    selectedOwner.PhoneNumber = owner.PhoneNumber;
                    selectedOwner.EmailAddress = owner.EmailAddress;
                    selectedOwner.ModifiedAt = DateTime.Now;
                    selectedOwner.ModifiedBy = "";

                }

                _context.SaveChanges();

                return RedirectToAction("index", "Owner");

            } catch(Exception e)
            {
                return RedirectToAction("index", "Owner");
            }
            
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var owner = _context.Owner.SingleOrDefault(c => c.Id == id);
            if (owner == null)
                return HttpNotFound();
            var viewModel = new OwnerFormViewModel
            {
                Owner = owner

            };
            return View("OwnerForm", viewModel);
        }

    }
}