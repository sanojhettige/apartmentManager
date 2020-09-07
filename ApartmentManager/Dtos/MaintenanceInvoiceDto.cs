using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApartmentManager.Dtos
{
    public class MaintenanceInvoiceDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ApartmentDto Apartment { get; set; }

        [Required(ErrorMessage = "please select apartment")]
        public int ApartmentId { get; set; }

        [Required(ErrorMessage = "please select month")]
        public string MonthId { get; set; }

        [Required(ErrorMessage = "please enter maintenance cost")]
        public decimal MaintenanceCost { get; set; }

        [Required(ErrorMessage = "please enter electricity cost")]
        public decimal ElectricityUnits { get; set; }
        public decimal ElectricityCost { get; set; }

        [Required(ErrorMessage = "please enter water cost")]
        public decimal WaterUnits { get; set; }
        public decimal WaterCost { get; set; }

        [Required(ErrorMessage = "please enter lp gas cost")]
        public decimal GasUnits { get; set; }

        public decimal GasCost { get; set; }
        public decimal OtherCost { get; set; }

        public string OtherNotes { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}