namespace refriauto
{
    partial class agregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregar));
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_examinar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lb_estado = new System.Windows.Forms.Label();
            this.lb_exito = new System.Windows.Forms.Label();
            this.lb_error = new System.Windows.Forms.Label();
            this.Sucursal = new System.Windows.Forms.ComboBox();
            this.bt_ftp = new System.Windows.Forms.Button();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_errores = new System.Windows.Forms.DataGridView();
            this.Errores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_detener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ftp = new System.Windows.Forms.ComboBox();
            this.pb_proceso = new System.Windows.Forms.ProgressBar();
            this.lb_poncentaje = new System.Windows.Forms.Label();
            this.lb_tiempo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_errores)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(617, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Encriptar Facturas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(294, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Menú principal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_examinar
            // 
            this.bt_examinar.Location = new System.Drawing.Point(57, 129);
            this.bt_examinar.Name = "bt_examinar";
            this.bt_examinar.Size = new System.Drawing.Size(294, 23);
            this.bt_examinar.TabIndex = 17;
            this.bt_examinar.Text = "Seleccionar Facturas desde Disco Duro";
            this.bt_examinar.UseVisualStyleBackColor = true;
            this.bt_examinar.Click += new System.EventHandler(this.bt_examinar_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lb_estado
            // 
            this.lb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_estado.ForeColor = System.Drawing.Color.Gray;
            this.lb_estado.Location = new System.Drawing.Point(57, 327);
            this.lb_estado.Name = "lb_estado";
            this.lb_estado.Size = new System.Drawing.Size(294, 18);
            this.lb_estado.TabIndex = 18;
            this.lb_estado.Text = "Esperando archivos";
            this.lb_estado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_estado.Click += new System.EventHandler(this.label3_Click);
            // 
            // lb_exito
            // 
            this.lb_exito.Location = new System.Drawing.Point(57, 357);
            this.lb_exito.Name = "lb_exito";
            this.lb_exito.Size = new System.Drawing.Size(294, 11);
            this.lb_exito.TabIndex = 19;
            this.lb_exito.Text = "Facturas capturadas con éxito: 0";
            this.lb_exito.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb_exito.Click += new System.EventHandler(this.lb_exito_Click);
            // 
            // lb_error
            // 
            this.lb_error.Location = new System.Drawing.Point(60, 382);
            this.lb_error.Name = "lb_error";
            this.lb_error.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_error.Size = new System.Drawing.Size(291, 13);
            this.lb_error.TabIndex = 20;
            this.lb_error.Text = "Error en 0 facturas";
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Sucursal
            // 
            this.Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sucursal.FormattingEnabled = true;
            this.Sucursal.Items.AddRange(new object[] {
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
            this.Sucursal.Location = new System.Drawing.Point(57, 102);
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.Size = new System.Drawing.Size(294, 21);
            this.Sucursal.TabIndex = 23;
            this.Sucursal.SelectedIndexChanged += new System.EventHandler(this.Sucursal_SelectedIndexChanged);
            // 
            // bt_ftp
            // 
            this.bt_ftp.Location = new System.Drawing.Point(57, 285);
            this.bt_ftp.Name = "bt_ftp";
            this.bt_ftp.Size = new System.Drawing.Size(294, 23);
            this.bt_ftp.TabIndex = 24;
            this.bt_ftp.Text = "Seleccionar Facturas desde FTP";
            this.bt_ftp.UseVisualStyleBackColor = true;
            this.bt_ftp.Click += new System.EventHandler(this.bt_ftp_Click);
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(112, 208);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(239, 20);
            this.tb_server.TabIndex = 25;
            this.tb_server.Text = "ftp://";
            // 
            // tb_user
            // 
            this.tb_user.Location = new System.Drawing.Point(112, 234);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(239, 20);
            this.tb_user.TabIndex = 26;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(125, 260);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(226, 20);
            this.tb_password.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Servidor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Usuario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Contraseña:";
            // 
            // dgv_errores
            // 
            this.dgv_errores.AllowUserToAddRows = false;
            this.dgv_errores.AllowUserToDeleteRows = false;
            this.dgv_errores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_errores.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_errores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_errores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Errores});
            this.dgv_errores.Location = new System.Drawing.Point(376, 312);
            this.dgv_errores.Name = "dgv_errores";
            this.dgv_errores.ReadOnly = true;
            this.dgv_errores.Size = new System.Drawing.Size(212, 207);
            this.dgv_errores.TabIndex = 32;
            // 
            // Errores
            // 
            this.Errores.HeaderText = "Errores";
            this.Errores.Name = "Errores";
            this.Errores.ReadOnly = true;
            // 
            // bt_detener
            // 
            this.bt_detener.Image = global::refriauto.Properties.Resources.stop;
            this.bt_detener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_detener.Location = new System.Drawing.Point(220, 450);
            this.bt_detener.Name = "bt_detener";
            this.bt_detener.Size = new System.Drawing.Size(131, 40);
            this.bt_detener.TabIndex = 33;
            this.bt_detener.Text = "Detener proceso";
            this.bt_detener.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_detener.UseVisualStyleBackColor = true;
            this.bt_detener.Visible = false;
            this.bt_detener.Click += new System.EventHandler(this.bt_detener_Click);
            // 
            // label1
            // 
            this.label1.Image = global::refriauto.Properties.Resources.refriauto_marca_de_agua1;
            this.label1.Location = new System.Drawing.Point(433, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 67);
            this.label1.TabIndex = 0;
            // 
            // cb_ftp
            // 
            this.cb_ftp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ftp.FormattingEnabled = true;
            this.cb_ftp.Items.AddRange(new object[] {
            "Seleccionar FTP",
            "Prueba",
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
            this.cb_ftp.Location = new System.Drawing.Point(57, 181);
            this.cb_ftp.Name = "cb_ftp";
            this.cb_ftp.Size = new System.Drawing.Size(294, 21);
            this.cb_ftp.TabIndex = 34;
            this.cb_ftp.SelectedIndexChanged += new System.EventHandler(this.cb_ftp_SelectedIndexChanged);
            // 
            // pb_proceso
            // 
            this.pb_proceso.Location = new System.Drawing.Point(57, 467);
            this.pb_proceso.Name = "pb_proceso";
            this.pb_proceso.Size = new System.Drawing.Size(157, 23);
            this.pb_proceso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_proceso.TabIndex = 35;
            // 
            // lb_poncentaje
            // 
            this.lb_poncentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_poncentaje.ForeColor = System.Drawing.Color.Gray;
            this.lb_poncentaje.Location = new System.Drawing.Point(60, 450);
            this.lb_poncentaje.Name = "lb_poncentaje";
            this.lb_poncentaje.Size = new System.Drawing.Size(151, 13);
            this.lb_poncentaje.TabIndex = 37;
            this.lb_poncentaje.Text = "-- de -- archivos";
            this.lb_poncentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_tiempo
            // 
            this.lb_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tiempo.ForeColor = System.Drawing.Color.Gray;
            this.lb_tiempo.Location = new System.Drawing.Point(57, 412);
            this.lb_tiempo.Name = "lb_tiempo";
            this.lb_tiempo.Size = new System.Drawing.Size(294, 23);
            this.lb_tiempo.TabIndex = 38;
            this.lb_tiempo.Text = "Tiempo de ejecución";
            this.lb_tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Encriptar y separar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 40;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(376, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(376, 256);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 20);
            this.textBox2.TabIndex = 42;
            // 
            // agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(641, 587);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_tiempo);
            this.Controls.Add(this.lb_poncentaje);
            this.Controls.Add(this.pb_proceso);
            this.Controls.Add(this.cb_ftp);
            this.Controls.Add(this.bt_detener);
            this.Controls.Add(this.dgv_errores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_server);
            this.Controls.Add(this.bt_ftp);
            this.Controls.Add(this.Sucursal);
            this.Controls.Add(this.lb_error);
            this.Controls.Add(this.lb_exito);
            this.Controls.Add(this.lb_estado);
            this.Controls.Add(this.bt_examinar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "agregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_errores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bt_examinar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lb_estado;
        private System.Windows.Forms.Label lb_exito;
        private System.Windows.Forms.Label lb_error;
        private System.Windows.Forms.ComboBox Sucursal;
        private System.Windows.Forms.Button bt_ftp;
        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_errores;
        private System.Windows.Forms.Button bt_detener;
        private System.Windows.Forms.DataGridViewTextBoxColumn Errores;
        private System.Windows.Forms.ComboBox cb_ftp;
        private System.Windows.Forms.ProgressBar pb_proceso;
        private System.Windows.Forms.Label lb_poncentaje;
        private System.Windows.Forms.Label lb_tiempo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}