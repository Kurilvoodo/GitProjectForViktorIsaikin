using System.Web.Mvc;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}