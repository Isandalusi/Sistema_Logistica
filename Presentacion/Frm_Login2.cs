using Entidades;
using Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Frm_Login2 : Form
    {
        

        public Frm_Login2()
        {
            InitializeComponent();
        }
        M_RolUsuario Mru=new M_RolUsuario();
        E_Usuario Eus=new E_Usuario();
        int IdRol = 0;

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MDI_Principal m = new MDI_Principal(IdRol);
                m.Show();
                this.Hide();
            }
            
            
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool ValidarCampos()
        {
            IdRol = Mru.BuscarUsuario(txt_login.Text,txtPassword.Text);
            if (txt_login.Text==string.Empty)
            {
                MessageBox.Show("Ingrese Usuario");
                txt_login.Focus();
                return false;
            }
            else if(txtPassword.Text==string.Empty)
            {
                MessageBox.Show("Ingrese Password");
                txtPassword.Focus();
                return false;
            }
            else if (IdRol==0)
            {
                MessageBox.Show("Usuario no Registrado");
                return false;
            }
            return true;
        }


    }
}
