namespace refriauto
{
    partial class Errores
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
            this.lb_nombres = new System.Windows.Forms.Label();
            this.lb_ubicaciones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_nombres
            // 
            this.lb_nombres.AutoSize = true;
            this.lb_nombres.Location = new System.Drawing.Point(12, 9);
            this.lb_nombres.Name = "lb_nombres";
            this.lb_nombres.Size = new System.Drawing.Size(47, 13);
            this.lb_nombres.TabIndex = 0;
            this.lb_nombres.Text = "Nombre:";
            this.lb_nombres.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_ubicaciones
            // 
            this.lb_ubicaciones.AutoSize = true;
            this.lb_ubicaciones.Location = new System.Drawing.Point(121, 9);
            this.lb_ubicaciones.Name = "lb_ubicaciones";
            this.lb_ubicaciones.Size = new System.Drawing.Size(58, 13);
            this.lb_ubicaciones.TabIndex = 1;
            this.lb_ubicaciones.Text = "Ubicación:";
            // 
            // Errores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 385);
            this.Controls.Add(this.lb_ubicaciones);
            this.Controls.Add(this.lb_nombres);
            this.Name = "Errores";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Errores";
            this.Load += new System.EventHandler(this.Errores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lb_ubicaciones;
        public System.Windows.Forms.Label lb_nombres;
    }
}