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
    public class M_Entrada_Productos
    {

        public DataTable Listado_ep(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_ep", SqlCon);
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
        public DataTable Listado_detalle_ep(int nCodigo_ep)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_Detalle_ep", SqlCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_ep", SqlDbType.Int).Value = nCodigo_ep;
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
        public string Guardar_ep(E_Entrada_Productos oEp,DataTable dTabla)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Guardar_ep", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;

               
                command.Parameters.Add("@nCodigo_tde", SqlDbType.Int).Value = oEp.Codigo_tde;
                command.Parameters.Add("@cNrodocumento_ep", SqlDbType.VarChar).Value = oEp.NroDocumento_ep;
                command.Parameters.Add("@nCodigo_pv", SqlDbType.Int).Value = oEp.Codigo_pv;
                command.Parameters.Add("@fFecha_ep", SqlDbType.Date).Value = oEp.Fecha_ep;
                command.Parameters.Add("@nCodigo_al", SqlDbType.Int).Value = oEp.Codigo_al;
                command.Parameters.Add("@cObservacion_ep", SqlDbType.Text).Value = oEp.Observacion;
                command.Parameters.Add("@nSubtotal", SqlDbType.Decimal).Value = oEp.Subtotal;
                command.Parameters.Add("@nIva", SqlDbType.Decimal).Value = oEp.Iva;
                command.Parameters.Add("@nTotal_importe", SqlDbType.Decimal).Value = oEp.Importe_Total;
                command.Parameters.Add("@tDetalle", SqlDbType.Structured).Value = dTabla;
               
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

        public string Eliminar_ep(int codigo_ep)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Eliminar_ep", Sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nCodigo_ep", SqlDbType.Int).Value = codigo_ep;
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

        public DataTable Listado_tde_ep()
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
        public DataTable Listado_al_ep()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_al_ep", SqlCon);
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


        public DataTable Listado_pv_ep(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_pv_ep", SqlCon);
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

        public DataTable Listado_pr_ep(string texto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstacia().CrearConexion();
                SqlCommand command = new SqlCommand("USP_Listado_pr_ep", SqlCon);
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
