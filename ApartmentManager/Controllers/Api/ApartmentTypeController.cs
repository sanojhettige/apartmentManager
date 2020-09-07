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
    public class ApartmentTypeController : ApiController
    {
        private ApplicationDbContext _context;

        public ApartmentTypeController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/apartmentType
        public IHttpActionResult GetApartmentType(int id)
        {
            var apartmentType = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (apartmentType == null)
                return NotFound();

            return Ok(Mapper.Map<ApartmentType, ApartmentTypeDto>(apartmentType));
        }

        //GET /api/apartmentType/1
        public IEnumerable<ApartmentTypeDto> GetApartmentTypes(string query = null)
        {
            var aptQuery = _context.ApartmentType
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                aptQuery = aptQuery.Where(m => m.Name.Contains(query));

            return aptQuery
                .ToList()
                .Select(Mapper.Map<ApartmentType, ApartmentTypeDto>);
        }
        // POST /api/apartmentType
        [HttpPost]
        public IHttpActionResult CreateApartmentType(ApartmentTypeDto aptTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var aptType = Mapper.Map<ApartmentTypeDto, ApartmentType>(aptTypeDto);
            _context.ApartmentType.Add(aptType);
            _context.SaveChanges();

            aptTypeDto.Id = aptType.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + aptType.Id), aptTypeDto);
        }
        // PUT /api/apartmentType/1
        [HttpPut]
        public void UpdateApartmentType(int id, ApartmentTypeDto aptTypeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedAptType = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (selectedAptType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(aptTypeDto, selectedAptType);

            _context.SaveChanges();
        }
        //DELETE api/apartmentType/1
        [HttpDelete]
        public void DeleteApartmentType(int id)
        {
            var selectedAptType = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (selectedAptType == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ApartmentType.Remove(selectedAptType);
            _context.SaveChanges();

        }

    }

}
