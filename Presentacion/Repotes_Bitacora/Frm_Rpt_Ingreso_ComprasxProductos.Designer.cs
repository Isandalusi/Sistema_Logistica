namespace Presentacion.Repotes_Bitacora
{
    partial class Frm_Rpt_Ingreso_ComprasxProductos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uSPReporteIngresoComprasxProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset_Reportes_Bitacora = new Presentacion.Repotes_Bitacora.Dataset_Reportes_Bitacora();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_Reporte_Ingreso_ComprasxProductosTableAdapter = new Presentacion.Repotes_Bitacora.Dataset_Reportes_BitacoraTableAdapters.USP_Reporte_Ingreso_ComprasxProductosTableAdapter();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteIngresoComprasxProductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset_Reportes_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPReporteIngresoComprasxProductosBindingSource
            // 
            this.uSPReporteIngresoComprasxProductosBindingSource.DataMember = "USP_Reporte_Ingreso_ComprasxProductos";
            this.uSPReporteIngresoComprasxProductosBindingSource.DataSource = this.dataset_Reportes_Bitacora;
            // 
            // dataset_Reportes_Bitacora
            // 
            this.dataset_Reportes_Bitacora.DataSetName = "Dataset_Reportes_Bitacora";
            this.dataset_Reportes_Bitacora.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uSPReporteIngresoComprasxProductosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Repotes_Bitacora.Rpt_Ingreso_ComprasxProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1270, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSP_Reporte_Ingreso_ComprasxProductosTableAdapter
            // 
            this.uSP_Reporte_Ingreso_ComprasxProductosTableAdapter.ClearBeforeFill = true;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(103, 101);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(138, 20);
            this.txt1.TabIndex = 1;
            this.txt1.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(296, 101);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(138, 20);
            this.txt2.TabIndex = 2;
            this.txt2.Visible = false;
            // 
            // Frm_Rpt_Ingreso_ComprasxProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 450);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Ingreso_ComprasxProductos";
            this.Text = "Reporte_Ingreso_ComprasxProductos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Ingreso_ComprasxProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPReporteIngresoComprasxProductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset_Reportes_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPReporteIngresoComprasxProductosBindingSource;
        private Dataset_Reportes_Bitacora dataset_Reportes_Bitacora;
        private Dataset_Reportes_BitacoraTableAdapters.USP_Reporte_Ingreso_ComprasxProductosTableAdapter uSP_Reporte_Ingreso_ComprasxProductosTableAdapter;
        public System.Windows.Forms.TextBox txt2;
        public System.Windows.Forms.TextBox txt1;
    }
}