﻿using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class DatoTablaBasicaRepositorio
    {
        public List<DatoTablaBasica> ObtenerPorTabla(int tablaBasicaId)
        {
            List<DatoTablaBasica> lista = new List<DatoTablaBasica>();

            try
            {
                using (Repositorio db = new Repositorio())
                {
                    lista = db.DatosTablasBasicas.Where(m => m.TablaBasicaId == tablaBasicaId).ToList();
                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return lista;
        }



    }
}
