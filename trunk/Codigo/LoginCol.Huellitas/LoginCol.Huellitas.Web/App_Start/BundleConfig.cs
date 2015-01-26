using System.Web;
using System.Web.Optimization;

namespace LoginCol.Huellitas.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Generales
            //Carga exclusivamente los archivos de backbone basico con underscore
            bundles.Add(new ScriptBundle("~/bundles/backbone").Include(
                "~/Scripts/libs/json2.js",
                "~/Scripts/libs/underscore.js",
                "~/Scripts/libs/backbone.js"
                ));

            //Carga las validaciones de backbone
            bundles.Add(new ScriptBundle("~/bundles/backbonevalidation").Include(
                "~/Scripts/libs/backbone-validation.js",
                "~/Scripts/libs/backbone.stickit.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/libs/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/libs/jquery.unobtrusive*",
                        "~/Scripts/libs/jquery.validate*"));

            //ELIMINAR -> Solo para admin
            bundles.Add(new ScriptBundle("~/bundles/huellitas")
                .Include("~/Scripts/huellitas.general.js"));

            bundles.Add(new ScriptBundle("~/bundles/slide").Include(
                "~/Scripts/libs/jquery.cbpFWSlider.js"));

            bundles.Add(new ScriptBundle("~/bundles/scroll")
                .Include("~/Scripts/libs/jquery.mCustomScrollbar.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-*"));

            //para errores ---> Hay que pasar a otro css
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/site.css"));


            bundles.Add(new StyleBundle("~/bundles/cssfrontend")
                .Include("~/Content/normalize.css")
                .Include("~/Content/columnas_scrollbar_slider.css")
                .Include("~/Content/style.css")
                .Include("~/Content/animate.css"));


            bundles.Add(new ScriptBundle("~/bundles/menuEfecto")
                .Include("~/Scripts/libs/modernizr_menu.js")
                .Include("~/Scripts/libs/jquery.stellar.js") //Efecto de menu
                .Include("~/Scripts/libs/waypoints.js") //anclas Julian
                .Include("~/Scripts/libs/menu.js")
                //.Include("~/Scripts/libs/jquery.jscroll.js")
                .Include("~/Scripts/libs/jquery.easing.1.3.js") //Efectos 
                //.Include("~/Scripts/libs/huellitas.front.init.js")
                //.Include("~/Scripts/libs/TrafficCop.js")
                );


            bundles.Add(new StyleBundle("~/bundles/cssjqueryui").Include(
                        "~/Content/themes/base/jquery-ui.css"
                        //"~/Content/themes/base/jquery.ui.resizable.css",
                        //"~/Content/themes/base/jquery.ui.selectable.css",
                        //"~/Content/themes/base/jquery.ui.accordion.css",
                        //"~/Content/themes/base/jquery.ui.autocomplete.css",
                        //"~/Content/themes/base/jquery.ui.button.css",
                        //"~/Content/themes/base/jquery.ui.dialog.css",
                        //"~/Content/themes/base/jquery.ui.slider.css",
                        //"~/Content/themes/base/jquery.ui.tabs.css",
                        //"~/Content/themes/base/jquery.ui.datepicker.css",
                        //"~/Content/themes/base/jquery.ui.progressbar.css",
                        //"~/Content/themes/base/jquery.ui.theme.css"
                        ));
            #endregion

            #region Admin
            //Librerias adicionales del template charisma
            bundles.Add(new ScriptBundle("~/bundles/jqueryTemplate").
                Include(
                "~/Scripts/libs/jquery.cookie.js",
                "~/Scripts/libs/jquery.dataTables.js",
                                "~/Scripts/libs/jquery.raty.js",
                                "~/Scripts/libs/jquery.iphone.toggle.js",
                                "~/Scripts/libs/jquery.autogrow-textarea.js",
                                "~/Scripts/libs/jquery.uploadify-3.1.js",
                                "~/Scripts/libs/jquery.history.js",
                                "~/Scripts/libs/charisma.js",
                                "~/Scripts/libs/jquery.noty.js",
                                "~/Scripts/libs/responsive-tables.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/libs/bootstrap.js",
                    "~/Scripts/libs/bootstrap-tour.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                    "~/Scripts/libs/moment/moment.js",
                    "~/Scripts/libs/fullcalendar/fullcalendar.js"

                    ));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                    "~/Scripts/libs/chosen/chosen.jquery.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/colorbox").Include(
                    "~/Scripts/libs/colorbox/jquery.colorbox.js"
                    ));

            bundles.Add(new StyleBundle("~/bundles/Admin").Include(
                "~/Content/Admin/charisma-app.css",
                "~/Content/Admin/fullcalendar.css",
                "~/Content/Admin/fullcalendar.print.css",
                "~/Content/Admin/chosen.css",
                "~/Content/Admin/colorbox.css",
                "~/Content/Admin/responsive-tables.css",
                "~/Content/Admin/bootstrap-tour.css",
                "~/Content/Admin/jquery.noty.css",
                "~/Content/Admin/noty_theme_default.css",
                "~/Content/Admin/elfinder.css",
                "~/Content/Admin/elfinder.theme.css",
                "~/Content/Admin/jquery.iphone.toggle.css",
                "~/Content/Admin/uploadify.css",
                "~/Content/Admin/animate.css"));
            #endregion

            #region Backbone
            //Router y base de aplicacion en backbone
            bundles.Add(new ScriptBundle("~/bundles/backbone_router")
                .Include("~/Scripts/huellitas.app.js")
                .Include("~/Scripts/huellitas.router.js"));

            //zonas geograficas
            bundles.Add(new ScriptBundle("~/bundles/backbone_zonasGeograficas")
                .Include("~/Scripts/models/huellitas.ZonaGeografica.js")
                .Include("~/Scripts/views/huellitas.ZonasGeograficasView.js"));
            
            //Contenido Model en Backbone
            bundles.Add(new ScriptBundle("~/bundles/backbone_contenido")
                .Include("~/Scripts/models/huellitas.Contenido.js"));


            //Vista de listar huellitas
            bundles.Add(new ScriptBundle("~/bundles/backbone_lhuellitas")
                .Include("~/Scripts/views/huellitas.ListarHuellitasView.js")
                .Include("~/Scripts/views/huellitas.ResultadosHuellitasView.js"));

            //Vista de listar huellitas
            bundles.Add(new ScriptBundle("~/bundles/backbone_lfundaciones")
                .Include("~/Scripts/views/huellitas.MapaView.js")
                .Include("~/Scripts/views/huellitas.ListarFundacionesView.js")
                .Include("~/Scripts/views/huellitas.ResultadosHuellitasView.js")
                );

            //listado de contenidos con filtros
            bundles.Add(new ScriptBundle("~/bundles/backbone_filtroContenidos")
                .Include("~/Scripts/views/huellitas.ResultadosHuellitasView.js")
                );

            //Carga de archivos por ajax
            bundles.Add(new ScriptBundle("~/bundles/backbone_cargaArchivo")
                    .Include("~/Scripts/models/huellitas.Archivo.js")
                    .Include("~/Scripts/views/huellitas.SubirArchivoView.js")
                );

            //Informacion sobre adopciones
            bundles.Add(new ScriptBundle("~/bundles/backbone_porqueAdoptar")
                    .Include("~/Scripts/views/huellitas.InfoAdoptarView.js")
                );

            //listado de huellitas asociadas a una fundación
            bundles.Add(new ScriptBundle("~/bundles/backbone_huellasFundacion")
                .Include("~/Scripts/views/huellitas.HuellasFundacionView.js"));

            //Huellitas perdidos
            bundles.Add(new ScriptBundle("~/bundles/backbone_perdidos")
                .Include("~/Scripts/models/huellitas.Contenido.js")
                .Include("~/Scripts/views/huellitas.PerdidosView.js")
                .Include("~/Scripts/views/huellitas.ListaPerdidosView.js")
                .Include("~/Scripts/models/huellitas.ContenidoPerdido.js")
                .Include("~/Scripts/views/huellitas.DetallePerdidoView.js")
                .Include("~/Scripts/views/huellitas.SummaryView.js")
                .Include("~/Scripts/models/huellitas.Contacto.js")
                .Include("~/Scripts/models/huellitas.TablaBasica.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/backbone_home")
                .Include("~/Scripts/models/huellitas.Contacto.js")
                .Include("~/Scripts/views/huellitas.ContactoView.js")
                .Include("~/Scripts/views/huellitas.HomeView.js")
                .Include("~/Scripts/libs/jquery.cbpFWSlider.js")
                );

            //Contactanos
            bundles.Add(new ScriptBundle("~/bundles/backbone_contacto")
                .Include("~/Scripts/models/huellitas.Contacto.js")
                .Include("~/Scripts/views/huellitas.ContactoView.js")
                );
            
            //Detalle de la huellita
            bundles.Add(new ScriptBundle("~/bundles/backbone_detalleHuellita")
                .Include("~/Scripts/views/huellitas.DetalleHuellitaView.js"));

            //Detalle de la fundacion
            bundles.Add(new ScriptBundle("~/bundles/backbone_detalleFundacion")
                .Include("~/Scripts/views/huellitas.DetalleFundacionView.js"));

            bundles.Add(new ScriptBundle("~/bundles/backbone_adoptar")
                .Include("~/Scripts/views/huellitas.AdoptarView.js"));

            //Vista del mapa de google
            bundles.Add(new ScriptBundle("~/bundles/backbone_mapa")
                .Include("~/Scripts/views/huellitas.MapaView.js"));

            

            //Comentarios en los contenidos
            bundles.Add(new ScriptBundle("~/bundles/backbone_comentarios")
                .Include("~/Scripts/models/huellitas.Comentario.js")
                .Include("~/Scripts/views/huellitas.ComentariosView.js"));
            
            //Contenidos relacionados
            bundles.Add(new ScriptBundle("~/bundles/backbone_contRelacionados")
                .Include("~/Scripts/models/huellitas.admin.ContenidoRelacionado.js")
                .Include("~/Scripts/views/huellitas.ContenidoRelacionadoView.js"));

            //Contenidos relacionados
            bundles.Add(new ScriptBundle("~/bundles/backbone_redesSociales")
                .Include("~/Scripts/views/huellitas.TwitterShareView.js")
                .Include("~/Scripts/views/huellitas.FacebookShareView.js"));

            //Summary Errores
            bundles.Add(new ScriptBundle("~/bundles/backbone_summary")
                .Include("~/Scripts/views/huellitas.SummaryView.js"));

            //imagenes de los contenidos
            bundles.Add(new ScriptBundle("~/bundles/backbone_imagenes")
                .Include("~/Scripts/models/huellitas.admin.Imagen.js")
                .Include("~/Scripts/views/huellitas.ImagenesContenidoView.js")
                .Include("~/Scripts/libs/jquery.mCustomScrollbar.js"));

            //Principales scripts utilizados en el detalle de un contenido
            bundles.Add(new ScriptBundle("~/bundles/backbone_contenidodetalle")
                .Include("~/Scripts/libs/jquery-ui.js")
                .Include("~/Scripts/models/huellitas.Comentario.js")
                .Include("~/Scripts/views/huellitas.ComentariosView.js")
                .Include("~/Scripts/models/huellitas.admin.ContenidoRelacionado.js")
                .Include("~/Scripts/views/huellitas.ContenidoRelacionadoView.js")
                .Include("~/Scripts/views/huellitas.TwitterShareView.js")
                .Include("~/Scripts/views/huellitas.FacebookShareView.js")
                .Include("~/Scripts/models/huellitas.admin.Imagen.js")
                .Include("~/Scripts/views/huellitas.ImagenesContenidoView.js")
                .Include("~/Scripts/libs/jquery.cbpFWSlider.js")
                .Include("~/Scripts/libs/jquery.mCustomScrollbar.js")
                .Include("~/Scripts/libs/backbone-validation.js")
                .Include("~/Scripts/libs/backbone.stickit.js")
                );


            #endregion

            BundleTable.EnableOptimizations = true;
            #if DEBUG
            BundleTable.EnableOptimizations = false;
            #endif


        }
    }
}