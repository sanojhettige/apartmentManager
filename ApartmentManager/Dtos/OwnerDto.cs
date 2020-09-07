using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApartmentManager.Dtos
{
    public class OwnerDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter Nic No")]
        [StringLength(20)]
        public string NicNo { get; set; }

        [Required(ErrorMessage = "please enter phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "please enter email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}