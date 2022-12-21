namespace Presentacion.Repotes_Bitacora
{
    partial class Frm_Rpt_Salida_VentasxProductos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uSPReporteSalidaVentasxProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset_Reportes_Bitacora = new Presentacion.Repotes_Bitacora.Dataset_Reportes_Bitacora();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_Reporte_Salida_VentasxProductosTableAdapter = new Presentacion.Repotes_Bitacora.Dataset_Reportes_BitacoraTableAdapters.USP_Reporte_Salida_VentasxProductosTableAdapter();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteSalidaVentasxProductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset_Reportes_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPReporteSalidaVentasxProductosBindingSource
            // 
            this.uSPReporteSalidaVentasxProductosBindingSource.DataMember = "USP_Reporte_Salida_VentasxProductos";
            this.uSPReporteSalidaVentasxProductosBindingSource.DataSource = this.dataset_Reportes_Bitacora;
            // 
            // dataset_Reportes_Bitacora
            // 
            this.dataset_Reportes_Bitacora.DataSetName = "Dataset_Reportes_Bitacora";
            this.dataset_Reportes_Bitacora.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPReporteSalidaVentasxProductosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Repotes_Bitacora.Rpt_Salidas_VentaxProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1183, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSP_Reporte_Salida_VentasxProductosTableAdapter
            // 
            this.uSP_Reporte_Salida_VentasxProductosTableAdapter.ClearBeforeFill = true;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(185, 119);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(155, 20);
            this.txt1.TabIndex = 1;
            this.txt1.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(185, 178);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(155, 20);
            this.txt2.TabIndex = 2;
            this.txt2.Visible = false;
            // 
            // Frm_Rpt_Salida_VentasxProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 450);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Salida_VentasxProductos";
            this.Text = "Repote Salida Ventas x Productos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Salida_VentasxProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteSalidaVentasxProductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset_Reportes_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPReporteSalidaVentasxProductosBindingSource;
        private Dataset_Reportes_Bitacora dataset_Reportes_Bitacora;
        private Dataset_Reportes_BitacoraTableAdapters.USP_Reporte_Salida_VentasxProductosTableAdapter uSP_Reporte_Salida_VentasxProductosTableAdapter;
        public System.Windows.Forms.TextBox txt1;
        public System.Windows.Forms.TextBox txt2;
    }
}