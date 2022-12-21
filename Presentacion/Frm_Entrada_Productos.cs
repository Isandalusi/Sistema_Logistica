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
using System.Windows.Forms.VisualStyles;

namespace Presentacion
{
    public partial class Frm_Entrada_Productos : Form
    {
        public Frm_Entrada_Productos()
        {
            InitializeComponent();
        }
        #region "Mis Variables"



        int Codigo_ep = 0;
        int Codigo_tde = 0;
        int Codigo_pv = 0;
        int Codigo_al = 0;
        int Estado_guarda = 0;
        DataTable Tabla_Detalle = new DataTable();

        #endregion


        #region"Mis Metodos"
        private void Formato_ep()
        {
            dgvPrincipal.Columns[0].Width = 98;
            dgvPrincipal.Columns[0].HeaderText = "CODIGO";
            dgvPrincipal.Columns[1].Width = 150;
            dgvPrincipal.Columns[1].HeaderText = "TIPO DOCUMENTO";
            dgvPrincipal.Columns[2].Width = 150;
            dgvPrincipal.Columns[2].HeaderText = "N° DOCUMENTO";
            dgvPrincipal.Columns[3].Width = 150;
            dgvPrincipal.Columns[3].HeaderText = "FECHA DOC";
            dgvPrincipal.Columns[4].Width = 250;
            dgvPrincipal.Columns[4].HeaderText = "PROVEEDOR";
            dgvPrincipal.Columns[5].Width = 200;
            dgvPrincipal.Columns[5].HeaderText = "ALMACEN";
            dgvPrincipal.Columns[6].Width = 150;
            dgvPrincipal.Columns[6].HeaderText = "TOTAL IMPORTE";
            dgvPrincipal.Columns[7].Visible = false;
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[9].Visible = false;
            dgvPrincipal.Columns[10].Visible = false;
            dgvPrincipal.Columns[11].Visible = false;
            dgvPrincipal.Columns[12].Visible = false;
        }

