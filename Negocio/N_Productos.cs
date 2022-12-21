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
    public class N_Productos
    {

        public static DataTable Listado_pr(string Texto)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Listado_pr(Texto);
        }

        public static string Guardar_pr(int nOpcion, E_Productos oPr)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Guardar_pr(nOpcion, oPr);
        }

        public static string Eliminar_ma(int codigo_pr)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Eliminar_pr(codigo_pr);
        }

        public static DataTable Listado_ma_pr(string Texto)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Listado_ma_pr(Texto);
        }

        public static DataTable Listado_um_pr(string Texto)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Listado_um_pr(Texto);
        }

        public static DataTable Listado_ca_pr(string Texto)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Listado_ca_pr(Texto);
        }

        public static DataTable Ver_Stock_actual_ProductoxAlmacenes(int nCodigo_pr)
        {
            M_Productos Datos = new M_Productos();
            return Datos.Ver_Stock_actual_ProductoxAlmacenes(nCodigo_pr);
        }
    }
}
