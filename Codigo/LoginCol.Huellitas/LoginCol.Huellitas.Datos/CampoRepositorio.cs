﻿using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LoginCol.Huellitas.Utilidades;

namespace LoginCol.Huellitas.Datos
{
    public class CampoRepositorio
    {
        public Campo Obtener(int idCampo)
        {
            Campo campo = null;

            try
            {
                using (var db = new Repositorio())
                {
                    campo = db.Campos
                        .Include(c => c.Opciones)
                        .FirstOrDefault(c => c.CampoId == idCampo);

                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }
            

            return campo == null ? new Campo() : campo;
        }


        public Campo Obtener(string nombreCampo)
        {
            Campo campo = null;

            try
            {
                using (var db = new Repositorio())
                {
                    campo = db.Campos
                        .Include(c => c.Opciones)
                        .FirstOrDefault(c => c.Nombre.Equals(nombreCampo));

                }
            }
            catch (Exception e)
            {
                LogErrores.RegistrarError(e);
            }

            return campo == null ? new Campo() : campo;
        }
    }
}
