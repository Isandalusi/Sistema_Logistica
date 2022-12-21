using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public SqlConnection CrearConexion()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = @"Data Source=DESKTOP-3KOHSRH\SQLEXPRESS;Initial Catalog=BD_Sistema_Logitica;Integrated Security=True";
            }
            catch (Exception ex)
            {
                connection = null;
                throw ex;
            }
            return connection;
        }

        public static Conexion getInstacia()
        {
            Conexion Con = null;

            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

        private string conn;

        public string strinCon(string nomBd)
        {
            conn = ConfigurationManager.ConnectionStrings[nomBd].ConnectionString;
            return conn;
        }
    }
}
