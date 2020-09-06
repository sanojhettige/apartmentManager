using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter square feets")]
        public int SquareFeets { get; set; }

        [Required(ErrorMessage = "please enter maintenance charge")]
        public decimal MaintenanceCharge { get; set; }

        [Required(ErrorMessage = "please select number of rooms")]
        public int NumRooms { get; set; }

        [Required(ErrorMessage = "please select number of bath rooms")]
        public int NumBathRooms { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}