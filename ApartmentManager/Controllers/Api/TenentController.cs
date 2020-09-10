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
    public class TenentController : ApiController
    {
        private ApplicationDbContext _context;

        public TenentController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/tenent/1
        public IHttpActionResult GetTenent(int id)
        {
            var tenent = _context.Tenent.SingleOrDefault(c => c.Id == id);

            if (tenent == null)
                return NotFound();

            return Ok(Mapper.Map<Tenent, TenentDto>(tenent));
        }

        //GET /api/tenent
        public IEnumerable<TenentDto> GetTenents(string query = null)
        {
            var tenentQuery = _context.Tenent
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                tenentQuery = tenentQuery.Where(m => m.Name.Contains(query));

            return tenentQuery
                .ToList()
                .Select(Mapper.Map<Tenent, TenentDto>);
        }
        // POST /api/tenent
        [HttpPost]
        public IHttpActionResult CreateTenent(TenentDto tenentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var tenent = Mapper.Map<TenentDto, Tenent>(tenentDto);
            _context.Tenent.Add(tenent);
            _context.SaveChanges();

            tenentDto.Id = tenent.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + tenent.Id), tenentDto);
        }
        // PUT /api/tenent/1
        [HttpPut]
        public void UpdateTenent(int id, TenentDto tenentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedTenent = _context.Property.SingleOrDefault(c => c.Id == id);

            if (selectedTenent == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(tenentDto, selectedTenent);

            _context.SaveChanges();
        }
        //DELETE api/tenent/1
        [HttpDelete]
        public void Delete(int id)
        {
            var selectedTenent = _context.Tenent.SingleOrDefault(c => c.Id == id);

            if (selectedTenent == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Tenent.Remove(selectedTenent);
            _context.SaveChanges();

        }

    }

}
