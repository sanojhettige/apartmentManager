namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApartmentType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Square Feets")]
        public int SquareFeets { get; set; }

        [Display(Name = "Monthly Maintenance Charge")]
        public decimal MaintenanceCharge { get; set; }

        [Display(Name = "Num. of Rooms")]
        public int NumRooms { get; set; }

        [Display(Name = "Num. of Bathrooms")]
        public int NumBathRooms { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
