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


        //GET /api/user/1
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == "1");

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<ApplicationUser>(user));
        }

        //GET /api/user
        public IEnumerable<ApplicationUser> GetUser(string query = null)
        {
            //return _context.Users
            // .Where(m => m.Id != "4").ToList();

            return _context.Users.Include(u => u.Roles).ToList();
  
        }

        // POST /api/user
        [HttpPost]
        public IHttpActionResult CreateUser(ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var user = Mapper.Map<ApartmentDto, Apartment>(apartmentDto);
            _context.Apartment.Add(user);
            _context.SaveChanges();

            apartmentDto.Id = user.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + user.Id), apartmentDto);
        }
        // PUT /api/user/1
        [HttpPut]
        public void UpdateUser(int id, PropertyDto apartmentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedUser = _context.Apartment.SingleOrDefault(c => c.Id == id);

            if (selectedUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(apartmentDto, selectedUser);

            _context.SaveChanges();
        }
        //DELETE api/us/1er
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var selectedUser = _context.Apartment.SingleOrDefault(c => c.Id == id);

            if (selectedUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Apartment.Remove(selectedUser);
            _context.SaveChanges();

        }

    }

}
