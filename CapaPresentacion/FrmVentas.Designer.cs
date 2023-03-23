namespace CapaPresentacion
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoVenta = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTipBuscar = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDProducto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.grdListaVenta = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.btnBuscarFactura = new System.Windows.Forms.Button();
            this.btnGuardarFactura = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTipoVenta);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDFactura);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de venta:";
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVenta.FormattingEnabled = true;
            this.cboTipoVenta.Items.AddRange(new object[] {
            "CONTADO",
            "CREDITO"});
            this.cboTipoVenta.Location = new System.Drawing.Point(108, 61);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Size = new System.Drawing.Size(134, 21);
            this.cboTipoVenta.TabIndex = 5;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(253, 24);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(242, 20);
            this.txtCliente.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // txtIDFactura
            // 
            this.txtIDFactura.Location = new System.Drawing.Point(108, 24);
            this.txtIDFactura.Name = "txtIDFactura";
            this.txtIDFactura.ReadOnly = true;
            this.txtIDFactura.Size = new System.Drawing.Size(100, 20);
            this.txtIDFactura.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Factura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Precio";
            // 
            // txtIDProducto
            // 
            this.txtIDProducto.Location = new System.Drawing.Point(29, 149);
            this.txtIDProducto.Name = "txtIDProducto";
            this.txtIDProducto.Size = new System.Drawing.Size(56, 20);
            this.txtIDProducto.TabIndex = 11;
            this.txtIDProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDProducto_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(91, 149);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(192, 20);
            this.txtDescripcion.TabIndex = 12;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(337, 147);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(64, 20);
            this.numCantidad.TabIndex = 13;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(407, 149);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 14;
            // 
            // grdListaVenta
            // 
            this.grdListaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListaVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDVenta,
            this.IDProducto,
            this.Descripcion,
            this.Cantidad,
            this.PrecioVenta,
            this.Subtotal,
            this.Existe});
            this.grdListaVenta.Location = new System.Drawing.Point(12, 208);
            this.grdListaVenta.Name = "grdListaVenta";
            this.grdListaVenta.Size = new System.Drawing.Size(585, 256);
            this.grdListaVenta.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(491, 481);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(106, 20);
            this.txtTotal.TabIndex = 20;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Close_48;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Location = new System.Drawing.Point(551, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(46, 37);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.BackgroundImage = global::CapaPresentacion.Properties.Resources.Delete_48;
            this.btnEliminarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarFactura.Location = new System.Drawing.Point(499, 520);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(46, 37);
            this.btnEliminarFactura.TabIndex = 23;
            this.btnEliminarFactura.UseVisualStyleBackColor = true;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.btnBuscarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarFactura.Location = new System.Drawing.Point(447, 520);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(46, 37);
            this.btnBuscarFactura.TabIndex = 22;
            this.btnBuscarFactura.UseVisualStyleBackColor = true;
            // 
            // btnGuardarFactura
            // 
            this.btnGuardarFactura.BackgroundImage = global::CapaPresentacion.Properties.Resources.save_48;
            this.btnGuardarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarFactura.Location = new System.Drawing.Point(395, 520);
            this.btnGuardarFactura.Name = "btnGuardarFactura";
            this.btnGuardarFactura.Size = new System.Drawing.Size(46, 37);
            this.btnGuardarFactura.TabIndex = 21;
            this.btnGuardarFactura.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Eliminar;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(558, 145);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(39, 27);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Agregar;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(513, 145);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(39, 27);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackgroundImage = global::CapaPresentacion.Properties.Resources.Search_32;
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProducto.Location = new System.Drawing.Point(289, 145);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(39, 27);
            this.btnBuscarProducto.TabIndex = 15;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(501, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 35);
            this.btnBuscar.TabIndex = 4;
            this.toolTipBuscar.SetToolTip(this.btnBuscar, "Buscar cliente");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // IDVenta
            // 
            this.IDVenta.DataPropertyName = "VentaID";
            this.IDVenta.HeaderText = "VentaID";
            this.IDVenta.Name = "IDVenta";
            this.IDVenta.Visible = false;
            this.IDVenta.Width = 50;
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "ProductoID";
            this.IDProducto.HeaderText = "Código";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 200;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 50;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "PrecioVenta";
            this.PrecioVenta.HeaderText = "Precio Unitario";
            this.PrecioVenta.Name = "PrecioVenta";
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            this.Subtotal.HeaderText = "SubTotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.Width = 75;
            // 
            // Existe
            // 
            this.Existe.DataPropertyName = "Existe";
            this.Existe.HeaderText = "Existe";
            this.Existe.Name = "Existe";
            this.Existe.Visible = false;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(623, 581);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.btnBuscarFactura);
            this.Controls.Add(this.btnGuardarFactura);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grdListaVenta);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtIDProducto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVentas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoVenta;
        private System.Windows.Forms.ToolTip toolTipBuscar;
        private System.Windows.Forms.TextBox txtIDProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView grdListaVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGuardarFactura;
        private System.Windows.Forms.Button btnBuscarFactura;
        private System.Windows.Forms.Button btnEliminarFactura;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existe;
    }
}