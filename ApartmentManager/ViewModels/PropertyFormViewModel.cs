using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class PropertyFormViewModel
    {
        public Property Property { get; set; }
        public string Title
        {
            get
            {
                if (Property != null && Property.Id != 0)


                    return "Edit Property";

                return "New Property";
            }
        }
    }
}