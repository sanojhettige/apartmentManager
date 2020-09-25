namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Property Name")]
        [Required]
        [StringLength(100)]
        public string PropertyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(?:7|0|(?:\+94))[1-9]{2}[0-9]{7,8}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Fax Number")]
        [RegularExpression(@"^(?:7|0|(?:\+94))[1-9]{2}[0-9]{7,8}$", ErrorMessage = "Not a valid phone number")]
        public string FaxNumber { get; set; }

        [Required]
        [Display(Name = "Number of Floors")]
        [Range(1, 999)]
        public int NumFloors { get; set; }

        [Required]
        [Display(Name = "Number of Units")]
        [Range(1, 9999)]
        public int NumUnits { get; set; }

        [Display(Name = "Poll Exists")]
        public bool PoolExists { get; set; }

        [Display(Name = "Gym Exists")]
        public bool GymExists { get; set; }

        [Display(Name = "Other Facilities")]
        public string OtherAmenities { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
