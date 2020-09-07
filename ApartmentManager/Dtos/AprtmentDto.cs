using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApartmentManager.Dtos
{
    public class ApartmentDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "please select apartment")]
        public int PropertyId { get; set; }

        public PropertyDto Property { get; set; }

        [Required(ErrorMessage = "please select owner")]
        public int OwnerId { get; set; }
        public OwnerDto Owner { get; set; }

        [Required(ErrorMessage = "please select type")]
        public int ApartmentTypeId { get; set; }

        public ApartmentTypeDto Category { get; set; }

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