        private void Listado_ep(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Entrada_Productos.Listado_ep(texto);
                this.Formato_ep();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_Botones_Principales(bool lEstado)
        {
            this.btnNuevo.Enabled = lEstado;
            this.btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

        }
        private void Estado_Botones_Procesos(bool lEstado)
        {
            this.btnCancelar.Visible = lEstado;
            this.btnGuardar.Visible = lEstado;
            this.btnVolver.Visible = !lEstado;
            this.btnAgregar.Visible = lEstado;
            this.btnEliminar.Visible = lEstado;
            this.btn_lupa1.Visible = lEstado;
            this.btn_lupa2.Visible = lEstado;
            this.btn_lupa_3.Visible = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                this.Codigo_ep = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_ep"].Value);
                this.Codigo_tde = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_tde"].Value);
                this.Codigo_pv = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_pv"].Value);
                this.Codigo_al = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codgo_al"].Value);
                txt_descripcion_tipo_documento.Text = dgvPrincipal.CurrentRow.Cells["descripcion_tde"].Value.ToString();
                txt_NroDocumento.Text = dgvPrincipal.CurrentRow.Cells["nrodocumento_ep"].Value.ToString();
                Dtp_Fecha.Value = Convert.ToDateTime(dgvPrincipal.CurrentRow.Cells["fecha_ep"].Value);
                txt_Proveedor.Text = dgvPrincipal.CurrentRow.Cells["razon_social_pv"].Value.ToString();
                txt_descripcion_Almacen.Text = dgvPrincipal.CurrentRow.Cells["descripcion_al"].Value.ToString();
                txt_Observaciones.Text = dgvPrincipal.CurrentRow.Cells["observacionnes_ep"].Value.ToString();
                txt_iva.Text = dgvPrincipal.CurrentRow.Cells["subtotal"].Value.ToString();
                txt_Subtotal.Text = dgvPrincipal.CurrentRow.Cells["iva"].Value.ToString();
                txtTotal.Text = dgvPrincipal.CurrentRow.Cells["total_importe"].Value.ToString();


                Dgv_Detalle.DataSource = N_Entrada_Productos.Listado_detalle_ep(this.Codigo_ep);
                this.Formato_detalle();
            }
        }
        private void Crear_TablaDetalle()
        {
            this.Tabla_Detalle = new DataTable("Tabla_detalle");
            this.Tabla_Detalle.Columns.Add("descripcion", Type.GetType("System.String"));
            this.Tabla_Detalle.Columns.Add("descripcion_ma", Type.GetType("System.String"));
            this.Tabla_Detalle.Columns.Add("descripcion_um", Type.GetType("System.String"));
            this.Tabla_Detalle.Columns.Add("cantidad", Type.GetType("System.Decimal"));
            this.Tabla_Detalle.Columns.Add("pu_compra", Type.GetType("System.Decimal"));
            this.Tabla_Detalle.Columns.Add("total", Type.GetType("System.Decimal"));
            this.Tabla_Detalle.Columns.Add("codigo_pr", Type.GetType("System.Int32"));
            this.Tabla_Detalle.AcceptChanges();

            Dgv_Detalle.DataSource = this.Tabla_Detalle;
            this.Formato_detalle();

        }
        private void Formato_detalle()
        {
            Dgv_Detalle.Columns[0].Width = 280;
            Dgv_Detalle.Columns[0].HeaderText = "PRODUCTO";
            Dgv_Detalle.Columns[1].Width = 280;
            Dgv_Detalle.Columns[1].HeaderText = "MARCA";
            Dgv_Detalle.Columns[2].Width = 150;
            Dgv_Detalle.Columns[2].HeaderText = "U. MEDIDA";
            Dgv_Detalle.Columns[3].Width = 150;
            Dgv_Detalle.Columns[3].HeaderText = "CANTIDAD";
            Dgv_Detalle.Columns[4].Width = 150;
            Dgv_Detalle.Columns[4].HeaderText = "P.UNITARIO";
            Dgv_Detalle.Columns[5].Width = 150;
            Dgv_Detalle.Columns[5].HeaderText = "TOTAL";
            Dgv_Detalle.Columns[6].Visible = false;
            Dgv_Detalle.Columns[0].ReadOnly = true;
            Dgv_Detalle.Columns[1].ReadOnly = true;
            Dgv_Detalle.Columns[2].ReadOnly = true;
            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;
            Dgv_Detalle.Columns[5].ReadOnly = true;

        } 
        private void AgregarItem(string  Descripcion_pr,string Descripcion_ma,string Descripcion_um,decimal Cantidad,decimal Pu_compra,decimal Total,int Codigo_pr)
        {
            DataRow xFila = Tabla_Detalle.NewRow();
            xFila["descripcion"] = Descripcion_pr;
            xFila["descripcion_ma"] = Descripcion_ma;
            xFila["descripcion_um"] = Descripcion_um;
            xFila["cantidad"] = Cantidad;
            xFila["pu_compra"] = Pu_compra;
            xFila["total"] = Total;
            xFila["codigo_pr"] = Codigo_pr;
            this.Tabla_Detalle.Rows.Add(xFila);
            Tabla_Detalle.AcceptChanges();
        }
        private void Formato_tdpe()

        {
            dgv_TipoDocumento.Columns[0].Width = 250;
            dgv_TipoDocumento.Columns[0].HeaderText = "TIPO DOCUMENTO";
            dgv_TipoDocumento.Columns[1].Visible = false;
        }

        private void Listado_tdpe()
        {
            try
            {
                dgv_TipoDocumento.DataSource = N_Entrada_Productos.Listado_tde_ep();
                this.Formato_tdpe();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_tdpe()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_TipoDocumento.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_tde = Convert.ToInt32(dgv_TipoDocumento.CurrentRow.Cells[1].Value);
                txt_descripcion_tipo_documento.Text = Convert.ToString(dgv_TipoDocumento.CurrentRow.Cells[0].Value);
            }
        }

       
        private void Formato_al()
        {
            dgvAlmacen.Columns[0].Width = 200;
            dgvAlmacen.Columns[0].HeaderText = "ALMACEN";
            dgvAlmacen.Columns[1].Visible = false;
           
        }

