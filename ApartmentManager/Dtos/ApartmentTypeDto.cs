using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.Dtos
{
    public class ApartmentTypeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        public int SqurareFeets { get; set; }

        public decimal MaintenanceCharge { get; set; }

        public int NumRooms { get; set; }

        public int NumBathRooms { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}