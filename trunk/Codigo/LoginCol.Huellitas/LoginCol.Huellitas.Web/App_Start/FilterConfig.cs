using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new LocalizationAttribute());
        }
    }


    //public class LocalizationAttribute : AuthorizeAttribute
    //{
    //    //public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    //{
    //    //    base.OnActionExecuting(filterContext);
    //    //}

    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        base.OnAuthorization(filterContext);
    //    }
    //}


}