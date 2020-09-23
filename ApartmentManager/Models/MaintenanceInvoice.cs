using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ApartmentManager.Models
{
    public class MaintenanceInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Apartment Apartment { get; set; }

        [Required]
        [Display(Name = "Apartment Name")]
        public int ApartmentId { get; set; }

        [Display(Name = "Month")]
        public string MonthId { get; set; }

        [Display(Name = "Maintenance Cost")]
        [Range(1, 99999)]
        public decimal MaintenanceCost { get; set; }

        [Display(Name = "Electricity Units")]
        [Range(0, 9999)]
        public decimal ElectricityUnits { get; set; }

        [Display(Name = "Electricity Cost")]
        [Range(0, 99999)]
        public decimal ElectricityCost { get; set; }

        [Display(Name = "Water Units")]
        [Range(0, 999)]
        public decimal WaterUnits { get; set; }

        [Display(Name = "Water Cost")]
        [Range(0, 99999)]
        public decimal WaterCost { get; set; }

        [Display(Name = "Gas Units")]
        [Range(0, 999)]
        public decimal GasUnits { get; set; }

        [Display(Name = "Gas Cost")]
        [Range(0, 99999)]
        public decimal GasCost { get; set; }

        [Display(Name = "Other Cost")]
        [Range(0, 99999)]
        public decimal OtherCost { get; set; }

        [Display(Name = "Other Notes")]
        public string OtherNotes { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }




    }
}