using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class TenentFormViewModel
    {
        public IEnumerable<Apartment> Apartments { get; set; }
        public Tenent Tenent { get; set; }
        public string Title
        {
            get
            {
                if (Tenent != null && Tenent.Id != 0)


                    return "Edit Tenent";

                return "New Tenent";
            }
        }
    }
}