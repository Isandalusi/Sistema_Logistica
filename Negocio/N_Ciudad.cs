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
     public class N_Ciudad
    {
        public static DataTable Listado_ci(string Texto)
        {
            M_Ciudad Datos = new M_Ciudad();
            return Datos.Listado_ci(Texto);
        }

        public static string Guardar_ci(int nOpcion, E_Ciudad oCi)
        {
            M_Ciudad Datos = new M_Ciudad();
            return Datos.Guartdar_ci(nOpcion, oCi);
        }

        public static string Eliminar_ci(int codigo_ci)
        {
            M_Ciudad Datos = new M_Ciudad();
            return Datos.Eliminar_ci(codigo_ci);
        }
        public static DataTable Listado_po_ci(string Texto)
        {
            M_Ciudad Datos = new M_Ciudad();
            return Datos.Listado_po_ci(Texto);
        }
    }
}
