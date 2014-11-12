using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoginCol.Huellitas.Web.Infraestructure
{
    public class CookiesManager : IDisposable
    {

        private HttpContextBase Context { get; set; }
        public CookiesManager(HttpContextBase context)
        {
            this.Context = context;
        }


        private HttpCookie _cookie;
        private HttpCookie CookieContenidosVisitados { 
            get {
                
                _cookie = _cookie ?? Context.Request.Cookies.Get("huellitas.contenidosVisitados");

                if (_cookie == null)
                {
                    _cookie = new HttpCookie("huellitas.contenidosVisitados", string.Empty);
                }
                    
                return _cookie;
            }
        }
        
        public List<string> ContenidosVisitados { 
            get { 
                    HttpCookie cookie = this.CookieContenidosVisitados;
                    return cookie.Value.Split(new char[]{','}).ToList();
            } 

            private set {
                StringBuilder strBuilder = new StringBuilder();
                value.ForEach( c=> strBuilder.AppendFormat("{0}{1}", strBuilder.Length == 0 ? string.Empty : ",", c));
                _cookie.Value = strBuilder.ToString();
                Context.Response.Cookies.Add(_cookie);
            }
        }

        /// <summary>
        /// Agrega a la cookie el contenido visiado. Retorna true si el contenido fue agregado. Retorna false si ya exisia y no lo agrega
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AgregarContenidoVisitado(string id)
        {
            bool agregado = false;
            List<string> lista = this.ContenidosVisitados;
            if (!lista.Contains(id))
            {
                lista.Add(id);
                this.ContenidosVisitados = lista;
                agregado = true;
            }

            return agregado;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}