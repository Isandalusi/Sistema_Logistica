using Entidades;
using Negocio;
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
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }
        #region "Mis Variables"

        int Estado_Guardar = 0;//Sin accion

        int Codigo_pr=0;
        int Codigo_ma = 0;
        int Codigo_um = 0;
        int Codigo_ca = 0;


        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Listado_pr("%");
            this.Listado_ma("%");
            this.Listado_um("%");
            this.Listado_ca("%");

            
        }

        #region"Mis Metodos"
        private void Formato_pr()
        {
            dgvPrincipal.Columns[0].Width = 100;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 200;
            dgvPrincipal.Columns[1].HeaderText = "PRODUCTO";
            dgvPrincipal.Columns[2].Width = 200;
            dgvPrincipal.Columns[2].HeaderText = "MARCA";
            dgvPrincipal.Columns[3].Width = 100;
            dgvPrincipal.Columns[3].HeaderText = "U.MEDIDA";
            dgvPrincipal.Columns[4].Width = 200;
            dgvPrincipal.Columns[4].HeaderText = "CATEGORIA";
            dgvPrincipal.Columns[5].Width = 100;
            dgvPrincipal.Columns[5].HeaderText = "STOCK MIN";
            dgvPrincipal.Columns[6].Width = 100;
            dgvPrincipal.Columns[6].HeaderText = "STOCK MAX";
            dgvPrincipal.Columns[7].Visible=false;
            dgvPrincipal.Columns[8].Visible=false;
            dgvPrincipal.Columns[9].Visible = false;
            dgvPrincipal.Columns[10].Visible = false;
        }

        private void Listado_pr(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Productos.Listado_pr(texto);
                this.Formato_pr();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_Botones_Principales(bool lEstado)
        {
            this.btnNuevo.Enabled = lEstado;
            this.btnActualizar.Enabled = lEstado;
            this.btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

        }
        private void Estado_Botones_Procesos(bool lEstado)
        {
            this.btnCancelar.Visible = lEstado;
            this.btnGuardar.Visible=lEstado;
            this.btnVolver.Visible=!lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio","Aviso del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pr =Convert.ToInt32( dgvPrincipal.CurrentRow.Cells["codigo_pr"].Value);
                txtAlmacenes.Text =Convert.ToString( dgvPrincipal.CurrentRow.Cells["descripcion"].Value);
                this.Codigo_ma = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ma"].Value);
                txt_descripcion_marca.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_ma"].Value);
                this.Codigo_um = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_um"].Value);
                txt_descripcion_um.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_um"].Value);
                this.Codigo_ca = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ca"].Value);
                txt_descripcion_ca.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["descripcion_ca"].Value);
                txt_smin.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["stock_min"].Value);
                txt_smax.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["stock_max"].Value);
                txt_PUVenta.Text = Convert.ToString(dgvPrincipal.CurrentRow.Cells["pu_venta"].Value);

            }
        }

        private void Formato_ma()
        {
            dgvMarcas.Columns[0].Width = 200;
            dgvMarcas.Columns[0].HeaderText = "MARCA";
            dgvMarcas.Columns[1].Visible = false;
        }

        private void Listado_ma(string texto)
        {
            try
            {
                dgvMarcas.DataSource = N_Productos.Listado_ma_pr(texto);
                this.Formato_ma();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItemma_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvMarcas.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(dgvMarcas.CurrentRow.Cells[1].Value);
                txt_descripcion_marca.Text = Convert.ToString(dgvMarcas.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_um()
        {
            dgv_medidas.Columns[0].Width = 200;
            dgv_medidas.Columns[0].HeaderText = "UNIDAD DE MEDIDA";
            dgv_medidas.Columns[1].Visible = false;
        }

        private void Listado_um(string texto)
        {
            try
            {
                dgv_medidas.DataSource = N_Productos.Listado_um_pr(texto);
                this.Formato_um();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_um_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_medidas.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_um = Convert.ToInt32(dgv_medidas.CurrentRow.Cells[1].Value);
                txt_descripcion_um.Text = Convert.ToString(dgv_medidas.CurrentRow.Cells[0].Value);
            }
        
        }

        private void Formato_ca()
        {
            dgv_medidas.Columns[0].Width = 200;
            dgv_medidas.Columns[0].HeaderText = "CATEGORIAS";
            dgv_medidas.Columns[1].Visible = false;
        }

        private void Listado_ca(string texto)
        {
            try
            {
                dgvCategoria.DataSource = N_Productos.Listado_ca_pr(texto);
                this.Formato_ca();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_ca_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvCategoria.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(dgvCategoria.CurrentRow.Cells[1].Value);
                txt_descripcion_ca.Text = Convert.ToString(dgvCategoria.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_stock_actual()
        {
            dgv_stock_Actuaal.Columns[0].Width = 150;
            dgv_stock_Actuaal.Columns[0].HeaderText = "ALMACEN";
            dgv_stock_Actuaal.Columns[1].Width = 100;
            dgv_stock_Actuaal.Columns[1].HeaderText = "STOCK ACTUAL";
            dgv_stock_Actuaal.Columns[2].Width = 100;
            dgv_stock_Actuaal.Columns[2].HeaderText = "PRECIO UNIDAD";
        }

        private void Listado_stock_Actual(int nCodigo_pr)
        {
            try
            {
                dgv_stock_Actuaal.DataSource =N_Productos.Ver_Stock_actual_ProductoxAlmacenes(nCodigo_pr);
                this.Formato_stock_actual();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtAlmacenes.Text==String.Empty || txt_descripcion_marca.Text == String.Empty || txt_descripcion_ca.Text == String.Empty || txt_descripcion_um.Text == String.Empty||txt_PUVenta.Text==String.Empty)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)","Aviso de Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else//Registra el producto
            {
                E_Productos oPr = new E_Productos();
                string Rpta = "";
                oPr.Codigo_pr=this.Codigo_pr;
                oPr.Descripcion_pr = txtAlmacenes.Text;
                oPr.Codigo_ma = this.Codigo_ma;
                oPr.Codigo_um=this.Codigo_um;
                oPr.Codigo_ca=this.Codigo_ca;
                oPr.Stock_min =Convert.ToDecimal(txt_smin.Text);
                oPr.Stock_max = Convert.ToDecimal(txt_smax.Text);
                oPr.Pu_venta =Convert.ToDecimal(txt_PUVenta.Text);
                Rpta = N_Productos.Guardar_pr(Estado_Guardar,oPr);
                if (Rpta=="OK")
                {
                    Listado_pr("%");
                    MessageBox.Show("El producto se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estado_Guardar = 0;//Sin ninguna accion
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    txtAlmacenes.Text = "";
                    txt_descripcion_marca.Text = "";
                    txt_descripcion_um.Text = "";
                    txt_descripcion_ca.Text = "";
                    txtAlmacenes.ReadOnly=true;
                    txt_descripcion_marca.ReadOnly = true;
                    txt_descripcion_um.ReadOnly = true;
                    txt_descripcion_ca.ReadOnly = true;
                    tabControlPrincipaL.SelectedIndex =0;
                    this.Codigo_pr = 0;
                    gb_detalle.Visible = false;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 1;//Nuevo Registro
            gb_detalle.Visible = false;
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            txtAlmacenes.Text = "";
            txt_smin.Text = "0";
            txt_smax.Text ="0";
            txt_PUVenta.Text = "0";
            txt_smin.ReadOnly=false;
            txt_smax.ReadOnly=false;
            txt_PUVenta.ReadOnly=false;
            txtAlmacenes.ReadOnly=false;
            tabControlPrincipaL.SelectedIndex = 1;
            txtAlmacenes.Focus();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 2;//Actualizar
            gb_detalle.Visible = false;
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.SeleccionaItem();
            tabControlPrincipaL.SelectedIndex = 1;
            txtAlmacenes.ReadOnly = false;
            txt_smin.ReadOnly = false;   
            txt_smax.ReadOnly = false;
            txt_PUVenta.ReadOnly = false;
            txtAlmacenes.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Estado_Guardar = 0;//sin Accion
            gb_detalle.Visible = false;
            this.Codigo_pr =0;
            txtAlmacenes.Text = "";
            txtAlmacenes.ReadOnly = true;
            txt_smin.Text="0";
            txt_smax.Text="0";
            txt_PUVenta.Text = "0";
            txt_smin.ReadOnly = true;
            txt_smax.ReadOnly = true;
            txt_PUVenta.ReadOnly = true;
            this.Estado_Botones_Principales(true);
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;

        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;
            this.gb_detalle.Visible = true;

        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;
            Codigo_pr =0;
            gb_detalle.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
               Opcion=MessageBox.Show("Estas Seguro de eliminar el registro Seleccionado??","Aviso Del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (Opcion==DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_pr = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Almacenes.Eliminar_al(this.Codigo_pr);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_pr("%");
                        this.Codigo_pr = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     
                    }

                }
               
               
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Productos oRp2 = new Reportes.Frm_Rpt_Productos();
            oRp2.textBox1.Text=txtBuscar.Text;
            oRp2.ShowDialog(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_lupa1_Click(object sender, EventArgs e)
        {
            this.pListado_Marcas.Location = btn_lupa1.Location;
            this.pListado_Marcas.Visible = true;
        }

        private void dgvMarcas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItemma_pr();
            pListado_Marcas.Visible = false;
        }

        private void btn_lupa2_Click(object sender, EventArgs e)
        {
            this.p_listado_um.Location = btn_lupa1.Location;
            this.p_listado_um.Visible = true;
        }

        private void btnBuscar_1_Click(object sender, EventArgs e)
        {
            this.Listado_ma(txtBuscar1.Text);
        }

        private void btnbuscar2_Click(object sender, EventArgs e)
        {
            this.Listado_um(txtbuscar2.Text);
        }

        private void VotonVolver1_Click(object sender, EventArgs e)
        {
            pListado_Marcas.Visible = false;
        }

        private void btnvolver2_Click(object sender, EventArgs e)
        {
            p_listado_um.Visible=false;
        }

        private void dgv_medidas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem_um_pr();
            p_listado_um.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pCategorias.Location = btn_lupa1.Location;
            this.pCategorias.Visible = true;
        }

        private void btn_lupa_3_Click(object sender, EventArgs e)
        {

            this.pCategorias.Location = btn_lupa1.Location;
            this.pCategorias.Visible = true;

        }

        private void dgvCategoria_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem_ca_pr();
            pCategorias.Visible = false;
        }

        private void btnvolver3_Click(object sender, EventArgs e)
        {
            pCategorias.Visible = false;
        }

        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;
            this.Listado_stock_Actual(this.Codigo_pr);
            gb_detalle.Visible = true;

        }

        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_lupa_4_Click(object sender, EventArgs e)
        {

        }
    }
}
