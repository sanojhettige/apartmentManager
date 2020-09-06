namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string FaxNumber { get; set; }

        public int NumFloors { get; set; }

        public int NumUnits { get; set; }

        public bool PoolExists { get; set; }

        public bool GymExists { get; set; }

        public string OtherAmenities { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
