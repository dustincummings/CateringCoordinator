using System.Web;
using System.Web.Mvc;

namespace Catering_Coodinator.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
