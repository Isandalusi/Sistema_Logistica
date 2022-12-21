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
    public class M_Salida_Productos
    {
        public DataTable Listado_sp(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_sp", SqlCon);
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
        public DataTable Listado_detalle_sp(int nCodigo_sp)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_Detalle_sp", SqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_sp", SqlDbType.Int).Value = nCodigo_sp;
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
        public string Guardar_sp(E_Salida_Productos oSp, DataTable dTabla)
        {
            string Rpta ="";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Guardar_sp", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@nCodigo_tde", SqlDbType.Int).Value = oSp.Codigo_tde;
                command.Parameters.Add("@cNrodocumento_sp", SqlDbType.VarChar).Value = oSp.NroDocumento_sp;
                command.Parameters.Add("@nCodigo_cl", SqlDbType.Int).Value = oSp.Codigo_cl;
                command.Parameters.Add("@cNrodocumento_cl", SqlDbType.VarChar).Value = oSp.Nrodocumento_cl;
                command.Parameters.Add("@cRazon_social_cl", SqlDbType.VarChar).Value = oSp.Razon_social_cl;
                command.Parameters.Add("@fFecha_sp", SqlDbType.Date).Value = oSp.Fecha_sp;
                command.Parameters.Add("@cObservacion_sp", SqlDbType.Text).Value = oSp.Observacion;
                command.Parameters.Add("@nSubtotal", SqlDbType.Decimal).Value = oSp.Subtotal;
                command.Parameters.Add("@nIva", SqlDbType.Decimal).Value = oSp.Iva;
                command.Parameters.Add("@nTotal_importe", SqlDbType.Decimal).Value = oSp.Importe_Total;
                command.Parameters.Add("@tDetalle", SqlDbType.Structured).Value = dTabla;

                SqlParameter Param_codigo = new SqlParameter();
                Param_codigo.ParameterName = "@nCodigo_sp";
                Param_codigo.SqlDbType = SqlDbType.Int;
                Param_codigo.Direction=ParameterDirection.Output;
                command.Parameters.Add(Param_codigo);

                Sqlcon.Open();
                command.ExecuteNonQuery();
                Rpta =Convert.ToString(Param_codigo.Value);
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

        public string Eliminar_sp(int codigo_sp)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Eliminar_sp", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_sp", SqlDbType.Int).Value = codigo_sp;
                Sqlcon.Open();
                Rpta = command.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo Eliminar los Datos";

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

        public DataTable Listado_tde_sp()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_tde", SqlCon);
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
        


        public DataTable Listado_cl_sp(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_cl_sp", SqlCon);
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

        public DataTable Listado_pr_sp(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_pr_sp", SqlCon);
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
    }
}
