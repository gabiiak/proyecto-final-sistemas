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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIDeletedClients));
            this.dgvClientesEliminados = new System.Windows.Forms.DataGridView();
            this.btnDevolverCliente = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientesEliminados
            // 
            this.dgvClientesEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesEliminados.Location = new System.Drawing.Point(13, 77);
            this.dgvClientesEliminados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClientesEliminados.Name = "dgvClientesEliminados";
            this.dgvClientesEliminados.RowHeadersWidth = 51;
            this.dgvClientesEliminados.Size = new System.Drawing.Size(350, 298);
            this.dgvClientesEliminados.TabIndex = 0;
            this.dgvClientesEliminados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientesEliminados_CellContentClick);
            this.dgvClientesEliminados.SelectionChanged += new System.EventHandler(this.dgvClientesEliminados_SelectionChanged);
            // 
            // btnDevolverCliente
            // 
            this.btnDevolverCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnDevolverCliente.Location = new System.Drawing.Point(17, 41);
            this.btnDevolverCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevolverCliente.Name = "btnDevolverCliente";
            this.btnDevolverCliente.Size = new System.Drawing.Size(277, 28);
            this.btnDevolverCliente.TabIndex = 6;
            this.btnDevolverCliente.Text = "Mostrar Cliente Eliminado";
            this.btnDevolverCliente.UseVisualStyleBackColor = true;
            this.btnDevolverCliente.Click += new System.EventHandler(this.btnDevolverCliente_Click_1);
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
            // UIDeletedClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 406);
            this.Controls.Add(this.btnDevolverCliente);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClientesEliminados);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UIDeletedClients";
            this.Text = "UIDeletedClients";
            this.Load += new System.EventHandler(this.UIDeletedClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesEliminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientesEliminados;
        private System.Windows.Forms.Button btnDevolverCliente;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label1;
    }
}