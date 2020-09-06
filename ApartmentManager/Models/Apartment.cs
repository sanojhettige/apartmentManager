namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public int OwnerId { get; set; }

        public int FloorNo { get; set; }

        public int UnitNo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
