using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public enum TipoContenidoEnum
    { 
        Imagen = 1,
        Animal,
        Fundacion
    }

    public enum TamanoImagenEnum
    { 
        Grande = 1,
        Pequeno = 2,
        Mediano = 3
    }

    public static class EnumConverter
    { 

        public static TamanoImagenEnum ToEnum(this TamanoImagenEnum obj, string strEnum)
        {
            switch (strEnum)
	        {
		        case "mini":
                    return TamanoImagenEnum.Pequeno;
                case "large":
                    return TamanoImagenEnum.Grande;
                case "medium":
                    return TamanoImagenEnum.Mediano;
                default:
                    return TamanoImagenEnum.Pequeno;
	        }
        }
    }

}
