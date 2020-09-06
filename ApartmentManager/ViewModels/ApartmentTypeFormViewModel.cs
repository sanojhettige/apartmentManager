using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class ApartmentTypeFormViewModel
    {
        public ApartmentType ApartmentType { get; set; }
        public string Title
        {
            get
            {
                if (ApartmentType != null && ApartmentType.Id != 0)


                    return "Edit Apartment Type";

                return "New Apartment Type";
            }
        }
    }
}