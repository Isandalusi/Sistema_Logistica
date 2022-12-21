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
    public class N_Pais
    {
        public static DataTable Listado_ci(string Texto)
        {
            M_Pais Datos = new M_Pais();
            return Datos.Listado_pa(Texto);
        }

        public static string Guardar_ci(int nOpcion, E_Pais oCi)
        {
            M_Pais Datos = new M_Pais();
            return Datos.Guartdar_pa(nOpcion, oCi);
        }

        public static string Eliminar_ci(int codigo_ci)
        {
            M_Pais Datos = new M_Pais();
            return Datos.Eliminar_pa(codigo_ci);
        }
    }
}
