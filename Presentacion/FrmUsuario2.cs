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
    public partial class FrmUsuario2 : Form
    {
        public FrmUsuario2()
        {
            InitializeComponent();
        }
        M_RolUsuario oRu = new M_RolUsuario();
        E_Usuario oUs = new E_Usuario();

        private void CargarCombo()
        {
            DataTable dt = oRu.ComboRol();
            cbRol.DataSource = dt;
            cbRol.DisplayMember = "RolNombre";
            cbRol.ValueMember = "id_rol";
        }

        

        private void FrmUsuario2_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            oUs.Usuario=txt_Login.Text;
            oUs.Password=txt_Password.Text;
            oUs.RolId=(int)cbRol.SelectedValue;
            oRu.GuardarUsuario(oUs);
        }

        private void Limpiar()
        {
            txt_Login.Text = string.Empty;
            txt_Password.Text = string.Empty;
            txt_Login.Focus();
            cbRol.SelectedIndex = -1;
            MessageBox.Show("Usuario Guardado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oUs.Usuario = txt_Login.Text;
            oUs.Password = txt_Password.Text;
            oUs.RolId = (int)cbRol.SelectedValue;
            oRu.GuardarUsuario(oUs);
            Limpiar();
        }
    }
}
