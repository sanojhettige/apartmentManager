using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class SecurityGuardFormViewModel
    {

        public IEnumerable<Property> Properties { get; set; }
        public SecurityGuard SecurityGuard { get; set; }
        public string Title
        {
            get
            {
                if (SecurityGuard != null && SecurityGuard.Id != 0)


                    return "Edit Guard";

                return "New Guard";
            }
        }
    }
}