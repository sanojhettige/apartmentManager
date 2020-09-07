namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApartmentType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Square Feets")]
        [Range(1, 9999)]
        public int SquareFeets { get; set; }

        [Display(Name = "Monthly Maintenance Charge")]
        [Range(1, 99999)]
        public decimal MaintenanceCharge { get; set; }

        [Display(Name = "Num. of Rooms")]
        [Range(1, 9)]
        public int NumRooms { get; set; }

        [Display(Name = "Num. of Bathrooms")]
        [Range(1, 9)]
        public int NumBathRooms { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
