namespace ApartmentManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tenent
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string NicNo { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime TenentFrom { get; set; }

        public DateTime TenentTo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int Status { get; set; }
    }
}
