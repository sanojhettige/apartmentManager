using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class ReportFormViewModel
    {
        public IEnumerable<Owner> Owners { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }

        public MaintenanceInvoice MaintenanceInvoice { get; set; }
    }
}