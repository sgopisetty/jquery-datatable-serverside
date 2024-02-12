using System.Web;
using System.Web.Mvc;

namespace jquery_datatable_serverside
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
