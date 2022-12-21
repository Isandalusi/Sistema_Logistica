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
    public class N_Categoria
    {
        public static DataTable Listado_ca(string Texto)
        {
            M_Categoria Datos = new M_Categoria();
            return Datos.Listado_ma(Texto);
        }

        public static string Guardar_ca(int nOpcion,E_Categoria oCa)
        {
            M_Categoria Datos = new M_Categoria();
            return Datos.Guartdar_ca(nOpcion,oCa);
        }

        public static string Eliminar_ca(int codigo_ca)
        {
            M_Categoria Datos = new M_Categoria();
            return Datos.Eliminar_ca(codigo_ca);
        }

    }
}
