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
    public class DuePaymentController : ApiController
    {
        private ApplicationDbContext _context;

        public DuePaymentController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/duePayment
        public IEnumerable<MaintenanceInvoiceDto> GetDuePayment(string query = null)
        {

            var dueQuery = _context.MaintenanceInvoice
                .Include(p => p.Apartment)
                .Where(m => m.Status == 1);

            return dueQuery
                .ToList()
                .Select(Mapper.Map<MaintenanceInvoice, MaintenanceInvoiceDto>);

        }

    }

}
