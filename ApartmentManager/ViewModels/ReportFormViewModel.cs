using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentManager.ViewModels
{
    public class ReportFormViewModel
    {
        public IEnumerable<Owner> Owners { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }

        public IEnumerable<Property> Properties { get; set; }

        public MaintenanceInvoice MaintenanceInvoice { get; set; }

        [Display(Name = "Property")]
        [StringLength(15)]
        public string PropertyId { get; set; }

        [Display(Name = "Apartment")]
        [StringLength(15)]
        public string ApartmentId { get; set; }

        [Display(Name = "Owner")]
        [StringLength(15)]
        public string OwnerId { get; set; }
    }
}