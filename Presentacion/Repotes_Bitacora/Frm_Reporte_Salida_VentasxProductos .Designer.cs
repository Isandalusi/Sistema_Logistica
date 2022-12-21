namespace Presentacion.Repotes_Bitacora
{
    partial class Frm_Reporte_Salida_VentasxProductos
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dt_Fecha_ini = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_Fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.btn_VPrevia = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_Fecha_ini
            // 
            this.dt_Fecha_ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_Fecha_ini.Location = new System.Drawing.Point(167, 60);
            this.dt_Fecha_ini.Name = "dt_Fecha_ini";
            this.dt_Fecha_ini.Size = new System.Drawing.Size(115, 26);
            this.dt_Fecha_ini.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Fin :";
            // 
            // dt_Fecha_fin
            // 
            this.dt_Fecha_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_Fecha_fin.Location = new System.Drawing.Point(167, 125);
            this.dt_Fecha_fin.Name = "dt_Fecha_fin";
            this.dt_Fecha_fin.Size = new System.Drawing.Size(115, 26);
            this.dt_Fecha_fin.TabIndex = 2;
            // 
            // btn_VPrevia
            // 
            this.btn_VPrevia.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_VPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VPrevia.Location = new System.Drawing.Point(328, 60);
            this.btn_VPrevia.Name = "btn_VPrevia";
            this.btn_VPrevia.Size = new System.Drawing.Size(102, 31);
            this.btn_VPrevia.TabIndex = 4;
            this.btn_VPrevia.Text = "Vista Previa";
            this.btn_VPrevia.UseVisualStyleBackColor = false;
            this.btn_VPrevia.Click += new System.EventHandler(this.btn_VPrevia_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salir.Location = new System.Drawing.Point(328, 105);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(102, 31);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // Frm_Reporte_Salida_VentasxProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 229);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_VPrevia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_Fecha_fin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_Fecha_ini);
            this.Name = "Frm_Reporte_Salida_VentasxProductos";
            this.Text = "Reporte de Salida de VentasxProductos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DateTimePicker dt_Fecha_ini;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_Fecha_fin;
        private System.Windows.Forms.Button btn_VPrevia;
        private System.Windows.Forms.Button btn_Salir;
    }
}