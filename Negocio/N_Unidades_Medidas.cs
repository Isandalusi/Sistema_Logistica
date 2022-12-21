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
    public class N_Unidades_Medidas
    {
        public static DataTable Listado_um(string Texto)
        {
            M_Unidades_Medidas Datos = new M_Unidades_Medidas();
            return Datos.Listado_um(Texto);
        }

        public static string Guardar_um(int nOpcion, E_Unidades_Medidas oUm)
        {
            M_Unidades_Medidas Datos = new M_Unidades_Medidas();
            return Datos.Guartdar_um(nOpcion, oUm);
        }

        public static string Eliminar_um(int codigo_um)
        {
            M_Unidades_Medidas Datos = new M_Unidades_Medidas();
            return Datos.Eliminar_um(codigo_um);
        }
    }
}
