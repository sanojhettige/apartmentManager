using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;


namespace ApartmentManager.ViewModels
{
    public class OwnerFormViewModel
    {
        public Owner Owner { get; set; }
        public string Title
        {
            get
            {
                if (Owner != null && Owner.Id != 0)


                    return "Edit Owner";

                return "New Owner";
            }
        }
    }
}