using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.Dtos
{
    public class PropertyDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter property name")]
        [StringLength(100)]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "please enter property address")]
        [StringLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "please enter property phone number")]
        [StringLength(33)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "please enter property email address")]
        [StringLength(150)]
        public string EmailAddress { get; set; }
        [StringLength(150)]
        public string FaxNumber { get; set; }

        public int NumFloors { get; set; }

        public int NumUnits { get; set; }

        public bool PoolExists { get; set; }

        public bool GymExists { get; set; }

        public string OtherAmenities { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }

    }
}