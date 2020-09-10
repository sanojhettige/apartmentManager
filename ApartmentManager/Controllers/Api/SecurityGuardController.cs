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
    public class SecurityGuardController : ApiController
    {
        private ApplicationDbContext _context;

        public SecurityGuardController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/securityGuard/1
        public IHttpActionResult GetSecurityGuard(int id)
        {
            var guard = _context.SecurityGuard.SingleOrDefault(c => c.Id == id);

            if (guard == null)
                return NotFound();

            return Ok(Mapper.Map<SecurityGuard, SecurityGuardDto>(guard));
        }

        //GET /api/securityGuard
        public IEnumerable<SecurityGuardDto> GetsScurityGuard(string query = null)
        {
            var guardQuery = _context.SecurityGuard
                .Include(m => m.Property)
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                guardQuery = guardQuery.Where(m => m.PropertyId == 2);

            return guardQuery
                .ToList()
                .Select(Mapper.Map<SecurityGuard, SecurityGuardDto>);
        }

        // POST /api/securityGuard
        [HttpPost]
        public IHttpActionResult CreateSecurityGuard(ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var unit = Mapper.Map<ApartmentDto, Apartment>(apartmentDto);
            _context.Apartment.Add(unit);
            _context.SaveChanges();

            apartmentDto.Id = unit.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + unit.Id), apartmentDto);
        }
        // PUT /api/securityGuard/1
        [HttpPut]
        public void UpdateSecurityGuard(int id, SecurityGuardDto securityGuardDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedGuard = _context.SecurityGuard.SingleOrDefault(c => c.Id == id);

            if (selectedGuard == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(securityGuardDto, selectedGuard);

            _context.SaveChanges();
        }
        //DELETE api/securityGuard/1
        [HttpDelete]
        public void DeleteSecurityGuard(int id)
        {
            var selectedGuard = _context.SecurityGuard.SingleOrDefault(c => c.Id == id);

            if (selectedGuard == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SecurityGuard.Remove(selectedGuard);
            _context.SaveChanges();

        }

    }

}
