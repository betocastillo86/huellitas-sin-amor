using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public enum TipoContenidoEnum : int
    { 
        Imagen = 1,
        Animal = 2,
        Fundacion = 3,
        Perro = 4,
        Gato = 5,
        AnimalesPerdidosPadre = 8,
        AnimalesPerdidos = 10,
        AnimalesEncontrados = 9
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

    public enum TablasBasicasEnum
    {
        EstadoCivil = 1,
        Ocupacion = 2,
        PreguntaAdopcion = 3,
        RazasPerros = 4,
        RazasGatos = 5
    }

    public enum TipoDatoCampo
    {
        Int = 1,
        Bit = 2,
        Varchar = 3,

        [Description("Tabla configurada para relacionar los campos")]
        Relacional = 4,
        [Description("Consulta SQl que trae clave y valor para relacionar")]
        ConsultaSql = 5,
        [Description("Multiples valores posibles para el campo")]
        Multiple = 6,
        [Description("Se relaciona con datos tablas basicas")]
        TablaBasica = 7

    }

    public enum TipoRelacionUsuariosEnum
    { 
        Adoptante = 1,
        Padrino = 2
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
