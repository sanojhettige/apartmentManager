using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.Dtos
{
    public class ApartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please select apartment")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "please select owner")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "please enter floor number")]
        public int FloorNo { get; set; }

        [Required(ErrorMessage = "please enter unit number")]
        public int UnitNo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }

    }
}