namespace Login
{
    partial class UIRecetaProducto
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
            this.dgvRecetaProducto = new System.Windows.Forms.DataGridView();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.btnRegistrarReceta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbInsumo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // dgvRecetaProducto
            // 
            this.dgvRecetaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetaProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbInsumo,
            this.cantidad,
            this.colUnidadMedida});
            this.dgvRecetaProducto.Location = new System.Drawing.Point(12, 73);
            this.dgvRecetaProducto.Name = "dgvRecetaProducto";
            this.dgvRecetaProducto.Size = new System.Drawing.Size(400, 218);
            this.dgvRecetaProducto.TabIndex = 1;
            this.dgvRecetaProducto.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecetaProducto_CellValueChanged);
            this.dgvRecetaProducto.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRecetaProducto_CurrentCellDirtyStateChanged);
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(12, 34);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(195, 21);
            this.cmbProducto.TabIndex = 2;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // btnRegistrarReceta
            // 
            this.btnRegistrarReceta.Location = new System.Drawing.Point(12, 313);
            this.btnRegistrarReceta.Name = "btnRegistrarReceta";
            this.btnRegistrarReceta.Size = new System.Drawing.Size(195, 40);
            this.btnRegistrarReceta.TabIndex = 3;
            this.btnRegistrarReceta.Text = "Registrar Receta";
            this.btnRegistrarReceta.UseVisualStyleBackColor = true;
            this.btnRegistrarReceta.Click += new System.EventHandler(this.btnRegistrarReceta_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(220, 313);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(192, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbInsumo
            // 
            this.cmbInsumo.HeaderText = "Insumo";
            this.cmbInsumo.Name = "cmbInsumo";
            this.cmbInsumo.Width = 120;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ToolTipText = "Si la unidad es Kg, empieza por 0.xxx ";
            this.cantidad.Width = 130;
            // 
            // colUnidadMedida
            // 
            this.colUnidadMedida.HeaderText = "Unidad";
            this.colUnidadMedida.Name = "colUnidadMedida";
            this.colUnidadMedida.ReadOnly = true;
            this.colUnidadMedida.Width = 110;
            // 
            // UIRecetaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 365);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrarReceta);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.dgvRecetaProducto);
            this.Controls.Add(this.label1);
            this.Name = "UIRecetaProducto";
            this.Text = "UIRecetaProducto";
            this.Load += new System.EventHandler(this.UIRecetaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetaProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRecetaProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button btnRegistrarReceta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadMedida;
    }
}