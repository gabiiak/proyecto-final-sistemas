namespace Login
{
    partial class UIDeletedClients
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
            this.dgvClientesEliminados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientesEliminados
            // 
            this.dgvClientesEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesEliminados.Location = new System.Drawing.Point(328, 17);
            this.dgvClientesEliminados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvClientesEliminados.Name = "dgvClientesEliminados";
            this.dgvClientesEliminados.Size = new System.Drawing.Size(767, 261);
            this.dgvClientesEliminados.TabIndex = 0;
            this.dgvClientesEliminados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientesEliminados_CellContentClick);
            // 
            // UIDeletedClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 293);
            this.Controls.Add(this.dgvClientesEliminados);
            this.Font = new System.Drawing.Font("Ubuntu Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UIDeletedClients";
            this.Text = "UIDeletedClients";
            this.Load += new System.EventHandler(this.UIDeletedClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesEliminados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientesEliminados;
    }
}