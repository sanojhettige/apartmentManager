using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using ApartmentManager.Models;

namespace ApartmentManager.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = new ApplicationDbContext();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                return HttpNotFound();

            ViewData["user"] = user;

            var viewModel = new ProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            };

            return View(viewModel);
        }

        // POST: /Manage/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            user.Name = model.Name;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.UpdateProfileSuccess });
            }
            AddErrors(result);
            return View(model);
        }


        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        // GET: /Manager/Users
        public ActionResult Users()
        {
            return View();
        }

        // GET: /Manage/CreateUser
        [AllowAnonymous]
        public ActionResult CreateUser()
        {
            var list = new SelectList(new[] 
            {
                new { ID = "Admin", Name = "Admin" },
                new { ID = "ApartmentAdmin", Name = "Property Manager" },
                new { ID = "FinanceManager", Name = "Finance Manager" },
            },
            "ID", "Name", 1);

            //var properties = _context.Property.ToList();

            var viewModel = new RegisterViewModel
            {
            };

            ViewData["list"] = list;
            //ViewData["properties"] = properties;

            return View(viewModel);
        }

        //GET: /Manage/UpdateUser/1
        public async Task<ActionResult> UpdateUser(string userId)
        {
            var userId2 = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId2);

            if (user == null)
                return HttpNotFound();

            var list = new SelectList(new[]
            {
                new { ID = "Admin", Name = "Admin" },
                new { ID = "ApartmentAdmin", Name = "Property Manager" },
                new { ID = "FinanceManager", Name = "Finance Manager" },
            },
            "ID", "Name", 1);

            ViewData["list"] = list;
            ViewData["user"] = user;

            var viewModel = new RegisterViewModel
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            };

            return View("CreateUser", viewModel);
        }

        // POST: /Manager/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByIdAsync(model.Id);

            var list = new SelectList(new[]
            {
                new { ID = "Admin", Name = "Admin" },
                new { ID = "ApartmentAdmin", Name = "Property Manager" },
                new { ID = "FinanceManager", Name = "Finance Manager" },
            },
            "ID", "Name", 1);

            ViewData["list"] = list;


            if (user ==  null)
            {
                var userData = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PropertyId = model.PropertyId,
                    Name = model.Name
                };

                var result = await UserManager.CreateAsync(userData, model.Password);

                if (result.Succeeded)
                {
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    await roleManager.CreateAsync(new IdentityRole(model.RoleId));
                    if(model.RoleId.ToString() == "Admin")
                    {
                        await UserManager.AddToRoleAsync(userData.Id, "admin");
                    } else if(model.RoleId.ToString() == "ApartmentAdmin")
                    {
                        await UserManager.AddToRoleAsync(userData.Id, "apartmentAdmin");
                    } else if(model.RoleId.ToString() == "FinanceManager")
                    {
                        await UserManager.AddToRoleAsync(userData.Id, "financeManager");
                    }
                    
                    return RedirectToAction("Users", "Manage");
                }

                AddErrors(result);

            } else
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    await roleManager.CreateAsync(new IdentityRole(model.RoleId));
                    //await UserManager.AddToRoleAsync(user.Id, model.RoleId);
                    if (model.RoleId.ToString() == "Admin")
                    {
                        await UserManager.AddToRoleAsync(user.Id, "admin");
                    }
                    else if (model.RoleId.ToString() == "ApartmentAdmin")
                    {
                        await UserManager.AddToRoleAsync(user.Id, "apartmentAdmin");
                    }
                    else if (model.RoleId.ToString() == "FinanceManager")
                    {
                        await UserManager.AddToRoleAsync(user.Id, "financeManager");
                    }


                    return RedirectToAction("Index", new { Message = ManageMessageId.UpdateProfileSuccess });
                }
                AddErrors(result);
                return View("CreateUser", model);

            }
            // If we got this far, something failed, redisplay form
            return View("CreateUser", model);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            UpdateProfileSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}