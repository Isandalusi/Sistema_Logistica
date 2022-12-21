using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class M_RolUsuario
    {
        
        public int GuardarRolUsuario(E_RolUsuario oRol)
        {
            
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                int ultimoRegistro = 0;
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand cmd = new SqlCommand("Usp_GuardarRol", Sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                Sqlcon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter IdRol = new SqlParameter("@IdRol",SqlDbType.Int);
                IdRol.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdRol);
                cmd.Parameters.Add(new SqlParameter("@Nom",oRol.Rolnombre));
                cmd.ExecuteNonQuery();
                if (IdRol.Value != DBNull.Value)
                {
                    ultimoRegistro = Convert.ToInt32(IdRol.Value);
                }

                return ultimoRegistro;

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
              

            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
           
        }
        public void GuardarPermiso(E_Permisos oPe)
        {
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_GuardarPermiso", Sqlcon);
                Sqlcon.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add(new SqlParameter("@RolId", oPe.RolUsuario));
                cmd.Parameters.Add(new SqlParameter("@OpcionId", oPe.OpcionId));
                cmd.Parameters.Add(new SqlParameter("@Permitido", oPe.Permitido));
                cmd.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {
               
                throw ex;


            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
        }
        public DataTable ComboRol()
        {
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
              Sqlcon = Conexion.getInstacia().CrearConexion();
              DataTable dt = new DataTable();
              SqlCommand cmd = new SqlCommand("sp_ComboRol", Sqlcon);
              Sqlcon.Open();
              SqlDataAdapter da = new SqlDataAdapter();
              cmd.CommandType = CommandType.StoredProcedure;
              da.SelectCommand = cmd; 
              da.Fill(dt);
              return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }

            }
           
        }

        public void GuardarUsuario(E_Usuario oUs)
        {
            SqlConnection Sqlcon = new SqlConnection();

            try
            {

                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_guardarUsuario", Sqlcon);
                Sqlcon.Open();
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Usuario", oUs.Usuario));
                cmd.Parameters.Add(new SqlParameter("@Contra", oUs.Password));
                cmd.Parameters.Add(new SqlParameter("@RolId", oUs.RolId));
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw ex;


            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
        }
        public int BuscarUsuario(string Usuario ,string Password)
        {
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                int id = 0;
                Sqlcon = Conexion.getInstacia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_BuscarUsuario", Sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                Sqlcon.Open();
              
                SqlParameter IdRol = new SqlParameter("@IdUsuario", SqlDbType.Int);
                IdRol.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdRol);

                cmd.Parameters.Add(new SqlParameter("@usuario", Usuario));
                cmd.Parameters.Add(new SqlParameter("@contra", Password));
                cmd.ExecuteNonQuery();
                if (IdRol.Value != DBNull.Value)
                {
                    id = Convert.ToInt32(IdRol.Value);
                }

                return id;

            }
            catch (Exception ex)
            {
                return -1;
                throw ex;


            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }
            }
        }
        public List<E_Permisos>SelectOption(int IdRol)
        {
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstacia().CrearConexion();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spSelectOption", Sqlcon);
                Sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdRol", IdRol));
                da.SelectCommand = cmd;
                da.Fill(dt);
                List<E_Permisos> Opcion =(from row in dt.AsEnumerable()
                                          select new E_Permisos()
                                          {
                                              IdPermisos = int.Parse(row["IdPermisos"].ToString()),
                                              RolUsuario = int.Parse(row["RolUsuid"].ToString()),
                                              OpcionId = int.Parse(row["opcion_id"].ToString()),
                                              Permitido = bool.Parse(row["permitido"].ToString())
                                          }).ToList();
                return Opcion;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();

                }

            }
        }
    }
}
