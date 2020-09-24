using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ApartmentManager.Models
{
    public class SecurityGuard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Property Property { get; set; }

        [Required]
        [Display(Name = "Property Name")]
        public int? PropertyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "NIC No")]
        [RegularExpression(@"^([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Not a valid NIC number")]
        public string NicNo { get; set; }

        [Required]
        [RegularExpression(@"^(?:7|0|(?:\+94))[1-9]{2}[0-9]{7,8}$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}