        private void Listado_al()
        {
            try
            {
                dgvAlmacen.DataSource = N_Entrada_Productos.Listado_al_ep();
                this.Formato_al();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_al()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvAlmacen.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_al = Convert.ToInt32(dgvAlmacen.CurrentRow.Cells[1].Value);
                txt_descripcion_Almacen.Text = Convert.ToString(dgvAlmacen.CurrentRow.Cells[0].Value);
            }
        }

        private void Formato_pv()
        {
            dgv_Proveedores.Columns[0].Width = 150;
            dgv_Proveedores.Columns[0].HeaderText = "PROVEEDOR";
            dgv_Proveedores.Columns[1].Width = 80;
            dgv_Proveedores.Columns[1].HeaderText = "TIPO DOC";
            dgv_Proveedores.Columns[2].Width = 100;
            dgv_Proveedores.Columns[2].HeaderText = "NRO DOC";
            dgv_Proveedores.Columns[3].Visible = false;
        }

        private void Listado_pv(string Texto)
        {
            try
            {
                dgv_Proveedores.DataSource = N_Entrada_Productos.Listado_pv_ep(Texto);
                this.Formato_pv();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_pv()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Proveedores.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pv = Convert.ToInt32(dgv_Proveedores.CurrentRow.Cells["codigo_pv"].Value);
                txt_Proveedor.Text = Convert.ToString(dgv_Proveedores.CurrentRow.Cells["razon_social_pv"].Value);
            }
                              
        }
        private void Formato_pr()
        {
            dgv_pruductos.Columns[0].Width = 150;
            dgv_pruductos.Columns[0].HeaderText = "PRODUCTO";
            dgv_pruductos.Columns[1].Width = 80;
            dgv_pruductos.Columns[1].HeaderText = "MARCA";
            dgv_pruductos.Columns[2].Width = 100;
            dgv_pruductos.Columns[2].HeaderText = "U.MEDIDA";
            dgv_pruductos.Columns[3].Width = 100;
            dgv_pruductos.Columns[3].HeaderText = "CATEGORIA";
            dgv_pruductos.Columns[4].Visible = false;
        
        }

        private void Listado_pr(string Texto)
        {
            try
            {
                dgv_pruductos.DataSource = N_Entrada_Productos.Listado_pr_ep(Texto);
                this.Formato_pr();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_pruductos.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xDescripcion_pr;
                string xDescripcion_ma;
                string xDescripcion_um;
                decimal xCantidad;
                decimal xPu_Compra;
                decimal xTotal;
                int xCodigo_pr;

                bool Agregar=true ;

                xCodigo_pr =Convert.ToInt32(dgv_pruductos.CurrentRow.Cells["codigo_pr"].Value);

                foreach (DataRow Filatemp in Tabla_Detalle.Rows)
                {
                    if (Convert.ToInt32(Filatemp["codigo_pr"])==xCodigo_pr)
                    {
                        Agregar = false;
                        MessageBox.Show("El producto ya se encuentra agregado","Aviso del Sitema");
                    }
                }
                if (Agregar==true)
                {
                    xDescripcion_pr = Convert.ToString(dgv_pruductos.CurrentRow.Cells["descripcion"].Value);
                    xDescripcion_ma = Convert.ToString(dgv_pruductos.CurrentRow.Cells["descripcion_ma"].Value);
                    xDescripcion_um = Convert.ToString(dgv_pruductos.CurrentRow.Cells["descripcion_um"].Value);
                    xCantidad =Convert.ToDecimal("0.00");
                    xPu_Compra = Convert.ToDecimal("0.00");
                    xTotal = Convert.ToDecimal("0.00");

                    this.AgregarItem(xDescripcion_pr, xDescripcion_ma, xDescripcion_um, xCantidad, xPu_Compra, xTotal, xCodigo_pr);
                }
                
               
            }

        }

