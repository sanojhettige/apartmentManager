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
    public class ApartmentController : ApiController
    {
        private ApplicationDbContext _context;

        public ApartmentController()
        {
            _context = new ApplicationDbContext();
        }
 

        //GET /api/apartment/1
        public IEnumerable<ApartmentDto> GetApartment(int id)
        {
            var unitsQuery = _context.Apartment
                .Include(m => m.Owner)
                .Include(m => m.Tenent)
                .Where(m => m.Status != 4);

            if (id > 0)
                unitsQuery = unitsQuery.Where(m => m.PropertyId == id);

            return unitsQuery
                .ToList()
                .Select(Mapper.Map<Apartment, ApartmentDto>);
        }

        //GET /api/apartment
        public IEnumerable<ApartmentDto> GetApartments(string query = null)
        {
            var unitsQuery = _context.Apartment
                .Include(m => m.Owner)
                .Include(m => m.Tenent)
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                unitsQuery = unitsQuery.Where(m => m.PropertyId == 2);

            return unitsQuery
                .ToList()
                .Select(Mapper.Map<Apartment, ApartmentDto>);
        }

        // POST /api/apartment
        [HttpPost]
        public IHttpActionResult CreateApartment(ApartmentDto apartmentDto)
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
        // PUT /api/apartment/1
        [HttpPut]
        public void UpdateApartment(int id, ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedApartment = _context.Apartment.SingleOrDefault(c => c.Id == id);

            if (selectedApartment == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(apartmentDto, selectedApartment);

            _context.SaveChanges();
        }
        //DELETE api/apartment/1
        [HttpDelete]
        public IHttpActionResult DeleteApartment(int id)
        {
            var selectedApartment = _context.Apartment.SingleOrDefault(c => c.Id == id);

            if (selectedApartment == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Apartment.Remove(selectedApartment);
            _context.SaveChanges();
            return Ok(selectedApartment);

        }

    }

}
