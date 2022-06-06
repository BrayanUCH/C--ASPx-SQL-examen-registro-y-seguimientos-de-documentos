namespace CapaPresentacion
{
    partial class LoginRegistrar
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
            this.ckbLogin_MostrarInactivos = new System.Windows.Forms.CheckBox();
            this.cbxLogin = new System.Windows.Forms.ComboBox();
            this.btnLogin_cargarDatos = new System.Windows.Forms.Button();
            this.btnLogin_activar = new System.Windows.Forms.Button();
            this.btnLogin_inactivar = new System.Windows.Forms.Button();
            this.btnLogin_modificar = new System.Windows.Forms.Button();
            this.btnLogin_insertar = new System.Windows.Forms.Button();
            this.txtLogin_Usuario = new System.Windows.Forms.TextBox();
            this.txtLogin_Correo = new System.Windows.Forms.TextBox();
            this.txtLogin_Contraseña = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLogin = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbUsuario = new System.Windows.Forms.CheckBox();
            this.ckbAdministrador = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbLogin_MostrarInactivos
            // 
            this.ckbLogin_MostrarInactivos.AutoSize = true;
            this.ckbLogin_MostrarInactivos.Location = new System.Drawing.Point(348, 404);
            this.ckbLogin_MostrarInactivos.Name = "ckbLogin_MostrarInactivos";
            this.ckbLogin_MostrarInactivos.Size = new System.Drawing.Size(140, 17);
            this.ckbLogin_MostrarInactivos.TabIndex = 133;
            this.ckbLogin_MostrarInactivos.Text = "MOSTRAR INACTIVOS";
            this.ckbLogin_MostrarInactivos.UseVisualStyleBackColor = true;
            this.ckbLogin_MostrarInactivos.CheckedChanged += new System.EventHandler(this.ckbLogin_MostrarInactivos_CheckedChanged);
            // 
            // cbxLogin
            // 
            this.cbxLogin.FormattingEnabled = true;
            this.cbxLogin.Location = new System.Drawing.Point(138, 373);
            this.cbxLogin.Name = "cbxLogin";
            this.cbxLogin.Size = new System.Drawing.Size(185, 21);
            this.cbxLogin.TabIndex = 132;
            // 
            // btnLogin_cargarDatos
            // 
            this.btnLogin_cargarDatos.Location = new System.Drawing.Point(25, 371);
            this.btnLogin_cargarDatos.Name = "btnLogin_cargarDatos";
            this.btnLogin_cargarDatos.Size = new System.Drawing.Size(107, 23);
            this.btnLogin_cargarDatos.TabIndex = 131;
            this.btnLogin_cargarDatos.Text = "CARGAR DATOS";
            this.btnLogin_cargarDatos.UseVisualStyleBackColor = true;
            this.btnLogin_cargarDatos.Click += new System.EventHandler(this.btnLogin_cargarDatos_Click);
            // 
            // btnLogin_activar
            // 
            this.btnLogin_activar.Location = new System.Drawing.Point(267, 400);
            this.btnLogin_activar.Name = "btnLogin_activar";
            this.btnLogin_activar.Size = new System.Drawing.Size(75, 23);
            this.btnLogin_activar.TabIndex = 130;
            this.btnLogin_activar.Text = "ACTIVAR";
            this.btnLogin_activar.UseVisualStyleBackColor = true;
            this.btnLogin_activar.Click += new System.EventHandler(this.btnLogin_activar_Click);
            // 
            // btnLogin_inactivar
            // 
            this.btnLogin_inactivar.Location = new System.Drawing.Point(186, 400);
            this.btnLogin_inactivar.Name = "btnLogin_inactivar";
            this.btnLogin_inactivar.Size = new System.Drawing.Size(75, 23);
            this.btnLogin_inactivar.TabIndex = 129;
            this.btnLogin_inactivar.Text = "INACTIVAR";
            this.btnLogin_inactivar.UseVisualStyleBackColor = true;
            this.btnLogin_inactivar.Click += new System.EventHandler(this.btnLogin_inactivar_Click);
            // 
            // btnLogin_modificar
            // 
            this.btnLogin_modificar.Location = new System.Drawing.Point(105, 400);
            this.btnLogin_modificar.Name = "btnLogin_modificar";
            this.btnLogin_modificar.Size = new System.Drawing.Size(75, 23);
            this.btnLogin_modificar.TabIndex = 128;
            this.btnLogin_modificar.Text = "MODIFICAR";
            this.btnLogin_modificar.UseVisualStyleBackColor = true;
            this.btnLogin_modificar.Click += new System.EventHandler(this.btnLogin_modificar_Click);
            // 
            // btnLogin_insertar
            // 
            this.btnLogin_insertar.Location = new System.Drawing.Point(24, 400);
            this.btnLogin_insertar.Name = "btnLogin_insertar";
            this.btnLogin_insertar.Size = new System.Drawing.Size(75, 23);
            this.btnLogin_insertar.TabIndex = 127;
            this.btnLogin_insertar.Text = "INSERTAR";
            this.btnLogin_insertar.UseVisualStyleBackColor = true;
            this.btnLogin_insertar.Click += new System.EventHandler(this.btnLogin_insertar_Click);
            // 
            // txtLogin_Usuario
            // 
            this.txtLogin_Usuario.Location = new System.Drawing.Point(178, 37);
            this.txtLogin_Usuario.MaxLength = 10;
            this.txtLogin_Usuario.Name = "txtLogin_Usuario";
            this.txtLogin_Usuario.Size = new System.Drawing.Size(145, 20);
            this.txtLogin_Usuario.TabIndex = 126;
            // 
            // txtLogin_Correo
            // 
            this.txtLogin_Correo.Location = new System.Drawing.Point(178, 88);
            this.txtLogin_Correo.MaxLength = 50;
            this.txtLogin_Correo.Name = "txtLogin_Correo";
            this.txtLogin_Correo.Size = new System.Drawing.Size(145, 20);
            this.txtLogin_Correo.TabIndex = 125;
            // 
            // txtLogin_Contraseña
            // 
            this.txtLogin_Contraseña.Location = new System.Drawing.Point(178, 63);
            this.txtLogin_Contraseña.MaxLength = 8;
            this.txtLogin_Contraseña.Name = "txtLogin_Contraseña";
            this.txtLogin_Contraseña.Size = new System.Drawing.Size(145, 20);
            this.txtLogin_Contraseña.TabIndex = 122;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "Correo electrónico";
            // 
            // dgvLogin
            // 
            this.dgvLogin.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvLogin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogin.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLogin.Location = new System.Drawing.Point(329, 28);
            this.dgvLogin.Name = "dgvLogin";
            this.dgvLogin.Size = new System.Drawing.Size(635, 366);
            this.dgvLogin.TabIndex = 123;
            this.dgvLogin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogin_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "Tipo des usuario";
            // 
            // ckbUsuario
            // 
            this.ckbUsuario.AutoSize = true;
            this.ckbUsuario.Location = new System.Drawing.Point(25, 146);
            this.ckbUsuario.Name = "ckbUsuario";
            this.ckbUsuario.Size = new System.Drawing.Size(100, 17);
            this.ckbUsuario.TabIndex = 136;
            this.ckbUsuario.Text = "Usuario general";
            this.ckbUsuario.UseVisualStyleBackColor = true;
            this.ckbUsuario.CheckStateChanged += new System.EventHandler(this.ckbUsuario_CheckStateChanged);
            // 
            // ckbAdministrador
            // 
            this.ckbAdministrador.AutoSize = true;
            this.ckbAdministrador.Location = new System.Drawing.Point(150, 146);
            this.ckbAdministrador.Name = "ckbAdministrador";
            this.ckbAdministrador.Size = new System.Drawing.Size(89, 17);
            this.ckbAdministrador.TabIndex = 137;
            this.ckbAdministrador.Text = "Administrador";
            this.ckbAdministrador.UseVisualStyleBackColor = true;
            this.ckbAdministrador.CheckStateChanged += new System.EventHandler(this.ckbAdministrador_CheckStateChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(394, 1);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(237, 24);
            this.linkLabel1.TabIndex = 138;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "REGISTRO DE USUARIOS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(773, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 139;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(837, 400);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(127, 23);
            this.btnReporte.TabIndex = 140;
            this.btnReporte.Text = "GENERAR REPORTE";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // LoginRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ckbAdministrador);
            this.Controls.Add(this.ckbUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckbLogin_MostrarInactivos);
            this.Controls.Add(this.cbxLogin);
            this.Controls.Add(this.btnLogin_cargarDatos);
            this.Controls.Add(this.btnLogin_activar);
            this.Controls.Add(this.btnLogin_inactivar);
            this.Controls.Add(this.btnLogin_modificar);
            this.Controls.Add(this.btnLogin_insertar);
            this.Controls.Add(this.txtLogin_Usuario);
            this.Controls.Add(this.txtLogin_Correo);
            this.Controls.Add(this.txtLogin_Contraseña);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "LoginRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRO DE USUARIOS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbLogin_MostrarInactivos;
        private System.Windows.Forms.ComboBox cbxLogin;
        private System.Windows.Forms.Button btnLogin_cargarDatos;
        private System.Windows.Forms.Button btnLogin_activar;
        private System.Windows.Forms.Button btnLogin_inactivar;
        private System.Windows.Forms.Button btnLogin_modificar;
        private System.Windows.Forms.Button btnLogin_insertar;
        private System.Windows.Forms.TextBox txtLogin_Usuario;
        private System.Windows.Forms.TextBox txtLogin_Correo;
        private System.Windows.Forms.TextBox txtLogin_Contraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbUsuario;
        private System.Windows.Forms.CheckBox ckbAdministrador;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReporte;
    }
}