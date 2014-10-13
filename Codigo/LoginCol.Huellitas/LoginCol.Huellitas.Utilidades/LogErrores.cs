using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class LogErrores
    {
        public static void RegistrarError(string texto, params object[] parametros)
        {
            RegistrarError(string.Format(texto, parametros));
        }

        public static void RegistrarErrorPropiedadesObjeto(string texto, object obj)
        {
            StringBuilder error = new StringBuilder(texto);

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                error.AppendFormat("{0}:{1}\n", propertyInfo.Name, propertyInfo.GetValue(obj, null));
            }

            RegistrarError(error.ToString());
        }

        public static void RegistrarError(string texto)
        {
            // Write the string to a file.
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.Configuration.ConfigurationManager.AppSettings["rutaLog"], true))
            {
                file.WriteLine(string.Format("{0} ERROR:{1}", DateTime.Now, texto));

                file.Close();
            }

        }

        public static void RegistrarError(Exception e)
        {

            // Get stack trace for the exception with source file information
            var st = new StackTrace(e, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();

            RegistrarError("Error: {0} \n\t StackTrace: {1} \n\t InnerException: {2} \n\t Linea: {3}", e.Message, e.StackTrace, e.InnerException, line);
        }
    }
}
