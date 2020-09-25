using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using ApartmentManager.Dtos;
using ApartmentManager.Models;

namespace WebApplication2.Controllers.Api
{
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/user
        public IEnumerable<ApplicationUser> GetUser(string query = null)
        {
            var userId = User.Identity.GetUserId(); 

            return _context.Users
                .Where(u => u.Id != userId)
                .Include(u => u.Roles)
                //.Include(p => p.PropertyId)
                .ToList();
  
        }


        //DELETE api/user/1
        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var selectedUser = _context.Users.SingleOrDefault(c => c.Id == id);

            if (selectedUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(selectedUser);
            _context.SaveChanges();
            return Ok(selectedUser);

        }

    }

}
