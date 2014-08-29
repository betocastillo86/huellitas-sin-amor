using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LoginCol.Huellitas.Web.HtmlHelpers
{
    public static class HtmlHelperInputExtensions 
    {
        public static MvcHtmlString TextBoxForM<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,  Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "form-control" });
        }


    }
}