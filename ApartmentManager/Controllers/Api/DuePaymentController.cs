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
using ApartmentManager.ViewModels;

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
        public IEnumerable<MaintenanceInvoiceDto> GetDuePayment(int? Id)
        {
            if(Id > 0)
            {
                var dueQuery = _context.MaintenanceInvoice
                .Include(p => p.Apartment)
                .Where(m => m.Status == 1)
                .Where(m => m.ApartmentId == Id);

                return dueQuery
                .ToList()
                .Select(Mapper.Map<MaintenanceInvoice, MaintenanceInvoiceDto>);

            } else
            {
                var dueQuery = _context.MaintenanceInvoice
                .Include(p => p.Apartment)
                .Where(m => m.Status == 1);

                return dueQuery
                .ToList()
                .Select(Mapper.Map<MaintenanceInvoice, MaintenanceInvoiceDto>);
            }

        }

        //POST: /api/duePayment
        [HttpPost]
        public IEnumerable<MaintenanceInvoiceDto> GetDuePayment(ReportFormViewModel model)
        {
            var apartmentId = model.ApartmentId != "" ? Int32.Parse(model.ApartmentId): 0;
            var propertyId = model.PropertyId != "" ? Int32.Parse(model.PropertyId): 0;
            var ownerId = model.OwnerId != "" ? Int32.Parse(model.OwnerId): 0;
            var dueQuery = _context.MaintenanceInvoice
            .Include(p => p.Apartment)
            .Where(m => m.Status == 1);

            if(apartmentId > 0)
            {
                dueQuery.Where(m => m.ApartmentId == apartmentId);
            }

                return dueQuery
                .ToList()
                .Select(Mapper.Map<MaintenanceInvoice, MaintenanceInvoiceDto>);

        }
    }

}
