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
        Animal = 2,
        Fundacion = 3,
        Perro = 4,
        Gato = 5
    }

    public enum TipoRelacionEnum
    {
        Imagen = 1,
        PerrosEnFundacion=2,
        Fundacion = 3,
        AnimalesSimilares = 4
    }

    public enum TamanoImagenEnum
    { 
        Grande = 1,
        Pequeno = 2,
        Mediano = 3,
        Original = 4
    }

    public static class EnumConverter
    { 

        public static TamanoImagenEnum ToEnum(string strEnum)
        {
            switch (strEnum)
	        {
		        case "mini":
                    return TamanoImagenEnum.Pequeno;
                case "big":
                    return TamanoImagenEnum.Grande;
                case "medium":
                    return TamanoImagenEnum.Mediano;
                default:
                    return TamanoImagenEnum.Pequeno;
	        }
        }
    }

}
