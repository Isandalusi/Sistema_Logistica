namespace Presentacion
{
    partial class MDI_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_Principal));
            this.Mi_Menu = new System.Windows.Forms.MenuStrip();
            this.Datos = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadDeMedidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesYProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubicacionGeográficaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciudadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Movimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasDeProductosComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasDeProductosVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasDeVentasPorProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sistemas = new System.Windows.Forms.ToolStripMenuItem();
            this.rolDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mi_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mi_Menu
            // 
            this.Mi_Menu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mi_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Datos,
            this.Movimientos,
            this.Reportes,
            this.Sistemas,
            this.sALIRToolStripMenuItem});
            this.Mi_Menu.Location = new System.Drawing.Point(0, 0);
            this.Mi_Menu.Name = "Mi_Menu";
            this.Mi_Menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.Mi_Menu.Size = new System.Drawing.Size(1539, 29);
            this.Mi_Menu.TabIndex = 1;
            this.Mi_Menu.Text = "menuStrip1";
            // 
            // Datos
            // 
            this.Datos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.almacenToolStripMenuItem,
            this.clientesYProveedoresToolStripMenuItem,
            this.ubicacionGeográficaToolStripMenuItem});
            this.Datos.Name = "Datos";
            this.Datos.Size = new System.Drawing.Size(166, 25);
            this.Datos.Tag = "";
            this.Datos.Text = "DATOS GENERALES";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem1,
            this.marcasToolStripMenuItem,
            this.unidadDeMedidaToolStripMenuItem,
            this.categoriasToolStripMenuItem});
            this.productosToolStripMenuItem.Image = global::Presentacion.Properties.Resources.recibido;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Image = global::Presentacion.Properties.Resources.recibido;
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(221, 26);
            this.productosToolStripMenuItem1.Text = "Productos";
            this.productosToolStripMenuItem1.Click += new System.EventHandler(this.productosToolStripMenuItem1_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Image = global::Presentacion.Properties.Resources.producto;
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // unidadDeMedidaToolStripMenuItem
            // 
            this.unidadDeMedidaToolStripMenuItem.Image = global::Presentacion.Properties.Resources.producto;
            this.unidadDeMedidaToolStripMenuItem.Name = "unidadDeMedidaToolStripMenuItem";
            this.unidadDeMedidaToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.unidadDeMedidaToolStripMenuItem.Text = "Unidad de Medida";
            this.unidadDeMedidaToolStripMenuItem.Click += new System.EventHandler(this.unidadDeMedidaToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Image = global::Presentacion.Properties.Resources.producto;
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // almacenToolStripMenuItem
            // 
            this.almacenToolStripMenuItem.Image = global::Presentacion.Properties.Resources.warehouse_storage_unit_storehouse_icon_192428;
            this.almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
            this.almacenToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.almacenToolStripMenuItem.Text = "Almacen";
            this.almacenToolStripMenuItem.Click += new System.EventHandler(this.almacenToolStripMenuItem_Click);
            // 
            // clientesYProveedoresToolStripMenuItem
            // 
            this.clientesYProveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.rubrosToolStripMenuItem});
            this.clientesYProveedoresToolStripMenuItem.Image = global::Presentacion.Properties.Resources.clasificacion;
            this.clientesYProveedoresToolStripMenuItem.Name = "clientesYProveedoresToolStripMenuItem";
            this.clientesYProveedoresToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.clientesYProveedoresToolStripMenuItem.Text = "Clientes y Proveedores";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::Presentacion.Properties.Resources.servicio_al_cliente;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Image = global::Presentacion.Properties.Resources.mensajero;
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // rubrosToolStripMenuItem
            // 
            this.rubrosToolStripMenuItem.Image = global::Presentacion.Properties.Resources.producto;
            this.rubrosToolStripMenuItem.Name = "rubrosToolStripMenuItem";
            this.rubrosToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.rubrosToolStripMenuItem.Text = "Rubros";
            this.rubrosToolStripMenuItem.Click += new System.EventHandler(this.rubrosToolStripMenuItem_Click);
            // 
            // ubicacionGeográficaToolStripMenuItem
            // 
            this.ubicacionGeográficaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciudadesToolStripMenuItem,
            this.provinciasToolStripMenuItem,
            this.paisesToolStripMenuItem});
            this.ubicacionGeográficaToolStripMenuItem.Image = global::Presentacion.Properties.Resources.global;
            this.ubicacionGeográficaToolStripMenuItem.Name = "ubicacionGeográficaToolStripMenuItem";
            this.ubicacionGeográficaToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.ubicacionGeográficaToolStripMenuItem.Text = "Ubicacion Geográfica";
            // 
            // ciudadesToolStripMenuItem
            // 
            this.ciudadesToolStripMenuItem.Image = global::Presentacion.Properties.Resources.localizacion;
            this.ciudadesToolStripMenuItem.Name = "ciudadesToolStripMenuItem";
            this.ciudadesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.ciudadesToolStripMenuItem.Text = "Ciudades";
            this.ciudadesToolStripMenuItem.Click += new System.EventHandler(this.ciudadesToolStripMenuItem_Click);
            // 
            // provinciasToolStripMenuItem
            // 
            this.provinciasToolStripMenuItem.Image = global::Presentacion.Properties.Resources.localizacion;
            this.provinciasToolStripMenuItem.Name = "provinciasToolStripMenuItem";
            this.provinciasToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.provinciasToolStripMenuItem.Text = "Provincias";
            this.provinciasToolStripMenuItem.Click += new System.EventHandler(this.provinciasToolStripMenuItem_Click);
            // 
            // paisesToolStripMenuItem
            // 
            this.paisesToolStripMenuItem.Image = global::Presentacion.Properties.Resources.localizacion;
            this.paisesToolStripMenuItem.Name = "paisesToolStripMenuItem";
            this.paisesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.paisesToolStripMenuItem.Text = "Paises";
            this.paisesToolStripMenuItem.Click += new System.EventHandler(this.paisesToolStripMenuItem_Click);
            // 
            // Movimientos
            // 
            this.Movimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasDeProductosComprasToolStripMenuItem,
            this.salidasDeProductosVentasToolStripMenuItem});
            this.Movimientos.Name = "Movimientos";
            this.Movimientos.Size = new System.Drawing.Size(136, 25);
            this.Movimientos.Tag = "";
            this.Movimientos.Text = "MOVIMIENTOS";
            // 
            // entradasDeProductosComprasToolStripMenuItem
            // 
            this.entradasDeProductosComprasToolStripMenuItem.Image = global::Presentacion.Properties.Resources.verificar;
            this.entradasDeProductosComprasToolStripMenuItem.Name = "entradasDeProductosComprasToolStripMenuItem";
            this.entradasDeProductosComprasToolStripMenuItem.Size = new System.Drawing.Size(333, 26);
            this.entradasDeProductosComprasToolStripMenuItem.Text = "Entradas de productos (Compras)";
            this.entradasDeProductosComprasToolStripMenuItem.Click += new System.EventHandler(this.entradasDeProductosComprasToolStripMenuItem_Click);
            // 
            // salidasDeProductosVentasToolStripMenuItem
            // 
            this.salidasDeProductosVentasToolStripMenuItem.Image = global::Presentacion.Properties.Resources.punto_de_venta;
            this.salidasDeProductosVentasToolStripMenuItem.Name = "salidasDeProductosVentasToolStripMenuItem";
            this.salidasDeProductosVentasToolStripMenuItem.Size = new System.Drawing.Size(333, 26);
            this.salidasDeProductosVentasToolStripMenuItem.Text = "Salidas de productos (Ventas)";
            this.salidasDeProductosVentasToolStripMenuItem.Click += new System.EventHandler(this.salidasDeProductosVentasToolStripMenuItem_Click);
            // 
            // Reportes
            // 
            this.Reportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem,
            this.salidasToolStripMenuItem});
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(100, 25);
            this.Reportes.Tag = "";
            this.Reportes.Text = "REPORTES";
            // 
            // reporteDeIngresoDeComprasPorProductosToolStripMenuItem
            // 
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1});
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem.Name = "reporteDeIngresoDeComprasPorProductosToolStripMenuItem";
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem.Text = "Ingresos";
            // 
            // reporteDeIngresoDeComprasPorProductosToolStripMenuItem1
            // 
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1.Name = "reporteDeIngresoDeComprasPorProductosToolStripMenuItem1";
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1.Size = new System.Drawing.Size(340, 26);
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1.Text = "Ingreso de compras por productos";
            this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1.Click += new System.EventHandler(this.reporteDeIngresoDeComprasPorProductosToolStripMenuItem1_Click);
            // 
            // salidasToolStripMenuItem
            // 
            this.salidasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidasDeVentasPorProductosToolStripMenuItem});
            this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
            this.salidasToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.salidasToolStripMenuItem.Text = "Salidas";
            // 
            // salidasDeVentasPorProductosToolStripMenuItem
            // 
            this.salidasDeVentasPorProductosToolStripMenuItem.Name = "salidasDeVentasPorProductosToolStripMenuItem";
            this.salidasDeVentasPorProductosToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.salidasDeVentasPorProductosToolStripMenuItem.Text = "Salida de ventas por productos";
            this.salidasDeVentasPorProductosToolStripMenuItem.Click += new System.EventHandler(this.salidasDeVentasPorProductosToolStripMenuItem_Click);
            // 
            // Sistemas
            // 
            this.Sistemas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolDeUsuariosToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.Sistemas.Name = "Sistemas";
            this.Sistemas.Size = new System.Drawing.Size(98, 25);
            this.Sistemas.Tag = "";
            this.Sistemas.Text = "SISTEMAS";
            // 
            // rolDeUsuariosToolStripMenuItem
            // 
            this.rolDeUsuariosToolStripMenuItem.Name = "rolDeUsuariosToolStripMenuItem";
            this.rolDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.rolDeUsuariosToolStripMenuItem.Text = "Rol de Usuarios";
            this.rolDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.rolDeUsuariosToolStripMenuItem_Click);
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirDelSistemaToolStripMenuItem});
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(65, 25);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Image = global::Presentacion.Properties.Resources.cerrar_sesion;
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // MDI_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 796);
            this.Controls.Add(this.Mi_Menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Mi_Menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDI_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA  LOGISTICA(version 1.0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Principal_Load);
            this.Mi_Menu.ResumeLayout(false);
            this.Mi_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Mi_Menu;
        private System.Windows.Forms.ToolStripMenuItem Datos;
        private System.Windows.Forms.ToolStripMenuItem Movimientos;
        private System.Windows.Forms.ToolStripMenuItem Reportes;
        private System.Windows.Forms.ToolStripMenuItem Sistemas;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadDeMedidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesYProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubicacionGeográficaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciudadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasDeProductosComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasDeProductosVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeIngresoDeComprasPorProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeIngresoDeComprasPorProductosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasDeVentasPorProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}