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
    public class N__Proveedores
    {
        public static DataTable Listado_pv(string Texto)
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Listado_pv(Texto);
        }

        public static string Guardar_pv(int nOpcion, E_Proveedores oPv)
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Guardar_pv(nOpcion, oPv);
        }

        public static string Eliminar_pv(int codigo_pv)
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Eliminar_pv(codigo_pv);
        }

        public static DataTable Listado_td_pv()
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Listado_td_pv();
        }

        public static DataTable Listado_sx_pv()
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Listado_sx_pv();
        }

        public static DataTable Listado_ru_pv(string Texto)
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Listado_ru_pv(Texto);
        }

        public static DataTable Listado_ci_pv(string Texto)
        {
            M_Proveedores Datos = new M_Proveedores();
            return Datos.Listado_ci_pv(Texto);
        }

    }
}
