using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        #region "Mis Metodos"

        private void Login_us(string Login ,string Password)
        {
            try
            {
                DataTable dt_login = new DataTable();
                dt_login = N_Usuarios.Login_us(Login,Password);
                if (dt_login.Rows.Count>0)//Tiene contenido
                {
                    string Usuario="";
                    string Rol = "";
                    bool Admin=false;

                    Usuario =Convert.ToString(dt_login.Rows[0][3]);
                    Rol = Convert.ToString(dt_login.Rows[0][4]);
                    Admin = Convert.ToBoolean(dt_login.Rows[0][5]);
                    
                    Frm_DashBoard oDash = new Frm_DashBoard();
                    oDash.lbl_Usuario.Text ="Usuario: "+ Usuario;
                    oDash.lbl_Rol.Text ="Rol: " + Rol;
                    oDash.chB_aDMIN.Checked = Admin;

                    if (Admin==true)//Administrador
                    {
                        oDash.Btn_Mov.Enabled = true;
                        oDash.btn_Reportes.Enabled = true;
                        oDash.Btn_DatosG.Enabled = true;
                        oDash.btn_Sistemas.Enabled = true;
                    }
                    else //Usuario comun
                    {
                        oDash.Btn_Mov.Enabled = true;
                        oDash.btn_Reportes.Enabled = true;
                        oDash.Btn_DatosG.Enabled = false;
                        oDash.btn_Sistemas.Enabled = false;
                    }
                    oDash.Show();
                    oDash.FormClosed += CerrarSesion;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Acceso Incorrecto","Aviso del Sistema");
                }
                
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

           
        }
        private void CerrarSesion(object sender,FormClosedEventArgs e)
        {
            txt_login.Text = "";
            txtPassword.Text = "";
            this.Show();
            txt_login.Focus();

        }
        #endregion

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Login_us(txt_login.Text, txtPassword.Text);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
