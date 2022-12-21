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
    public class N_Usuarios
    {
        public static DataTable Listado_us(string Texto)
        {
            M_Usuarios Datos = new M_Usuarios();
            return Datos.Listado_us(Texto);
        }

        public static string Guardar_us(int nOpcion,E_Usuarios oUs)
        {
            M_Usuarios Datos = new M_Usuarios();
            return Datos.Guardar_us(nOpcion, oUs);
        }

        public static string Eliminar_us(int codigo_us)
        {
            M_Usuarios Datos = new M_Usuarios();
            return Datos.Eliminar_us(codigo_us);
        }

        public static DataTable Login_us(string Login,string password)
        {
            M_Usuarios Datos = new M_Usuarios();
            return Datos.Login_us(Login,password);
        }
    }
}
