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

        [Range(1, 99999)]
        public decimal MaintenanceCost { get; set; }

        [Range(1, 9999)]
        public decimal ElectricityUnits { get; set; }
        [Range(1, 99999)]
        public decimal ElectricityCost { get; set; }

        [Range(1, 999)]
        public decimal WaterUnits { get; set; }

        [Range(1, 99999)]
        public decimal WaterCost { get; set; }

        [Range(1, 999)]
        public decimal GasUnits { get; set; }

        [Range(1, 99999)]
        public decimal GasCost { get; set; }

        [Range(1, 99999)]
        public decimal OtherCost { get; set; }

        public string OtherNotes { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }




    }
}