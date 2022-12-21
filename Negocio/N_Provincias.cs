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
    public class N_Provincias
    {
        public static DataTable Listado_po(string Texto)
        {
            M_Provincia Datos = new M_Provincia();
            return Datos.Listado_po(Texto);
        }

        public static string Guardar_po(int nOpcion, E_Provincias oPo)
        {
            M_Provincia Datos = new M_Provincia();
            return Datos.Guartdar_po(nOpcion, oPo);
        }

        public static string Eliminar_po(int codigo_po)
        {
            M_Provincia Datos = new M_Provincia();
            return Datos.Eliminar_po(codigo_po);
        }
        public static DataTable Listado_pa_po(string Texto)
        {
            M_Provincia Datos = new M_Provincia();
            return Datos.Listado_pa_po(Texto);
        }
    }
}
