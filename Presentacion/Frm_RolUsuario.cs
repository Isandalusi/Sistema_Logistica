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
    public partial class Frm_RolUsuario : Form
    {
        public Frm_RolUsuario()
        {
            InitializeComponent();
        }
        E_RolUsuario oRu=new E_RolUsuario();
        E_Permisos oPe=new E_Permisos();
        M_RolUsuario oMru=new M_RolUsuario();
        int IdRol;

        private void GuardarRol()
        {
            oRu.Rolnombre=txt_Nombre.Text.ToUpper().Trim();
            IdRol = oMru.GuardarRolUsuario(oRu);
        }
        private void GuardarPermisos()
        {
            foreach (Control chk in panel1.Controls)
            {
                oPe.RolUsuario = IdRol;
                if (chk is CheckBox)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        oPe.OpcionId = Convert.ToInt32(chk.Tag);
                        oPe.Permitido=true;
                        oMru.GuardarPermiso(oPe);
                    }
                    else
                    {
                        if (((CheckBox)chk).Checked)
                        {
                            oPe.OpcionId = Convert.ToInt32(chk.Tag);
                            oPe.Permitido = false;
                            oMru.GuardarPermiso(oPe);
                        }
                    }
                }
            }
        }
        private void Limpiar()
        {
            txt_Nombre.Text = string.Empty;
            txt_Nombre.Focus();
            foreach(Control chk in panel1.Controls)
            {
                if (chk is CheckBox)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        ((CheckBox)chk).Checked = false;
                    }
                }
            }
            MessageBox.Show("Permiso Guardado");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GuardarRol();
            GuardarPermisos();
            Limpiar();
        }
    }
}
