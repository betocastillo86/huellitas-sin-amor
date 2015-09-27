using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public static class MvcExtensions
    {
        public static string ObtenerTodosLosErroresDeModelState(this System.Web.Http.ModelBinding.ModelStateDictionary modelState)
        {
            var strErrores = new StringBuilder();

            foreach (var model in modelState.Values)
            {
                foreach (var error in model.Errors)
                {
                    strErrores.AppendLine(error.ErrorMessage);
                }
            }

            return strErrores.ToString();
        }

    }
}