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
    public class CategoryController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/category
        public IHttpActionResult GetCategory(int id)
        {
            var category = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            return Ok(Mapper.Map<ApartmentType, CategoryDto>(category));
        }

        //GET /api/category/1
        public IEnumerable<CategoryDto> GetCategories(string query = null)
        {
            var catQuery = _context.ApartmentType
                .Where(m => m.Status != 4);

            if (!String.IsNullOrWhiteSpace(query))
                catQuery = catQuery.Where(m => m.Name.Contains(query));

            return catQuery
                .ToList()
                .Select(Mapper.Map<ApartmentType, CategoryDto>);
        }
        // POST /api/category
        [HttpPost]
        public IHttpActionResult CreateOwner(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var category = Mapper.Map<CategoryDto, ApartmentType>(categoryDto);
            _context.ApartmentType.Add(category);
            _context.SaveChanges();

            categoryDto.Id = category.Id;

            //use 
            return Created(new Uri(Request.RequestUri + "/" + category.Id), categoryDto);
        }
        // PUT /api/category/1
        [HttpPut]
        public void UpdateCategory(int id, OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var selectedCategory = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (selectedCategory == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(ownerDto, selectedCategory);

            _context.SaveChanges();
        }
        //DELETE api/category/1
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var selectedCategory = _context.ApartmentType.SingleOrDefault(c => c.Id == id);

            if (selectedCategory == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ApartmentType.Remove(selectedCategory);
            _context.SaveChanges();

        }

    }

}
