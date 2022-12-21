using Entidades;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Rubro
    {

        public static DataTable Listado_ru(string Texto)
        {
            M_Rubros Datos = new M_Rubros();
            return Datos.Listado_ru(Texto);
        }

        public static string Guardar_ru(int nOpcion, E_Rubros oRu)
        {
            M_Rubros Datos = new M_Rubros();
            return Datos.Guartdar_ru(nOpcion, oRu);
        }

        public static string Eliminar_ru(int codigo_ru)
        {
            M_Rubros Datos = new M_Rubros();
            return Datos.Eliminar_ru(codigo_ru);
        }
    }
}
