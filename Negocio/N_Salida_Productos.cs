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
    public class N_Salida_Productos
    {
        public static DataTable Listado_sp(string Texto)
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Listado_sp(Texto);
        }
        public static DataTable Listado_detalle_sp(int Codigo)
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Listado_detalle_sp(Codigo);
        }

        public static string Guardar_sp(E_Salida_Productos oSp, DataTable table)
        {
            M_Salida_Productos Datos = new M_Salida_Productos(); ;
            return Datos.Guardar_sp(oSp, table);
        }

        public static string Eliminar_sp(int codigo_sp)
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Eliminar_sp(codigo_sp);
        }

        public static DataTable Listado_tde_sp()
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Listado_tde_sp();
        }


        public static DataTable Listado_cl_sp(string Texto)
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Listado_cl_sp(Texto);
        }

        public static DataTable Listado_pr_sp(string Texto)
        {
            M_Salida_Productos Datos = new M_Salida_Productos();
            return Datos.Listado_pr_sp(Texto);
        }
    }
}