        private void Estado_texto(bool lestado)
        {
            txt_NroDocumento.ReadOnly = !lestado;
            txt_Observaciones.ReadOnly = !lestado;
            Dtp_Fecha.Enabled = lestado;

        }

        private void Limpia_texto()
        {
            txt_NroDocumento.Text = "";
            txt_Proveedor.Text = "";
            txt_Observaciones.Text = "";
            txt_iva.Text = "";
            txt_Subtotal.Text = "";
            txtTotal.Text = "";
            this.Crear_TablaDetalle();
        }
        private void Calcular_Totales()
        {
            decimal total_importe = 0;
            decimal subtotal_importe = 0;
            decimal iva;
            if (Dgv_Detalle.Rows.Count==0)
            {
                iva = 0;
                subtotal_importe = 0;
                total_importe = 0;
            }
            else
            {
                Tabla_Detalle.AcceptChanges();
                foreach (DataRow filatemp in Tabla_Detalle.Rows)
                {
                    total_importe = total_importe + Convert.ToDecimal(filatemp["total"]);
                }
                
                subtotal_importe = total_importe / (1 + Convert.ToDecimal("0.21"));
                iva =( total_importe - subtotal_importe);

                txt_Subtotal.Text = subtotal_importe.ToString("#0.00");
                txt_iva.Text = iva.ToString("#0.00");
                txtTotal.Text=total_importe.ToString("#0.00");
            }
        }
        #endregion

