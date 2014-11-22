﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Datos
{
    public class ParametrizacionRepositorio
    {
        public string Obtener(string llave)
        {
            string valor = string.Empty;

            using (var db = new Repositorio())
            {
                valor = db.Parametrizaciones
                    .Where(p => p.Llave.Equals(llave))
                    .FirstOrDefault().Valor;
            }

            return valor;
        }
    }
}