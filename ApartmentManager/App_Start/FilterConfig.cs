using System.Web;
using System.Web.Mvc;

namespace ApartmentManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

            //limit acces to the app to only a secure connection channel https://
            filters.Add(new RequireHttpsAttribute());


        }
    }
}
