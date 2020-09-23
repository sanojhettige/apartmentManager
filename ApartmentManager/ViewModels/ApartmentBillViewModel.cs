using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;

namespace ApartmentManager.ViewModels
{
    public class ApartmentBillViewModel
    {
        public MaintenanceInvoice MaintenanceInvoice { get; set; }
        public string Title
        {
            get
            {
                if (MaintenanceInvoice != null && MaintenanceInvoice.Id != 0)


                    return "Edit Invoice";

                return "New Invoice";
            }
        }
    }
}