namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Property Property { get; set; }

        [Required]
        [Display(Name = "Property Name")]
        public int PropertyId { get; set; }

        public Owner Owner { get; set; }

        [Display(Name = "Owner Name")]
        public int OwnerId { get; set; }

        public Tenent Tenent { get; set; }

        [Display(Name = "Tenent Name")]
        public int TenentId { get; set; }


        [Display(Name = "Apartment Type")]
        public int ApartmentTypeId { get; set; }

        public ApartmentType ApartmentType { get; set; }

        [Display(Name = "Floor No")]
        [Range(1, 999)]
        public int FloorNo { get; set; }

        [Display(Name = "Unit No")]
        [Range(1, 9999)]
        public int UnitNo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
