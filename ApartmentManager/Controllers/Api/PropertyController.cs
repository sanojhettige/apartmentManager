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
    public class PropertyController : ApiController
    {
        private  ApplicationDbContext _context;

        public PropertyController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/property/1
        public IHttpActionResult GetProperty(int id)
        {
            var property = _context.Property.SingleOrDefault(c => c.Id == id);

            if (property == null)
                return NotFound();

            return Ok(Mapper.Map<Property, PropertyDto>(property));
        }

        //GET /api/property
        public IEnumerable<PropertyDto> GetProperties(string query = null)
        {
            var propertyQuery = _context.Property
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                propertyQuery = propertyQuery.Where(m => m.PropertyName.Contains(query));

            return propertyQuery
                .ToList()
                .Select(Mapper.Map<Property, PropertyDto>);
        }
        // POST /api/property
        [HttpPost]
        public IHttpActionResult CreateProperty(PropertyDto propertyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var property = Mapper.Map<PropertyDto, Property>(propertyDto);
            _context.Property.Add(property);
            _context.SaveChanges();

            propertyDto.Id = property.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + property.Id), propertyDto);
        }
        // PUT /api/property/1
        [HttpPut]
        public void UpdateProperty(int id, PropertyDto propertyDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedProperty = _context.Property.SingleOrDefault(c => c.Id == id);

            if (selectedProperty == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(propertyDto, selectedProperty);

            _context.SaveChanges();
        }
        //DELETE api/property/1
        [HttpDelete]
        public void DeleteProperty(int id)
        {
            var selectedProperty = _context.Property.SingleOrDefault(c => c.Id == id);

            if (selectedProperty == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Property.Remove(selectedProperty);
            _context.SaveChanges();

        } 

    }

}
