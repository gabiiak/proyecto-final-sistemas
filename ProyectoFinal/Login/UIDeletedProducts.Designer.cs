namespace Login
{
    partial class UIDeletedProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIDeletedProducts));
            this.dgvProductosEliminados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnDevolverMetodo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductosEliminados
            // 
            this.dgvProductosEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosEliminados.Location = new System.Drawing.Point(500, 15);
            this.dgvProductosEliminados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductosEliminados.Name = "dgvProductosEliminados";
            this.dgvProductosEliminados.RowHeadersWidth = 51;
            this.dgvProductosEliminados.Size = new System.Drawing.Size(551, 524);
            this.dgvProductosEliminados.TabIndex = 0;
            this.dgvProductosEliminados.SelectionChanged += new System.EventHandler(this.dgvProductosEliminados_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID: ";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(107, 44);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 16);
            this.labelId.TabIndex = 2;
            // 
            // btnDevolverMetodo
            // 
            this.btnDevolverMetodo.Location = new System.Drawing.Point(27, 76);
            this.btnDevolverMetodo.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevolverMetodo.Name = "btnDevolverMetodo";
            this.btnDevolverMetodo.Size = new System.Drawing.Size(277, 28);
            this.btnDevolverMetodo.TabIndex = 3;
            this.btnDevolverMetodo.Text = "Mostrar Producto Eliminado";
            this.btnDevolverMetodo.UseVisualStyleBackColor = true;
            this.btnDevolverMetodo.Click += new System.EventHandler(this.button1_Click);
            // 
            // UIDeletedProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnDevolverMetodo);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProductosEliminados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UIDeletedProducts";
            this.Text = "UIDeletedProducts";
            this.Load += new System.EventHandler(this.UIDeletedProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosEliminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductosEliminados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnDevolverMetodo;
    }
}