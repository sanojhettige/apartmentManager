﻿using AutoMapper;
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
            //return _context.Users
            // .Where(m => m.Id != "4").ToList();

            return _context.Users
                .Include(u => u.Roles)
                //.Include(p => p.PropertyId)
                .ToList();
  
        }

    }

}
