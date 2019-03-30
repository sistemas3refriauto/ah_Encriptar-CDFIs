namespace refriauto
{
    partial class Validar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_sucursal = new System.Windows.Forms.ComboBox();
            this.tb_inicial = new System.Windows.Forms.TextBox();
            this.tb_final = new System.Windows.Forms.TextBox();
            this.lb_faltantes = new System.Windows.Forms.Label();
            this.dgv_faltantes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pb_progreso = new System.Windows.Forms.ProgressBar();
            this.lb_tiempo = new System.Windows.Forms.Label();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sucursal:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folio Inicial:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Folio Final:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(294, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Menú principal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Verificar folios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_sucursal
            // 
            this.cb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sucursal.FormattingEnabled = true;
            this.cb_sucursal.Items.AddRange(new object[] {
            "Sucursal",
            "Caborca",
            "Cd. Obregon",
            "Chihuahua",
            "Coatzacoalcos",
            "Comalcalco",
            "Guadalajara",
            "Hermosillo ( Bodega )",
            "Hermosillo ( Gaspar Luken )",
            "Hermosillo ( Modelo )",
            "Hermosillo ( San Benito )",
            "Hermosillo ( Taller )",
            "La Paz",
            "Los Mochis",
            "Mexicali",
            "Navojoa",
            "Tuxtla Gutierrez",
            "Veracruz",
            "Villa Hermosa"});
            this.cb_sucursal.Location = new System.Drawing.Point(112, 75);
            this.cb_sucursal.Name = "cb_sucursal";
            this.cb_sucursal.Size = new System.Drawing.Size(235, 21);
            this.cb_sucursal.TabIndex = 24;
            this.cb_sucursal.SelectedIndexChanged += new System.EventHandler(this.Sucursal_SelectedIndexChanged);
            // 
            // tb_inicial
            // 
            this.tb_inicial.Location = new System.Drawing.Point(128, 114);
            this.tb_inicial.Name = "tb_inicial";
            this.tb_inicial.Size = new System.Drawing.Size(219, 20);
            this.tb_inicial.TabIndex = 25;
            this.tb_inicial.WordWrap = false;
            this.tb_inicial.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tb_inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tb_final
            // 
            this.tb_final.Location = new System.Drawing.Point(128, 151);
            this.tb_final.Name = "tb_final";
            this.tb_final.Size = new System.Drawing.Size(219, 20);
            this.tb_final.TabIndex = 26;
            this.tb_final.WordWrap = false;
            this.tb_final.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.tb_final.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lb_faltantes
            // 
            this.lb_faltantes.ForeColor = System.Drawing.Color.Black;
            this.lb_faltantes.Location = new System.Drawing.Point(56, 269);
            this.lb_faltantes.Name = "lb_faltantes";
            this.lb_faltantes.Size = new System.Drawing.Size(291, 23);
            this.lb_faltantes.TabIndex = 29;
            this.lb_faltantes.Text = "Faltantes";
            this.lb_faltantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_faltantes.Visible = false;
            // 
            // dgv_faltantes
            // 
            this.dgv_faltantes.AllowUserToAddRows = false;
            this.dgv_faltantes.AllowUserToDeleteRows = false;
            this.dgv_faltantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_faltantes.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_faltantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_faltantes.Location = new System.Drawing.Point(376, 75);
            this.dgv_faltantes.Name = "dgv_faltantes";
            this.dgv_faltantes.ReadOnly = true;
            this.dgv_faltantes.Size = new System.Drawing.Size(162, 314);
            this.dgv_faltantes.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.Image = global::refriauto.Properties.Resources.refriauto_marca_de_agua1;
            this.label4.Location = new System.Drawing.Point(375, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 67);
            this.label4.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(559, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Validar existencia de facturas";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pb_progreso
            // 
            this.pb_progreso.Location = new System.Drawing.Point(53, 295);
            this.pb_progreso.Name = "pb_progreso";
            this.pb_progreso.Size = new System.Drawing.Size(294, 23);
            this.pb_progreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progreso.TabIndex = 34;
            // 
            // lb_tiempo
            // 
            this.lb_tiempo.ForeColor = System.Drawing.Color.Gray;
            this.lb_tiempo.Location = new System.Drawing.Point(53, 321);
            this.lb_tiempo.Name = "lb_tiempo";
            this.lb_tiempo.Size = new System.Drawing.Size(294, 23);
            this.lb_tiempo.TabIndex = 35;
            this.lb_tiempo.Text = "Tiempo de ejecución";
            this.lb_tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_tipo
            // 
            this.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Items.AddRange(new object[] {
            "I - Factura",
            "E - Nota de crédito",
            "P - Comprobante de pago"});
            this.cb_tipo.Location = new System.Drawing.Point(128, 182);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(219, 21);
            this.cb_tipo.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tipo:";
            // 
            // Validar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(583, 416);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_tipo);
            this.Controls.Add(this.lb_tiempo);
            this.Controls.Add(this.pb_progreso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_faltantes);
            this.Controls.Add(this.lb_faltantes);
            this.Controls.Add(this.tb_final);
            this.Controls.Add(this.tb_inicial);
            this.Controls.Add(this.cb_sucursal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "Validar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar existencia de facturas";
            this.Load += new System.EventHandler(this.Validar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faltantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_sucursal;
        private System.Windows.Forms.TextBox tb_inicial;
        private System.Windows.Forms.TextBox tb_final;
        private System.Windows.Forms.Label lb_faltantes;
        private System.Windows.Forms.DataGridView dgv_faltantes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pb_progreso;
        private System.Windows.Forms.Label lb_tiempo;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.Label label6;
    }
}