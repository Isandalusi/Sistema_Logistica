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
    public class N_Marca
    {
        public static DataTable Listado_ma(string Texto)
        {
            M_Marca Datos = new M_Marca();
            return Datos.Listado_ma(Texto);
        }

        public static string Guardar_ma(int nOpcion, E_Marca oMa)
        {
            M_Marca Datos = new M_Marca();
            return Datos.Guartdar_ma(nOpcion, oMa);
        }

        public static string Eliminar_ma(int codigo_ma)
        {
            M_Marca Datos = new M_Marca();
            return Datos.Eliminar_ma(codigo_ma);
        }
    }
}
