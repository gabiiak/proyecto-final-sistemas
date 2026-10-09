namespace Login
{
    partial class UIProveedoresEliminados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvProveedoresEliminados = new System.Windows.Forms.DataGridView();
            this.btnDevolverProveedor = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresEliminados)).BeginInit();
            this.SuspendLayout();
            //
            // dgvProveedoresEliminados
            //
            this.dgvProveedoresEliminados.AllowUserToAddRows = false;
            this.dgvProveedoresEliminados.AllowUserToDeleteRows = false;
            this.dgvProveedoresEliminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedoresEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedoresEliminados.Location = new System.Drawing.Point(13, 77);
            this.dgvProveedoresEliminados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProveedoresEliminados.Name = "dgvProveedoresEliminados";
            this.dgvProveedoresEliminados.ReadOnly = true;
            this.dgvProveedoresEliminados.RowHeadersVisible = false;
            this.dgvProveedoresEliminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedoresEliminados.Size = new System.Drawing.Size(614, 298);
            this.dgvProveedoresEliminados.TabIndex = 0;
            this.dgvProveedoresEliminados.SelectionChanged += new System.EventHandler(this.dgvProveedoresEliminados_SelectionChanged);
            //
            // btnDevolverProveedor
            //
            this.btnDevolverProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnDevolverProveedor.Location = new System.Drawing.Point(17, 41);
            this.btnDevolverProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevolverProveedor.Name = "btnDevolverProveedor";
            this.btnDevolverProveedor.Size = new System.Drawing.Size(277, 28);
            this.btnDevolverProveedor.TabIndex = 6;
            this.btnDevolverProveedor.Text = "Restaurar Proveedor Eliminado";
            this.btnDevolverProveedor.UseVisualStyleBackColor = true;
            this.btnDevolverProveedor.Click += new System.EventHandler(this.btnDevolverProveedor_Click);
            //
            // labelId
            //
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(97, 9);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 20);
            this.labelId.TabIndex = 5;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID: ";
            //
            // UIProveedoresEliminados
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 395);
            this.Controls.Add(this.btnDevolverProveedor);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProveedoresEliminados);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UIProveedoresEliminados";
            this.Text = "Proveedores Eliminados";
            this.Load += new System.EventHandler(this.UIProveedoresEliminados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresEliminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProveedoresEliminados;
        private System.Windows.Forms.Button btnDevolverProveedor;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label1;
    }
}