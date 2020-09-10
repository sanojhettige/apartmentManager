using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentManager.Models;
using ApartmentManager.ViewModels;

namespace ApartmentManager.Controllers
{
    public class SecurityGuardController : Controller
    {
        private ApplicationDbContext _context;

        public SecurityGuardController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: SecurityGuard/Random 

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: SecurityGuard
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View();
            else
                return View("../Shared/NoPermission");
        }


        // GET: Create SecurityGuard
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var properties = _context.Property.ToList();
            var securityGuard = new SecurityGuard();
            var viewModel = new SecurityGuardFormViewModel
            {
                Properties = properties,
                SecurityGuard = securityGuard
            };
            return View("SecurityGuardForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(SecurityGuard securityGuard)
        {
            //Model.State to check validation from the model
            if (!ModelState.IsValid)
            {
                var viewModel = new SecurityGuardFormViewModel
                {
                    SecurityGuard = securityGuard
                };

                return View("Form", viewModel);
            }
            if (securityGuard.Id == 0)
            {
                securityGuard.CreatedAt = DateTime.Now;
                securityGuard.ModifiedAt = DateTime.Now;
                securityGuard.CreatedBy = "";
                securityGuard.ModifiedBy = "";
                _context.SecurityGuard.Add(securityGuard);

            }
            else
            {
                var selectedGuard = _context.SecurityGuard.Single(m => m.Id == securityGuard.Id);
                selectedGuard.PropertyId = securityGuard.PropertyId;
                selectedGuard.Name = securityGuard.Name;
                selectedGuard.NicNo = securityGuard.NicNo;
                selectedGuard.PhoneNumber = securityGuard.PhoneNumber;
                selectedGuard.ModifiedAt = DateTime.Now;
                selectedGuard.ModifiedBy = "";

            }

            _context.SaveChanges();
            return RedirectToAction("index", "SecurityGuard");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var guard = _context.SecurityGuard.SingleOrDefault(c => c.Id == id);
            if (guard == null)
                return HttpNotFound();
            var properties = _context.Property.ToList();
            var viewModel = new SecurityGuardFormViewModel
            {
                SecurityGuard = guard,
                Properties = properties
            };
            return View("SecurityGuardForm", viewModel);
        }
    }
}