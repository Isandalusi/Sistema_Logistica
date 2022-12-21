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
    public class N_Almacenes
    {
        public static DataTable Listado_al(string Texto)
        {
            M_Almacenes Datos = new M_Almacenes();
            return Datos.Listado_al(Texto);
        }

        public static string Guardar_al(int nOpcion,E_Almacenes oAl)
        {
            M_Almacenes Datos = new M_Almacenes();
            return Datos.Guartdar_al(nOpcion, oAl);
        }

        public static string Eliminar_al(int codigo_al)
        {
            M_Almacenes Datos = new M_Almacenes();
            return Datos.Eliminar_al(codigo_al);
        }
    }
}
