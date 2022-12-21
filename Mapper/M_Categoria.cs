using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Mapper
{
    public class M_Categoria
    {

        public DataTable Listado_ma(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_ca", SqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Texto", SqlDbType.VarChar).Value = texto;
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

        public string Guartdar_ca(int nOpcion,E_Categoria oCa)
        {
            string Rpta= "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Guardar_ca", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.Add("@nOpcion",SqlDbType.Int).Value=nOpcion;
                command.Parameters.Add("@codigo", SqlDbType.Int).Value = oCa.Codigo_ca;
                command.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oCa.Descripcion_ca;
                Sqlcon.Open();
                Rpta = command.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Registrar los Datos";

            }
            catch (Exception ex)
            {

                Rpta=ex.Message;
            }
            finally
            {
                if (Sqlcon.State==ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
            return Rpta;
        }

        public string Eliminar_ca(int codigo_ca)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Eliminar_ca", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value =codigo_ca;
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
       
    }
}
