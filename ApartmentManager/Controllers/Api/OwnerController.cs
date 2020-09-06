using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ApartmentManager.Dtos;
using ApartmentManager.Models;

namespace WebApplication2.Controllers.Api
{
    public class OwnerController : ApiController
    {
        private ApplicationDbContext _context;

        public OwnerController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/owner
        public IHttpActionResult GetOwner(int id)
        {
            var owner = _context.Owner.SingleOrDefault(c => c.Id == id);

            if (owner == null)
                return NotFound();

            return Ok(Mapper.Map<Owner, OwnerDto>(owner));
        }

        //GET /api/owner/1
        public IEnumerable<OwnerDto> GetOwners(string query = null)
        {
            var ownerQuery = _context.Owner
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                ownerQuery = ownerQuery.Where(m => m.Name.Contains(query));

            return ownerQuery
                .ToList()
                .Select(Mapper.Map<Owner, OwnerDto>);
        }
        // POST /api/owner
        [HttpPost]
        public IHttpActionResult CreateOwner(OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var owner = Mapper.Map<OwnerDto, Owner>(ownerDto);
            _context.Owner.Add(owner);
            _context.SaveChanges();

            ownerDto.Id = owner.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + owner.Id), ownerDto);
        }
        // PUT /api/owner/1
        [HttpPut]
        public void UpdateOwner(int id, OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedOwner = _context.Property.SingleOrDefault(c => c.Id == id);

            if (selectedOwner == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(ownerDto, selectedOwner);

            _context.SaveChanges();
        }
        //DELETE api/owner/1
        [HttpDelete]
        public void DeleteOwner(int id)
        {
            var selectedOwner = _context.Owner.SingleOrDefault(c => c.Id == id);

            if (selectedOwner == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Owner.Remove(selectedOwner);
            _context.SaveChanges();

        }

    }

}
