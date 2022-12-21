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
    public partial class Frm_Salida_Productos : Form
    {
        public Frm_Salida_Productos()
        {
            InitializeComponent();
        }
        #region "Mis Variables"



        int Codigo_sp = 0;
        int Codigo_tde = 0;
        int Codigo_cl = 0;
       
        int Estado_guarda = 0;
        DataTable Tabla_Detalle = new DataTable();

        #endregion


        #region"Mis Metodos"
        private void Formato_sp()
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
            dgvPrincipal.Columns[4].HeaderText = "N° CLIENTE";
            dgvPrincipal.Columns[5].Width = 200;
            dgvPrincipal.Columns[5].HeaderText = "CLIENTE";
            dgvPrincipal.Columns[6].Width = 150;
            dgvPrincipal.Columns[6].HeaderText = "TOTAL IMPORTE";
            dgvPrincipal.Columns[7].Visible = false;
            dgvPrincipal.Columns[8].Visible = false;
            dgvPrincipal.Columns[9].Visible = false;
            dgvPrincipal.Columns[10].Visible = false;
            dgvPrincipal.Columns[11].Visible = false;
           
        }

        private void Listado_sp(string texto)
        {
            try
            {
                dgvPrincipal.DataSource = N_Salida_Productos.Listado_sp(texto);
                this.Formato_sp();

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
            this.btnAgregar.Visible = lEstado;
            this.btnEliminar.Visible = !lEstado;
            this.btn_lupa1.Visible = lEstado;
            this.btn_lupa2.Visible = lEstado;
          
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                this.Codigo_sp = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_sp"].Value);
                this.Codigo_tde = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_tde"].Value);
                this.Codigo_cl = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["codigo_cl"].Value);
                txt_descripcion_tipo_documento.Text = dgvPrincipal.CurrentRow.Cells["descripcion_tde"].Value.ToString();
                txt_NroDocumento.Text = dgvPrincipal.CurrentRow.Cells["nrodocumento_sp"].Value.ToString();
                Dtp_Fecha.Value = Convert.ToDateTime(dgvPrincipal.CurrentRow.Cells["fecha_sp"].Value);
                txt_nrodoc_cl.Text = dgvPrincipal.CurrentRow.Cells["razonsocial_cl"].Value.ToString();
                txt_Observaciones.Text = dgvPrincipal.CurrentRow.Cells["observacion_sp"].Value.ToString();
                txt_iva.Text = dgvPrincipal.CurrentRow.Cells["subtotal"].Value.ToString();
                txt_Subtotal.Text = dgvPrincipal.CurrentRow.Cells["iva"].Value.ToString();
                txtTotal.Text = dgvPrincipal.CurrentRow.Cells["total_importe"].Value.ToString();


                Dgv_Detalle.DataSource = N_Salida_Productos.Listado_detalle_sp(this.Codigo_sp);
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
            this.Tabla_Detalle.Columns.Add("pu_venta", Type.GetType("System.Decimal"));
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
        private void AgregarItem(string  Descripcion_pr,string Descripcion_ma,string Descripcion_um,decimal Cantidad,decimal Pu_venta,decimal Total,int Codigo_pr)
        {
            DataRow xFila = Tabla_Detalle.NewRow();
            xFila["descripcion"] = Descripcion_pr;
            xFila["descripcion_ma"] = Descripcion_ma;
            xFila["descripcion_um"] = Descripcion_um;
            xFila["cantidad"] = Cantidad;
            xFila["pu_venta"] = Pu_venta;
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
                dgv_TipoDocumento.DataSource =N_Salida_Productos.Listado_tde_sp();
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

       
      

       


        private void Formato_cl()
        {
            dgv_clientes.Columns[0].Width = 150;
            dgv_clientes.Columns[0].HeaderText = "CLIENTE";
            dgv_clientes.Columns[1].Width = 80;
            dgv_clientes.Columns[1].HeaderText = "TIPO DOC";
            dgv_clientes.Columns[2].Width = 100;
            dgv_clientes.Columns[2].HeaderText = "NRO DOC";
            dgv_clientes.Columns[3].Visible = false;
        }

        private void Listado_cl(string Texto)
        {
            try
            {
                dgv_clientes.DataSource = N_Salida_Productos.Listado_cl_sp(Texto);
                this.Formato_cl();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaItem_cl()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_clientes.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("El Listado esta Vacio", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_cl = Convert.ToInt32(dgv_clientes.CurrentRow.Cells["codigo_cl"].Value);
                txt_razonsocial_cl.Text= Convert.ToString(dgv_clientes.CurrentRow.Cells["razon_social_cl"].Value);
                txt_nrodoc_cl.Text = Convert.ToString(dgv_clientes.CurrentRow.Cells["nrodocumento_cl"].Value);
                if (this.Codigo_cl==1)//es el cliente generico
                {
                    txt_nrodoc_cl.ReadOnly = false;
                    txt_razonsocial_cl.ReadOnly=false;
                }
                else//demas clientes 
                {
                    txt_nrodoc_cl.ReadOnly = true;
                    txt_razonsocial_cl.ReadOnly = true;
                    txt_nrodoc_cl.Focus();
                }
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
            dgv_pruductos.Columns[4].Width = 100;
            dgv_pruductos.Columns[4].HeaderText = "STOCK ACTUAL";
            dgv_pruductos.Columns[5].Width = 100;
            dgv_pruductos.Columns[5].HeaderText = "P.U. VENTA";
            dgv_pruductos.Columns[6].Visible = false;
        
        }

        private void Listado_pr(string Texto)
        {
            try
            {
                dgv_pruductos.DataSource = N_Salida_Productos.Listado_pr_sp(Texto);
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
                decimal xPu_Venta;
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
                    xCantidad = Convert.ToDecimal(dgv_pruductos.CurrentRow.Cells["stock_actual"].Value);
                    xPu_Venta = Convert.ToDecimal(dgv_pruductos.CurrentRow.Cells["pu_venta"].Value);
                    xTotal =decimal.Round(xCantidad * xPu_Venta,2);

                    this.AgregarItem(xDescripcion_pr, xDescripcion_ma, xDescripcion_um, xCantidad, xPu_Venta, xTotal, xCodigo_pr);
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
            txt_nrodoc_cl.Text = "";
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

        private void Frm_Salida_Productos_Load(object sender, EventArgs e)
        {
              this.Listado_sp("%");
              this.Listado_tdpe();
              this.Listado_cl("%");
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_NroDocumento.Text == String.Empty || txt_descripcion_tipo_documento.Text == String.Empty || txt_nrodoc_cl.Text==string.Empty||
                Dgv_Detalle.Rows.Count==0)
            {
                MessageBox.Show("Ingrese los datos requeridos (*)", "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string Rpta = "";
                E_Salida_Productos oSp = new E_Salida_Productos ();
                oSp.Codigo_sp = this.Codigo_sp;
                oSp.Codigo_tde = this.Codigo_tde;
                oSp.NroDocumento_sp = txt_NroDocumento.Text.Trim();
                oSp.Codigo_cl=this.Codigo_cl;
                oSp.Nrodocumento_cl=txt_nrodoc_cl.Text.Trim();
                oSp.Razon_social_cl = txt_razonsocial_cl.Text.Trim();
                oSp.Fecha_sp = Dtp_Fecha.Value;
                oSp.Observacion = txt_Observaciones.Text.Trim();
                oSp.Subtotal =Convert.ToDecimal(txt_iva.Text.Trim());
                oSp.Iva = Convert.ToDecimal(txt_Subtotal.Text.Trim());
                oSp.Importe_Total = Convert.ToDecimal(txtTotal.Text.Trim());
                this.Tabla_Detalle.AcceptChanges();

                Rpta = N_Salida_Productos.Guardar_sp(oSp,Tabla_Detalle);
                if (Rpta!=String.Empty)
                {
                    this.Codigo_sp =Convert.ToInt32(Rpta);//Salida de Datos para generar posible tickect
                    MessageBox.Show("El producto se Guardo de Forma Correcta!!! "+this.Codigo_sp, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    this.Estado_texto(false);
                    Dgv_Detalle.Columns[3].ReadOnly = true;
                    tabControlPrincipaL.SelectedIndex = 0;

                    
                    this.Codigo_sp = 0;
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
           
            this.Estado_texto(true);
          
            tabControlPrincipaL.SelectedIndex = 0;
            txt_NroDocumento.Focus();
           
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {

           
            this.Estado_guarda=0;
            this.Codigo_sp= 0;
            this.Codigo_tde = 0;
            this.Codigo_cl= 0;
            
          
            this.Estado_texto(false);
            this.Limpia_texto();
            Dgv_Detalle.Columns[3].ReadOnly = true;
            
            this.Estado_Botones_Principales(true);
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;


        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;
           
          
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
                    this.Codigo_sp = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells[0].Value);
                    Rpta = N_Salida_Productos.Eliminar_sp(this.Codigo_sp);

                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_sp("%");
                        this.Limpia_texto();
                        this.Codigo_sp = 0;
                        MessageBox.Show("Registro Anulado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tabControlPrincipaL.SelectedIndex = 1;

                    }

                }


            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_sp(txtBuscar.Text.Trim());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Salida_Productos oRp2 = new Reportes.Frm_Rpt_Salida_Productos();
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
            this.p_Clientes.Location = btn_lupa1.Location;
            this.p_Clientes.Visible = true;
        }

       
        
        private void btnvolver2_Click(object sender, EventArgs e)
        {
            p_listado_TD.Visible=false;
        }


        private void dgvPrincipal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botones_Procesos(false);
            tabControlPrincipaL.SelectedIndex = 0;
            
        }

       

        private void dgv_TipoDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionaItem_tdpe();
            p_listado_TD.Visible = false;
            txt_NroDocumento.Focus();
        }

        

       
        private void btn_lupa_5_Click(object sender, EventArgs e)
        {
            this.p_Clientes.Location = btn_lupa1.Location;
            this.p_Clientes.Visible = true;
        }

        private void btn_volver_ci_Click(object sender, EventArgs e)
        {
            p_Clientes.Visible=false;
        }

        private void bnt_buscar_ci_Click(object sender, EventArgs e)
        {
            this.Listado_sp(txt_Buscar_clientes.Text);
        }

        private void dgv_Proveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.SeleccionaItem_cl();
            p_Clientes.Visible = false;
          
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
                decimal yPu_venta = Convert.ToDecimal(yFila["pu_venta"]);
                yFila["Total"] = decimal.Round(yCantidad * yPu_venta, 2).ToString("#0.00");
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
            this.SeleccionaItem_cl();
            p_Clientes.Visible = false;
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

            tabControlPrincipaL.SelectedIndex = 0;
        }
    }
}
