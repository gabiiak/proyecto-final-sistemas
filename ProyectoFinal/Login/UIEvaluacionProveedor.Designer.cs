namespace Login
{
    partial class UIEvaluacionProveedor
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblCompra = new System.Windows.Forms.Label();
            this.cmbCompras = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblFechaPrometida = new System.Windows.Forms.Label();
            this.dtpFechaPrometida = new System.Windows.Forms.DateTimePicker();
            this.lblCalidad = new System.Windows.Forms.Label();
            this.cmbCalidad = new System.Windows.Forms.ComboBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.dgvEvaluaciones = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnProbarIA = new System.Windows.Forms.Button();
            this.lblAnalisisIA = new System.Windows.Forms.Label();
            this.pnlAnalisisIA = new System.Windows.Forms.Panel();
            this.lblProveedorRecomendado = new System.Windows.Forms.Label();
            this.lblProbabilidadIA = new System.Windows.Forms.Label();
            this.lblExplicacionIA = new System.Windows.Forms.Label();
            this.btnAnalizarProveedores = new System.Windows.Forms.Button();
            this.tlpIndicadoresIA = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEntregasIA = new System.Windows.Forms.Panel();
            this.lblTituloEntregasIA = new System.Windows.Forms.Label();
            this.lblValorEntregasIA = new System.Windows.Forms.Label();
            this.pnlPuntualidadIA = new System.Windows.Forms.Panel();
            this.lblTituloPuntualidadIA = new System.Windows.Forms.Label();
            this.lblValorPuntualidadIA = new System.Windows.Forms.Label();
            this.pnlCalidadIA = new System.Windows.Forms.Panel();
            this.lblTituloCalidadIA = new System.Windows.Forms.Label();
            this.lblValorCalidadIA = new System.Windows.Forms.Label();
            this.pnlGraficoIA = new System.Windows.Forms.Panel();
            this.lblTituloGraficoIA = new System.Windows.Forms.Label();
            this.btnRecomendacionIA = new System.Windows.Forms.Button();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluaciones)).BeginInit();
            this.pnlAnalisisIA.SuspendLayout();
            this.tlpIndicadoresIA.SuspendLayout();
            this.pnlEntregasIA.SuspendLayout();
            this.pnlPuntualidadIA.SuspendLayout();
            this.pnlCalidadIA.SuspendLayout();
            this.pnlGraficoIA.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evaluación de Proveedores";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.White;
            this.pnlDatos.Controls.Add(this.txtObservaciones);
            this.pnlDatos.Controls.Add(this.lblObservaciones);
            this.pnlDatos.Controls.Add(this.cmbCalidad);
            this.pnlDatos.Controls.Add(this.lblCalidad);
            this.pnlDatos.Controls.Add(this.dtpFechaPrometida);
            this.pnlDatos.Controls.Add(this.lblFechaPrometida);
            this.pnlDatos.Controls.Add(this.txtProveedor);
            this.pnlDatos.Controls.Add(this.lblProveedor);
            this.pnlDatos.Controls.Add(this.cmbCompras);
            this.pnlDatos.Controls.Add(this.lblCompra);
            this.pnlDatos.Location = new System.Drawing.Point(25, 75);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(845, 261);
            this.pnlDatos.TabIndex = 1;
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.ForeColor = System.Drawing.Color.DimGray;
            this.lblCompra.Location = new System.Drawing.Point(15, 15);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(126, 17);
            this.lblCompra.TabIndex = 0;
            this.lblCompra.Text = "Seleccionar compra:";
            // 
            // cmbCompras
            // 
            this.cmbCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompras.DropDownWidth = 550;
            this.cmbCompras.FormattingEnabled = true;
            this.cmbCompras.Location = new System.Drawing.Point(15, 40);
            this.cmbCompras.Name = "cmbCompras";
            this.cmbCompras.Size = new System.Drawing.Size(350, 25);
            this.cmbCompras.TabIndex = 1;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.ForeColor = System.Drawing.Color.DimGray;
            this.lblProveedor.Location = new System.Drawing.Point(405, 15);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(72, 17);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProveedor.Location = new System.Drawing.Point(405, 40);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(350, 25);
            this.txtProveedor.TabIndex = 3;
            // 
            // lblFechaPrometida
            // 
            this.lblFechaPrometida.AutoSize = true;
            this.lblFechaPrometida.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaPrometida.Location = new System.Drawing.Point(15, 85);
            this.lblFechaPrometida.Name = "lblFechaPrometida";
            this.lblFechaPrometida.Size = new System.Drawing.Size(109, 17);
            this.lblFechaPrometida.TabIndex = 4;
            this.lblFechaPrometida.Text = "Fecha prometida:";
            // 
            // dtpFechaPrometida
            // 
            this.dtpFechaPrometida.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaPrometida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPrometida.Location = new System.Drawing.Point(15, 110);
            this.dtpFechaPrometida.Name = "dtpFechaPrometida";
            this.dtpFechaPrometida.Size = new System.Drawing.Size(350, 25);
            this.dtpFechaPrometida.TabIndex = 5;
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.ForeColor = System.Drawing.Color.DimGray;
            this.lblCalidad.Location = new System.Drawing.Point(405, 85);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(123, 17);
            this.lblCalidad.TabIndex = 6;
            this.lblCalidad.Text = "Calidad de entrega:";
            // 
            // cmbCalidad
            // 
            this.cmbCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalidad.FormattingEnabled = true;
            this.cmbCalidad.Location = new System.Drawing.Point(405, 110);
            this.cmbCalidad.Name = "cmbCalidad";
            this.cmbCalidad.Size = new System.Drawing.Size(350, 25);
            this.cmbCalidad.TabIndex = 7;
            this.cmbCalidad.SelectedIndexChanged += new System.EventHandler(this.cmbCalidad_SelectedIndexChanged);
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.ForeColor = System.Drawing.Color.DimGray;
            this.lblObservaciones.Location = new System.Drawing.Point(15, 155);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(97, 17);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(15, 180);
            this.txtObservaciones.MaxLength = 500;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(740, 48);
            this.txtObservaciones.TabIndex = 9;
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblHistorial.Location = new System.Drawing.Point(25, 390);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(182, 20);
            this.lblHistorial.TabIndex = 2;
            this.lblHistorial.Text = "Historial de evaluaciones";
            // 
            // dgvEvaluaciones
            // 
            this.dgvEvaluaciones.AllowUserToAddRows = false;
            this.dgvEvaluaciones.AllowUserToDeleteRows = false;
            this.dgvEvaluaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvaluaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvaluaciones.Location = new System.Drawing.Point(25, 425);
            this.dgvEvaluaciones.MultiSelect = false;
            this.dgvEvaluaciones.Name = "dgvEvaluaciones";
            this.dgvEvaluaciones.ReadOnly = true;
            this.dgvEvaluaciones.RowHeadersVisible = false;
            this.dgvEvaluaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvaluaciones.Size = new System.Drawing.Size(1445, 125);
            this.dgvEvaluaciones.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.btnLimpiar.Location = new System.Drawing.Point(225, 345);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 36);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(25, 345);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(185, 36);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar evaluación";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnProbarIA
            // 
            this.btnProbarIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.btnProbarIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarIA.ForeColor = System.Drawing.Color.White;
            this.btnProbarIA.Location = new System.Drawing.Point(545, 345);
            this.btnProbarIA.Name = "btnProbarIA";
            this.btnProbarIA.Size = new System.Drawing.Size(150, 36);
            this.btnProbarIA.TabIndex = 14;
            this.btnProbarIA.Text = "Evaluar IA";
            this.btnProbarIA.UseVisualStyleBackColor = false;
            // 
            // lblAnalisisIA
            // 
            this.lblAnalisisIA.AutoSize = true;
            this.lblAnalisisIA.BackColor = System.Drawing.Color.Transparent;
            this.lblAnalisisIA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalisisIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblAnalisisIA.Location = new System.Drawing.Point(25, 580);
            this.lblAnalisisIA.Name = "lblAnalisisIA";
            this.lblAnalisisIA.Size = new System.Drawing.Size(279, 21);
            this.lblAnalisisIA.TabIndex = 15;
            this.lblAnalisisIA.Text = "Análisis Inteligente de Proveedores";
            // 
            // pnlAnalisisIA
            // 
            this.pnlAnalisisIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnalisisIA.BackColor = System.Drawing.Color.White;
            this.pnlAnalisisIA.Controls.Add(this.btnRecomendacionIA);
            this.pnlAnalisisIA.Controls.Add(this.btnAnalizarProveedores);
            this.pnlAnalisisIA.Controls.Add(this.lblExplicacionIA);
            this.pnlAnalisisIA.Controls.Add(this.lblProbabilidadIA);
            this.pnlAnalisisIA.Controls.Add(this.lblProveedorRecomendado);
            this.pnlAnalisisIA.Location = new System.Drawing.Point(25, 720);
            this.pnlAnalisisIA.Name = "pnlAnalisisIA";
            this.pnlAnalisisIA.Size = new System.Drawing.Size(1445, 184);
            this.pnlAnalisisIA.TabIndex = 16;
            // 
            // lblProveedorRecomendado
            // 
            this.lblProveedorRecomendado.AutoSize = true;
            this.lblProveedorRecomendado.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedorRecomendado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblProveedorRecomendado.Location = new System.Drawing.Point(23, 9);
            this.lblProveedorRecomendado.Name = "lblProveedorRecomendado";
            this.lblProveedorRecomendado.Size = new System.Drawing.Size(454, 28);
            this.lblProveedorRecomendado.TabIndex = 0;
            this.lblProveedorRecomendado.Text = "Proveedor recomendado: Pendiente de análisis";
            // 
            // lblProbabilidadIA
            // 
            this.lblProbabilidadIA.AutoSize = true;
            this.lblProbabilidadIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblProbabilidadIA.Location = new System.Drawing.Point(24, 49);
            this.lblProbabilidadIA.Name = "lblProbabilidadIA";
            this.lblProbabilidadIA.Size = new System.Drawing.Size(201, 17);
            this.lblProbabilidadIA.TabIndex = 1;
            this.lblProbabilidadIA.Text = "Probabilidad de cumplimiento: --";
            // 
            // lblExplicacionIA
            // 
            this.lblExplicacionIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExplicacionIA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplicacionIA.ForeColor = System.Drawing.Color.DimGray;
            this.lblExplicacionIA.Location = new System.Drawing.Point(23, 75);
            this.lblExplicacionIA.Name = "lblExplicacionIA";
            this.lblExplicacionIA.Size = new System.Drawing.Size(1417, 55);
            this.lblExplicacionIA.TabIndex = 2;
            this.lblExplicacionIA.Text = "Todavía no hay una recomendación disponible.";
            // 
            // btnAnalizarProveedores
            // 
            this.btnAnalizarProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalizarProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.btnAnalizarProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizarProveedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizarProveedores.ForeColor = System.Drawing.Color.White;
            this.btnAnalizarProveedores.Location = new System.Drawing.Point(1240, 145);
            this.btnAnalizarProveedores.Name = "btnAnalizarProveedores";
            this.btnAnalizarProveedores.Size = new System.Drawing.Size(200, 36);
            this.btnAnalizarProveedores.TabIndex = 3;
            this.btnAnalizarProveedores.Text = "Analizar proveedores";
            this.btnAnalizarProveedores.UseVisualStyleBackColor = false;
            // 
            // tlpIndicadoresIA
            // 
            this.tlpIndicadoresIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpIndicadoresIA.ColumnCount = 3;
            this.tlpIndicadoresIA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpIndicadoresIA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpIndicadoresIA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpIndicadoresIA.Controls.Add(this.pnlEntregasIA, 0, 0);
            this.tlpIndicadoresIA.Controls.Add(this.pnlPuntualidadIA, 1, 0);
            this.tlpIndicadoresIA.Controls.Add(this.pnlCalidadIA, 2, 0);
            this.tlpIndicadoresIA.Location = new System.Drawing.Point(25, 605);
            this.tlpIndicadoresIA.Name = "tlpIndicadoresIA";
            this.tlpIndicadoresIA.RowCount = 1;
            this.tlpIndicadoresIA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIndicadoresIA.Size = new System.Drawing.Size(1445, 90);
            this.tlpIndicadoresIA.TabIndex = 17;
            // 
            // pnlEntregasIA
            // 
            this.pnlEntregasIA.BackColor = System.Drawing.Color.White;
            this.pnlEntregasIA.Controls.Add(this.lblValorEntregasIA);
            this.pnlEntregasIA.Controls.Add(this.lblTituloEntregasIA);
            this.pnlEntregasIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntregasIA.Location = new System.Drawing.Point(5, 5);
            this.pnlEntregasIA.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlEntregasIA.Name = "pnlEntregasIA";
            this.pnlEntregasIA.Size = new System.Drawing.Size(466, 80);
            this.pnlEntregasIA.TabIndex = 0;
            // 
            // lblTituloEntregasIA
            // 
            this.lblTituloEntregasIA.AutoSize = true;
            this.lblTituloEntregasIA.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloEntregasIA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloEntregasIA.ForeColor = System.Drawing.Color.DimGray;
            this.lblTituloEntregasIA.Location = new System.Drawing.Point(15, 12);
            this.lblTituloEntregasIA.Name = "lblTituloEntregasIA";
            this.lblTituloEntregasIA.Size = new System.Drawing.Size(131, 15);
            this.lblTituloEntregasIA.TabIndex = 0;
            this.lblTituloEntregasIA.Text = "ENTREGAS EVALUADAS";
            // 
            // lblValorEntregasIA
            // 
            this.lblValorEntregasIA.AutoSize = true;
            this.lblValorEntregasIA.BackColor = System.Drawing.Color.Transparent;
            this.lblValorEntregasIA.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntregasIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblValorEntregasIA.Location = new System.Drawing.Point(15, 35);
            this.lblValorEntregasIA.Name = "lblValorEntregasIA";
            this.lblValorEntregasIA.Size = new System.Drawing.Size(41, 40);
            this.lblValorEntregasIA.TabIndex = 1;
            this.lblValorEntregasIA.Text = "--";
            // 
            // pnlPuntualidadIA
            // 
            this.pnlPuntualidadIA.BackColor = System.Drawing.Color.White;
            this.pnlPuntualidadIA.Controls.Add(this.lblValorPuntualidadIA);
            this.pnlPuntualidadIA.Controls.Add(this.lblTituloPuntualidadIA);
            this.pnlPuntualidadIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPuntualidadIA.Location = new System.Drawing.Point(486, 5);
            this.pnlPuntualidadIA.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlPuntualidadIA.Name = "pnlPuntualidadIA";
            this.pnlPuntualidadIA.Size = new System.Drawing.Size(466, 80);
            this.pnlPuntualidadIA.TabIndex = 1;
            // 
            // lblTituloPuntualidadIA
            // 
            this.lblTituloPuntualidadIA.AutoSize = true;
            this.lblTituloPuntualidadIA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloPuntualidadIA.ForeColor = System.Drawing.Color.DimGray;
            this.lblTituloPuntualidadIA.Location = new System.Drawing.Point(15, 12);
            this.lblTituloPuntualidadIA.Name = "lblTituloPuntualidadIA";
            this.lblTituloPuntualidadIA.Size = new System.Drawing.Size(87, 15);
            this.lblTituloPuntualidadIA.TabIndex = 0;
            this.lblTituloPuntualidadIA.Text = "PUNTUALIDAD";
            // 
            // lblValorPuntualidadIA
            // 
            this.lblValorPuntualidadIA.AutoSize = true;
            this.lblValorPuntualidadIA.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPuntualidadIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblValorPuntualidadIA.Location = new System.Drawing.Point(15, 35);
            this.lblValorPuntualidadIA.Name = "lblValorPuntualidadIA";
            this.lblValorPuntualidadIA.Size = new System.Drawing.Size(41, 40);
            this.lblValorPuntualidadIA.TabIndex = 1;
            this.lblValorPuntualidadIA.Text = "--";
            // 
            // pnlCalidadIA
            // 
            this.pnlCalidadIA.BackColor = System.Drawing.Color.White;
            this.pnlCalidadIA.Controls.Add(this.lblValorCalidadIA);
            this.pnlCalidadIA.Controls.Add(this.lblTituloCalidadIA);
            this.pnlCalidadIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalidadIA.Location = new System.Drawing.Point(967, 5);
            this.pnlCalidadIA.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCalidadIA.Name = "pnlCalidadIA";
            this.pnlCalidadIA.Size = new System.Drawing.Size(473, 80);
            this.pnlCalidadIA.TabIndex = 2;
            // 
            // lblTituloCalidadIA
            // 
            this.lblTituloCalidadIA.AutoSize = true;
            this.lblTituloCalidadIA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloCalidadIA.ForeColor = System.Drawing.Color.DimGray;
            this.lblTituloCalidadIA.Location = new System.Drawing.Point(15, 12);
            this.lblTituloCalidadIA.Name = "lblTituloCalidadIA";
            this.lblTituloCalidadIA.Size = new System.Drawing.Size(119, 15);
            this.lblTituloCalidadIA.TabIndex = 0;
            this.lblTituloCalidadIA.Text = "CALIDAD PROMEDIO";
            // 
            // lblValorCalidadIA
            // 
            this.lblValorCalidadIA.AutoSize = true;
            this.lblValorCalidadIA.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCalidadIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblValorCalidadIA.Location = new System.Drawing.Point(15, 35);
            this.lblValorCalidadIA.Name = "lblValorCalidadIA";
            this.lblValorCalidadIA.Size = new System.Drawing.Size(41, 40);
            this.lblValorCalidadIA.TabIndex = 1;
            this.lblValorCalidadIA.Text = "--";
            // 
            // pnlGraficoIA
            // 
            this.pnlGraficoIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraficoIA.BackColor = System.Drawing.Color.White;
            this.pnlGraficoIA.Controls.Add(this.lblTituloGraficoIA);
            this.pnlGraficoIA.Location = new System.Drawing.Point(910, 75);
            this.pnlGraficoIA.Name = "pnlGraficoIA";
            this.pnlGraficoIA.Size = new System.Drawing.Size(600, 260);
            this.pnlGraficoIA.TabIndex = 18;
            // 
            // lblTituloGraficoIA
            // 
            this.lblTituloGraficoIA.AutoSize = true;
            this.lblTituloGraficoIA.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGraficoIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblTituloGraficoIA.Location = new System.Drawing.Point(20, 15);
            this.lblTituloGraficoIA.Name = "lblTituloGraficoIA";
            this.lblTituloGraficoIA.Size = new System.Drawing.Size(222, 20);
            this.lblTituloGraficoIA.TabIndex = 0;
            this.lblTituloGraficoIA.Text = "PUNTUALIDAD DE ENTREGAS";
            // 
            // btnRecomendacionIA
            // 
            this.btnRecomendacionIA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecomendacionIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnRecomendacionIA.FlatAppearance.BorderSize = 0;
            this.btnRecomendacionIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecomendacionIA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecomendacionIA.ForeColor = System.Drawing.Color.White;
            this.btnRecomendacionIA.Location = new System.Drawing.Point(1014, 145);
            this.btnRecomendacionIA.Name = "btnRecomendacionIA";
            this.btnRecomendacionIA.Size = new System.Drawing.Size(220, 35);
            this.btnRecomendacionIA.TabIndex = 4;
            this.btnRecomendacionIA.Text = "Generar recomendación IA";
            this.btnRecomendacionIA.UseVisualStyleBackColor = false;
            // 
            // UIEvaluacionProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1584, 916);
            this.Controls.Add(this.pnlGraficoIA);
            this.Controls.Add(this.tlpIndicadoresIA);
            this.Controls.Add(this.pnlAnalisisIA);
            this.Controls.Add(this.lblAnalisisIA);
            this.Controls.Add(this.btnProbarIA);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvEvaluaciones);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "UIEvaluacionProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluación De Proveedores";
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluaciones)).EndInit();
            this.pnlAnalisisIA.ResumeLayout(false);
            this.pnlAnalisisIA.PerformLayout();
            this.tlpIndicadoresIA.ResumeLayout(false);
            this.pnlEntregasIA.ResumeLayout(false);
            this.pnlEntregasIA.PerformLayout();
            this.pnlPuntualidadIA.ResumeLayout(false);
            this.pnlPuntualidadIA.PerformLayout();
            this.pnlCalidadIA.ResumeLayout(false);
            this.pnlCalidadIA.PerformLayout();
            this.pnlGraficoIA.ResumeLayout(false);
            this.pnlGraficoIA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.ComboBox cmbCompras;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.DateTimePicker dtpFechaPrometida;
        private System.Windows.Forms.Label lblFechaPrometida;
        private System.Windows.Forms.ComboBox cmbCalidad;
        private System.Windows.Forms.Label lblCalidad;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvEvaluaciones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnProbarIA;
        private System.Windows.Forms.Label lblAnalisisIA;
        private System.Windows.Forms.Panel pnlAnalisisIA;
        private System.Windows.Forms.Label lblExplicacionIA;
        private System.Windows.Forms.Label lblProbabilidadIA;
        private System.Windows.Forms.Label lblProveedorRecomendado;
        private System.Windows.Forms.Button btnAnalizarProveedores;
        private System.Windows.Forms.TableLayoutPanel tlpIndicadoresIA;
        private System.Windows.Forms.Panel pnlEntregasIA;
        private System.Windows.Forms.Label lblTituloEntregasIA;
        private System.Windows.Forms.Label lblValorEntregasIA;
        private System.Windows.Forms.Panel pnlPuntualidadIA;
        private System.Windows.Forms.Label lblTituloPuntualidadIA;
        private System.Windows.Forms.Label lblValorPuntualidadIA;
        private System.Windows.Forms.Panel pnlCalidadIA;
        private System.Windows.Forms.Label lblValorCalidadIA;
        private System.Windows.Forms.Label lblTituloCalidadIA;
        private System.Windows.Forms.Panel pnlGraficoIA;
        private System.Windows.Forms.Label lblTituloGraficoIA;
        private System.Windows.Forms.Button btnRecomendacionIA;
    }
}