        private void Frm_Entrada_Productos_Load(object sender, EventArgs e)
        {
            this.Listado_ep("%");
            this.Listado_tdpe();
            this.Listado_pv("%");
            this.Listado_al();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_NroDocumento.Text == String.Empty || txt_descripcion_tipo_documento.Text == String.Empty || txt_descripcion_Almacen.Text == String.Empty || txt_Proveedor.Text==string.Empty||
                Dgv_Detalle.Rows.Count>0)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else//Registra el proveedor
            {

                string Rpta = "";
                E_Entrada_Productos oEp = new E_Entrada_Productos ();
                oEp.Codigo_ep = this.Codigo_ep;
                oEp.Codigo_tde = this.Codigo_tde;
                oEp.NroDocumento_ep = txt_NroDocumento.Text.Trim();
                oEp.Codigo_pv=this.Codigo_pv;
                oEp.Fecha_ep = Dtp_Fecha.Value;
                oEp.Codigo_al=this.Codigo_al;
                oEp.Observacion = txt_Observaciones.Text.Trim();
                oEp.Subtotal =Convert.ToDecimal(txt_iva.Text.Trim());
                oEp.Iva = Convert.ToDecimal(txt_Subtotal.Text.Trim());
                oEp.Importe_Total = Convert.ToDecimal(txtTotal.Text.Trim());
                this.Tabla_Detalle.AcceptChanges();

                Rpta = N_Entrada_Productos.Guardar_ep(oEp,Tabla_Detalle);
                if (Rpta == "OK")
                {
                    Listado_ep("%");
                    MessageBox.Show("El producto se Guardo de Forma Correcta!!!", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    this.Estado_texto(false);

                    tabControlPrincipaL.SelectedIndex = 0;

                    
                    this.Codigo_ep = 0;
                  
                    this.Estado_guarda = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Estado_guarda = 1;
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.Limpia_texto();
            Dgv_Detalle.Columns[3].ReadOnly = false;
            Dgv_Detalle.Columns[4].ReadOnly = false;
            this.Estado_texto(true);
          
            tabControlPrincipaL.SelectedIndex = 1;
            txt_NroDocumento.Focus();
           
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {

           
            this.Estado_guarda=0;
            this.Codigo_ep= 0;
            this.Codigo_tde = 0;
            this.Codigo_pv= 0;
            this.Codigo_al = 0;
          
            this.Estado_texto(false);
            this.Limpia_texto();
            Dgv_Detalle.Columns[3].ReadOnly = true;
            Dgv_Detalle.Columns[4].ReadOnly = true;
            this.Estado_Botones_Principales(true);
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;


        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;
           
          
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;
            
         
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
                Opcion = MessageBox.Show("Estas Seguro de anular el registro Seleccionado??", "Aviso Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Codigo_ep = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Entrada_Productos.Eliminar_ep(this.Codigo_ep);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ep("%");
                        this.Codigo_ep = 0;
                        MessageBox.Show("Registro Anulado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }


            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_ep(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Fmr_Rpt_Entrada_Producto oRp2 = new Reportes.Fmr_Rpt_Entrada_Producto();
            oRp2.textBox1.Text = txtBuscar.Text;
            oRp2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_lupa1_Click(object sender, EventArgs e)
        {
            this.p_listado_TD.Location = btn_lupa1.Location;
            this.p_listado_TD.Visible = true;
        }

       

        private void btn_lupa2_Click(object sender, EventArgs e)
        {
            this.p_Proveedores.Location = btn_lupa1.Location;
            this.p_Proveedores.Visible = true;
        }

       
        
        

        private void btnvolver2_Click(object sender, EventArgs e)
        {
            p_listado_TD.Visible=false;
        }

      

       

        private void btn_lupa_3_Click(object sender, EventArgs e)
        {

            this.pAlmaccen.Location = btn_lupa1.Location;
            this.pAlmaccen.Visible = true;

        }

       
        private void btnvolver3_Click(object sender, EventArgs e)
        {
            pAlmaccen.Visible = false;
        }

        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
           /* this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 1;
            this.Listado_stock_Actual(this.Codigo_pr);
            gb_detalle.Visible = true;
           */
        }

        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_descripcion_marca_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_TipoDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_tdpe();
            p_listado_TD.Visible = false;
            txt_NroDocumento.Focus();
        }

        

        private void dgvRubro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             this.SeleccionaItem_al();
             pAlmaccen.Visible = false;
             txt_Observaciones.Focus();
        }

        private void btn_lupa_5_Click(object sender, EventArgs e)
        {
            this.p_Proveedores.Location = btn_lupa1.Location;
            this.p_Proveedores.Visible = true;
        }

        private void btn_volver_ci_Click(object sender, EventArgs e)
        {
            p_Proveedores.Visible=false;
        }

        private void bnt_buscar_ci_Click(object sender, EventArgs e)
        {
            this.Listado_pv(txt_Buscar_Proveedores.Text);
        }

        private void dgv_Proveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.SeleccionaItem_pv();
            p_Proveedores.Visible = false;
            txt_Observaciones.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.pListadopr.Visible=true;
            pListadopr.Location = btn_lupa1.Location;
            txt_buscar_pr.Focus();
        }

        private void btn_Volver_Pr_Click(object sender, EventArgs e)
        {
            pListadopr.Visible=false;
        }

        private void btn_buscar_productos_Click(object sender, EventArgs e)
        {
            this.Listado_pr(txt_buscar_pr.Text);
        }

        private void dgv_pruductos_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem_pr();
            pListadopr.Visible = false;
        }

        private void Dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Estado_guarda == 1)
            {
                DataRow yFila = (DataRow)Tabla_Detalle.Rows[e.RowIndex];
                decimal yCantidad = Convert.ToDecimal(yFila["cantidad"]);
                decimal yPu_compra = Convert.ToDecimal(yFila["pu_compra"]);
                yFila["Total"] = decimal.Round(yCantidad * yPu_compra, 2).ToString("#0.00");
                this.Calcular_Totales();
                Refresh();
            }
           
            
        }

        private void btnElimnar_Click(object sender, EventArgs e)
        {
            if (Dgv_Detalle.Rows.Count>0)
            {
                Dgv_Detalle.Rows.Remove(Dgv_Detalle.CurrentRow);
                Dgv_Detalle.Refresh();
                Tabla_Detalle.AcceptChanges();
                this.Calcular_Totales();
            }
        }

        private void dgv_Proveedores_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem_pv();
            p_Proveedores.Visible = false;
            txt_Observaciones.Focus();
        }
    }
}
