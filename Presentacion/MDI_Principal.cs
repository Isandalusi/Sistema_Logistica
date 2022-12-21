using Mapper;
using Presentacion.Reportes;
using Presentacion.Repotes_Bitacora;
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
    public partial class MDI_Principal : Form
    {
        public string nombreUsuario { get; set; }

        public MDI_Principal()
        {
            InitializeComponent();
        }
        public MDI_Principal(int pIdRol)
        {
            InitializeComponent();
            IdRol = pIdRol;
        }
        int IdRol;
        M_RolUsuario Mru = new M_RolUsuario();

        private void ConsultarRol(ToolStripMenuItem pTool)
        {
            var LstOp = Mru.SelectOption(IdRol);
            foreach (ToolStripMenuItem tool in pTool.DropDownItems)
            {
                foreach (var opc in LstOp)
                {
                    if (opc.OpcionId==Convert.ToInt32(tool.Tag))
                    {
                        if (!opc.Permitido)
                            tool.Enabled = true;
                    }
                }
            }
        }


        private void MDI_Principal_Load(object sender, EventArgs e)
        {

            ConsultarRol(Datos);
            ConsultarRol(Movimientos);
            ConsultarRol(Reportes);
            ConsultarRol(Sistemas);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Productos oFrm_pro = new Frm_Productos();
            oFrm_pro.MdiParent = this;
            oFrm_pro.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pro.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Marcas oFrm_ma = new Frm_Marcas();
            oFrm_ma.MdiParent = this;
            oFrm_ma.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ma.Show();
        }

        private void unidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Unidades_Medidas oFrm_um = new Frm_Unidades_Medidas();
            oFrm_um.MdiParent = this;
            oFrm_um.StartPosition = FormStartPosition.CenterScreen;
            oFrm_um.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria oFrm_ca = new FrmCategoria();
            oFrm_ca.MdiParent = this;
            oFrm_ca.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ca.Show();
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Almacenes oFrm_al = new Frm_Almacenes();
            oFrm_al.MdiParent = this;
            oFrm_al.StartPosition = FormStartPosition.CenterScreen;
            oFrm_al.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Clientes oFrm_cli=new Frm_Clientes();
            oFrm_cli.MdiParent = this;
            oFrm_cli.StartPosition = FormStartPosition.CenterScreen;
            oFrm_cli.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Proveedores oFrm_pv = new Frm_Proveedores();
            oFrm_pv.MdiParent = this;
            oFrm_pv.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pv.Show();
        }

        private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Rubros oFrm_ru = new Frm_Rubros();
            oFrm_ru.MdiParent = this;
            oFrm_ru.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ru.Show();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Ciudad oFrm_ci = new Frm_Ciudad();
            oFrm_ci.MdiParent = this;
            oFrm_ci.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ci.Show();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Frm_Provincias oFrm_pr=new Frm_Provincias();
            oFrm_pr.MdiParent = this;
            oFrm_pr.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pr.Show();
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PAISES oFrm_pa=new Frm_PAISES();
            oFrm_pa.MdiParent = this;
            oFrm_pa.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pa.Show();
        }

        private void entradasDeProductosComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Entrada_Productos oFrm_ep = new Frm_Entrada_Productos();
            oFrm_ep.MdiParent = this;
            oFrm_ep.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ep.Show();
        }

        private void salidasDeProductosVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Salida_Productos oFrm_sp = new Frm_Salida_Productos();
            oFrm_sp.MdiParent = this;
            oFrm_sp.StartPosition = FormStartPosition.CenterScreen;
            oFrm_sp.Show();
        }

        private void tb_Producto_Click(object sender, EventArgs e)
        {
            Frm_Productos oFrm_pro = new Frm_Productos();
            oFrm_pro.MdiParent = this;
            oFrm_pro.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pro.Show();
        }

        private void tb_Clientes_Click(object sender, EventArgs e)
        {
            Frm_Clientes oFrm_cli = new Frm_Clientes();
            oFrm_cli.MdiParent = this;
            oFrm_cli.StartPosition = FormStartPosition.CenterScreen;
            oFrm_cli.Show();
        }

        private void tb_Proveedores_Click(object sender, EventArgs e)
        {
            Frm_Proveedores oFrm_pv = new Frm_Proveedores();
            oFrm_pv.MdiParent = this;
            oFrm_pv.StartPosition = FormStartPosition.CenterScreen;
            oFrm_pv.Show();
        }

        private void tb_Entradas_Click(object sender, EventArgs e)
        {
            Frm_Entrada_Productos oFrm_ep = new Frm_Entrada_Productos();
            oFrm_ep.MdiParent = this;
            oFrm_ep.StartPosition = FormStartPosition.CenterScreen;
            oFrm_ep.Show();
        }

        private void tb_Salidas_Click(object sender, EventArgs e)
        {
            Frm_Salida_Productos oFrm_sp = new Frm_Salida_Productos();
            oFrm_sp.MdiParent = this;
            oFrm_sp.StartPosition = FormStartPosition.CenterScreen;
            oFrm_sp.Show();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void reporteDeIngresoDeComprasPorProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Repotes_Bitacora.Frm_Reporte_Ingreso_ComprasxProductos oFrm_rep1 = new Repotes_Bitacora.Frm_Reporte_Ingreso_ComprasxProductos();
            oFrm_rep1.MdiParent = this;
            oFrm_rep1.StartPosition = FormStartPosition.CenterScreen;
            oFrm_rep1.Show();
        }

        private void salidasDeVentasPorProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repotes_Bitacora.Frm_Reporte_Salida_VentasxProductos oFrm_rep2 = new Repotes_Bitacora.Frm_Reporte_Salida_VentasxProductos();
            oFrm_rep2.MdiParent = this;
            oFrm_rep2.StartPosition = FormStartPosition.CenterScreen;
            oFrm_rep2.Show();
        }

        private void rolDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RolUsuario oFrm_rol = new Frm_RolUsuario();
            oFrm_rol.MdiParent = this;
            oFrm_rol.StartPosition = FormStartPosition.CenterScreen;
            oFrm_rol.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario2 oFrm_rol = new FrmUsuario2();
            oFrm_rol.MdiParent = this;
            oFrm_rol.StartPosition = FormStartPosition.CenterScreen;
            oFrm_rol.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Mi_Barra_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
