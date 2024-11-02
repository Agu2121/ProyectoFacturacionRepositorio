namespace WindowsForms
{
    partial class Facturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturacion));
            this.btnLimpiarTodo = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCondCliente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtgGrilla = new System.Windows.Forms.DataGridView();
            this.btnAgregarGrilla = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarFactura = new System.Windows.Forms.Button();
            this.cboBusquedaCliente = new System.Windows.Forms.ComboBox();
            this.lblSeleccioneCliente = new System.Windows.Forms.Label();
            this.cboFacturas = new System.Windows.Forms.ComboBox();
            this.btnVerFactura = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiarTodo
            // 
            this.btnLimpiarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarTodo.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarTodo.Location = new System.Drawing.Point(25, 2);
            this.btnLimpiarTodo.Name = "btnLimpiarTodo";
            this.btnLimpiarTodo.Size = new System.Drawing.Size(150, 32);
            this.btnLimpiarTodo.TabIndex = 0;
            this.btnLimpiarTodo.Text = "Limpiar todo";
            this.btnLimpiarTodo.UseVisualStyleBackColor = true;
            this.btnLimpiarTodo.Click += new System.EventHandler(this.btnLimpiarTodo_Click);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarFactura.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactura.Location = new System.Drawing.Point(624, 2);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(150, 32);
            this.btnGenerarFactura.TabIndex = 1;
            this.btnGenerarFactura.Text = "Generar factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.cboFormaPago);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblCondCliente);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtgGrilla);
            this.panel1.Controls.Add(this.btnAgregarGrilla);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lblPrecioUnitario);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboArticulo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 472);
            this.panel1.TabIndex = 2;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(9, 136);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(252, 21);
            this.cboFormaPago.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(69, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Forma de pago:";
            // 
            // lblCondCliente
            // 
            this.lblCondCliente.AutoSize = true;
            this.lblCondCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondCliente.Location = new System.Drawing.Point(94, 43);
            this.lblCondCliente.Name = "lblCondCliente";
            this.lblCondCliente.Size = new System.Drawing.Size(14, 20);
            this.lblCondCliente.TabIndex = 15;
            this.lblCondCliente.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Condición:";
            // 
            // dtgGrilla
            // 
            this.dtgGrilla.AllowUserToAddRows = false;
            this.dtgGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrilla.Location = new System.Drawing.Point(22, 180);
            this.dtgGrilla.Name = "dtgGrilla";
            this.dtgGrilla.ReadOnly = true;
            this.dtgGrilla.Size = new System.Drawing.Size(707, 282);
            this.dtgGrilla.TabIndex = 13;
            // 
            // btnAgregarGrilla
            // 
            this.btnAgregarGrilla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarGrilla.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGrilla.Location = new System.Drawing.Point(571, 132);
            this.btnAgregarGrilla.Name = "btnAgregarGrilla";
            this.btnAgregarGrilla.Size = new System.Drawing.Size(158, 33);
            this.btnAgregarGrilla.TabIndex = 12;
            this.btnAgregarGrilla.Text = "Agregar articulo";
            this.btnAgregarGrilla.UseVisualStyleBackColor = true;
            this.btnAgregarGrilla.Click += new System.EventHandler(this.btnAgregarGrilla_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(424, 139);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 20);
            this.txtCantidad.TabIndex = 11;
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioUnitario.Location = new System.Drawing.Point(420, 108);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(14, 20);
            this.lblPrecioUnitario.TabIndex = 10;
            this.lblPrecioUnitario.Text = "-";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(420, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(14, 20);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(340, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cantidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(249, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Precio unitario sin IVA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(321, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Descripcion:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(420, 43);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(14, 20);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(354, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Codigo:";
            // 
            // cboArticulo
            // 
            this.cboArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Location = new System.Drawing.Point(424, 7);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(305, 21);
            this.cboArticulo.TabIndex = 3;
            this.cboArticulo.SelectedValueChanged += new System.EventHandler(this.cboArticulo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Articulo:";
            // 
            // cboCliente
            // 
            this.cboCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(73, 7);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(188, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedValueChanged += new System.EventHandler(this.cboCliente_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "SISTEMA FACTURACION";
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarFactura.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarFactura.Location = new System.Drawing.Point(849, 340);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(168, 32);
            this.btnBuscarFactura.TabIndex = 4;
            this.btnBuscarFactura.Text = "Buscar factura ya generada";
            this.btnBuscarFactura.UseVisualStyleBackColor = true;
            this.btnBuscarFactura.Click += new System.EventHandler(this.btnBuscarFactura_Click);
            // 
            // cboBusquedaCliente
            // 
            this.cboBusquedaCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBusquedaCliente.FormattingEnabled = true;
            this.cboBusquedaCliente.Location = new System.Drawing.Point(840, 407);
            this.cboBusquedaCliente.Name = "cboBusquedaCliente";
            this.cboBusquedaCliente.Size = new System.Drawing.Size(188, 21);
            this.cboBusquedaCliente.TabIndex = 18;
            this.cboBusquedaCliente.Visible = false;
            this.cboBusquedaCliente.SelectedIndexChanged += new System.EventHandler(this.cboBusquedaCliente_SelectedIndexChanged);
            // 
            // lblSeleccioneCliente
            // 
            this.lblSeleccioneCliente.AutoSize = true;
            this.lblSeleccioneCliente.Font = new System.Drawing.Font("HP Simplified", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccioneCliente.Location = new System.Drawing.Point(794, 375);
            this.lblSeleccioneCliente.Name = "lblSeleccioneCliente";
            this.lblSeleccioneCliente.Size = new System.Drawing.Size(285, 19);
            this.lblSeleccioneCliente.TabIndex = 18;
            this.lblSeleccioneCliente.Text = "Seleccione un cliente para ver sus facturas";
            this.lblSeleccioneCliente.Visible = false;
            // 
            // cboFacturas
            // 
            this.cboFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFacturas.Enabled = false;
            this.cboFacturas.FormattingEnabled = true;
            this.cboFacturas.Location = new System.Drawing.Point(824, 434);
            this.cboFacturas.Name = "cboFacturas";
            this.cboFacturas.Size = new System.Drawing.Size(219, 21);
            this.cboFacturas.TabIndex = 19;
            this.cboFacturas.Visible = false;
            this.cboFacturas.SelectedIndexChanged += new System.EventHandler(this.cboFacturas_SelectedIndexChanged);
            // 
            // btnVerFactura
            // 
            this.btnVerFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerFactura.Enabled = false;
            this.btnVerFactura.Font = new System.Drawing.Font("HP Simplified", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerFactura.Location = new System.Drawing.Point(858, 470);
            this.btnVerFactura.Name = "btnVerFactura";
            this.btnVerFactura.Size = new System.Drawing.Size(150, 32);
            this.btnVerFactura.TabIndex = 20;
            this.btnVerFactura.Text = "Ver factura";
            this.btnVerFactura.UseVisualStyleBackColor = true;
            this.btnVerFactura.Click += new System.EventHandler(this.btnVerFactura_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("HP Simplified", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(871, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(798, 181);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(283, 121);
            this.txtObservaciones.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(825, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1093, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnVerFactura);
            this.Controls.Add(this.cboFacturas);
            this.Controls.Add(this.lblSeleccioneCliente);
            this.Controls.Add(this.cboBusquedaCliente);
            this.Controls.Add(this.btnBuscarFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnLimpiarTodo);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.Facturacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarTodo;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DataGridView dtgGrilla;
        private System.Windows.Forms.Button btnAgregarGrilla;
        private System.Windows.Forms.Label lblCondCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscarFactura;
        private System.Windows.Forms.ComboBox cboBusquedaCliente;
        private System.Windows.Forms.Label lblSeleccioneCliente;
        private System.Windows.Forms.ComboBox cboFacturas;
        private System.Windows.Forms.Button btnVerFactura;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}