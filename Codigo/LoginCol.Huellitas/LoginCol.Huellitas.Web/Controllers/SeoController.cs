using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class SeoController : Controller
    {



        #region Robots
        public ActionResult RobotsTextFile()
        {
            List<string> disallowPaths;
            List<string> localizableDisallowPaths;

            //Solo lo habilita en producción
            bool allowRobots = Request.Url.Host.Contains("huellitas.social");

            //Si debe deshabilitar 
            //deshabilita todos los paths del sitio
            if (!allowRobots)
            {
                disallowPaths = new List<string> { "/" };
                localizableDisallowPaths = new List<string>();
            }
            else
            {
                disallowPaths = new List<string> { "/bin/" };

            }


            const string newLine = "\r\n"; //Environment.NewLine
            var sb = new StringBuilder();
            sb.Append("User-agent: *");
            sb.Append(newLine);

            //localizable paths (without SEO code)
            sb.AppendFormat("Sitemap: {0}sitemap.xml", "http://huellitas.social/");
            sb.Append(newLine);

            //usual paths
            foreach (var path in disallowPaths)
            {
                sb.AppendFormat("Disallow: {0}", path);
                sb.Append(newLine);
            }

            Response.ContentType = "text/plain";
            Response.Write(sb.ToString());
            return null;
        }
        #endregion
        #region Sitemap

        public ActionResult SitemapXml()
        {
            string xml = string.Empty;
            
            using (var stream = new MemoryStream())
            {
                _writer = new XmlTextWriter(stream, Encoding.UTF8);
                _writer.Formatting = Formatting.Indented;
                _writer.WriteStartDocument();
                _writer.WriteStartElement("urlset");
                _writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
                _writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                _writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

                GenerarNodosSiteMap();

                _writer.WriteEndElement();
                _writer.Close();

                xml = Encoding.UTF8.GetString(stream.ToArray());
            }

            return Content(xml, "text/xml");
        }

        private void GenerarNodosSiteMap()
        {
            //home page
            var homePageUrl = Url.Action("Index", "Home");
            WriteUrlLocation(homePageUrl, UpdateFrequency.Weekly, DateTime.UtcNow);
            //fundaciones
            var nContenido = new ContenidoNegocio();
            var fundaciones = nContenido.FiltrarContenidos(Convert.ToInt32(TipoContenidoEnum.Fundacion), true, new Contenido() { Activo = true }, new List<FiltroContenido>(), new List<ContenidoRelacionado>());
            foreach (var fundacion in fundaciones)
            {
                var fundacionUrl = Url.Action("Detalle", "Fundaciones", new { id = fundacion.ContenidoId, nombre = fundacion.NombreLink });
                WriteUrlLocation(fundacionUrl, UpdateFrequency.Weekly, DateTime.UtcNow);
            }
            //Perros
            var animales = nContenido.FiltrarContenidos(Convert.ToInt32(TipoContenidoEnum.Animal), true, new Contenido() { Activo = true }, new List<FiltroContenido>(), new List<ContenidoRelacionado>());
            foreach (var animal in animales)
            {
                var animalUrl = Url.Action("Detalle", "Huellitas", new { id = animal.ContenidoId, nombre = animal.NombreLink });
                WriteUrlLocation(animalUrl, UpdateFrequency.Weekly, DateTime.UtcNow);
            }
        }


        private XmlTextWriter _writer;
        protected virtual void WriteUrlLocation(string url, UpdateFrequency updateFrequency, DateTime lastUpdated)
        {
            _writer.WriteStartElement("url");
            _writer.WriteElementString("loc", "http://huellitas.social"+url);
            _writer.WriteElementString("changefreq", updateFrequency.ToString().ToLowerInvariant());
            _writer.WriteElementString("lastmod", lastUpdated.ToString(@"yyyy-MM-dd"));
            _writer.WriteEndElement();
        }

        public enum UpdateFrequency
        {
            /// <summary>
            /// Always
            /// </summary>
            Always,
            /// <summary>
            /// Hourly
            /// </summary>
            Hourly,
            /// <summary>
            /// Daily
            /// </summary>
            Daily,
            /// <summary>
            /// Weekly
            /// </summary>
            Weekly,
            /// <summary>
            /// Monthly
            /// </summary>
            Monthly,
            /// <summary>
            /// Yearly
            /// </summary>
            Yearly,
            /// <summary>
            /// Never
            /// </summary>
            Never
        }
        #endregion
        
    }
}