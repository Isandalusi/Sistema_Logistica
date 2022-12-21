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
    public class N_Entrada_Productos
    {
        public static DataTable Listado_ep(string Texto)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_ep(Texto);
        }
        public static DataTable Listado_detalle_ep(int Codigo)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_detalle_ep(Codigo);
        }

        public static string Guardar_ep(E_Entrada_Productos oEp,DataTable table)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Guardar_ep(oEp,table);
        }

        public static string Eliminar_ep(int codigo_ep)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Eliminar_ep(codigo_ep);
        }

        public static DataTable Listado_tde_ep()
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_tde_ep();
        }

        public static DataTable Listado_al_ep()
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_al_ep();
        }

        public static DataTable Listado_pv_ep(string Texto)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_pv_ep(Texto);
        }

        public static DataTable Listado_pr_ep(string Texto)
        {
            M_Entrada_Productos Datos = new M_Entrada_Productos();
            return Datos.Listado_pr_ep(Texto);
        }

    }
}
