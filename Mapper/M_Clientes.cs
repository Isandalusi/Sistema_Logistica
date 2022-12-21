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
    public class M_Clientes
    {
        public DataTable Listado_cl(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_cl", SqlCon);
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

        public string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Guardar_cl", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                command.Parameters.Add("@n_Codigo_cl", SqlDbType.Int).Value = oCl.Codigo_cl;
                command.Parameters.Add("@nCodigo_tdpc", SqlDbType.Int).Value = oCl.Codigo_tdpc;
                command.Parameters.Add("@cNrodoumento_cl", SqlDbType.VarChar).Value = oCl.Nro_Documento_cl;
                command.Parameters.Add("@cRazon_social_cl", SqlDbType.VarChar).Value = oCl.RazonSocial_cl;
                command.Parameters.Add("@cNombres", SqlDbType.VarChar).Value = oCl.Nombre;
                command.Parameters.Add("@cApellidos", SqlDbType.VarChar).Value = oCl.Apellido;
                command.Parameters.Add("@nCodigo_sx", SqlDbType.Int).Value = oCl.Codigo_sx;
                command.Parameters.Add("@nCodigo_ru", SqlDbType.Int).Value = oCl.Codigo_ru;
                command.Parameters.Add("@cEmail_cl", SqlDbType.VarChar).Value = oCl.Email_cl;
                command.Parameters.Add("@cTelefono_cl", SqlDbType.VarChar).Value = oCl.Telefono_cl;
                command.Parameters.Add("@cCelular_cl", SqlDbType.VarChar).Value = oCl.Celular_cl;
                command.Parameters.Add("@cDireccion", SqlDbType.Text).Value = oCl.Direccion_cl;
                command.Parameters.Add("@nCodigo_ci", SqlDbType.Int).Value = oCl.Codigo_ci;
                command.Parameters.Add("@cObservacion_cl", SqlDbType.Text).Value = oCl.Observaciones_cl;
                Sqlcon.Open();
                Rpta = command.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo Registrar los Datos";

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

        public string Eliminar_cl(int codigo_cl)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Eliminar_cl", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_cl", SqlDbType.Int).Value = codigo_cl;
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

        public DataTable Listado_td_cl()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_td_pv", SqlCon);
                command.CommandType = CommandType.StoredProcedure;

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
        public DataTable Listado_sx_cl()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_sx_pv", SqlCon);
                command.CommandType = CommandType.StoredProcedure;

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


        public DataTable Listado_ru_cl(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_ru_pv", SqlCon);
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

        public DataTable Listado_ci_cl(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_ci_pv", SqlCon);
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
    }
}