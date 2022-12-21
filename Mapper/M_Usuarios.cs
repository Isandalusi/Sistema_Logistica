using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class M_Usuarios
    {
        public DataTable Listado_us(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_us", SqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = texto;
                SqlCon.Open();
                Resultado = command.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_us(int nOpcion, E_Usuarios oUs)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Guardar_us", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                command.Parameters.Add("@nCodigo_us", SqlDbType.Int).Value = oUs.Codigo_us;
                command.Parameters.Add("@cLogin_us", SqlDbType.VarChar).Value = oUs.Login_us;
                command.Parameters.Add("@cPassword_us", SqlDbType.VarChar).Value = oUs.Password_us;
                command.Parameters.Add("@cNombre_us", SqlDbType.VarChar).Value = oUs.Nombre_us;
                command.Parameters.Add("@cCargo_us", SqlDbType.VarChar).Value = oUs.Cargo_us;
                command.Parameters.Add("@bAdmin", SqlDbType.Bit).Value = oUs.Admin;
                Sqlcon.Open();
                Rpta = command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Registrar los Datos";

            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
            return Rpta;
        }

        public string Eliminar_us(int codigo_us)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Eliminar_us", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_us", SqlDbType.Int).Value = codigo_us;
                Sqlcon.Open();
                Rpta = command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Eliminar los Datos";

            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
            return Rpta;
        }
        public DataTable Login_us(string login,string password)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Login_us", SqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cLogin_us", SqlDbType.VarChar).Value = login;
                command.Parameters.Add("@cPassword_us", SqlDbType.VarChar).Value = password;
                SqlCon.Open();
                Resultado = command.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }
    }
}
