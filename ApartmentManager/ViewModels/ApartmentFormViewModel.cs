using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class ApartmentFormViewModel
    {
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Tenent> Tenents { get; set; }
        public IEnumerable<ApartmentType> ApartmentTypes { get; set; }
        public Apartment Apartment { get; set; }
        public string Title
        {
            get
            {
                if (Apartment != null && Apartment.Id != 0)


                    return "Edit Apartment";

                return "New Apartment";
            }
        }
    }
}