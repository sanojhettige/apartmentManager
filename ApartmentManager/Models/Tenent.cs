namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tenent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "NIC No")]
        [StringLength(20)]
        [RegularExpression(@"^([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Not a valid NIC number")]
        public string NicNo { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(?:7|0|(?:\+94))[1-9]{2}[0-9]{7,8}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
