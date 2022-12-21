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
    public class N_Clientes
    {

            public static DataTable Listado_cl(string Texto)
            {
                M_Clientes Datos = new M_Clientes();
                return Datos.Listado_cl(Texto);
            }

            public static string Guardar_cl(int nOpcion, E_Clientes oCl)
            {
                M_Clientes Datos = new M_Clientes();
                return Datos.Guardar_cl(nOpcion, oCl);
            }

            public static string Eliminar_cl(int codigo_cl)
            {
                M_Clientes Datos = new M_Clientes();
                return Datos.Eliminar_cl(codigo_cl);
            }

            public static DataTable Listado_td_cl()
            {
            M_Clientes Datos = new M_Clientes();
            return Datos.Listado_td_cl();
            }

            public static DataTable Listado_sx_cl()
            {
            M_Clientes Datos = new M_Clientes();
            return Datos.Listado_sx_cl();
            }

            public static DataTable Listado_ru_cl(string Texto)
            {
                M_Clientes Datos = new M_Clientes();
                return Datos.Listado_ru_cl(Texto);
            }

            public static DataTable Listado_ci_cl(string Texto)
            {
                 M_Clientes Datos = new M_Clientes();
                 return Datos.Listado_ci_cl(Texto);
            }
    }
}
