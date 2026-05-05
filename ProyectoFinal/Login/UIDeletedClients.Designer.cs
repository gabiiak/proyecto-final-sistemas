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
            this.label1 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnDevolverCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientesEliminados
            // 
            this.dgvClientesEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesEliminados.Location = new System.Drawing.Point(328, 17);
            this.dgvClientesEliminados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClientesEliminados.Name = "dgvClientesEliminados";
            this.dgvClientesEliminados.Size = new System.Drawing.Size(767, 261);
            this.dgvClientesEliminados.TabIndex = 0;
            this.dgvClientesEliminados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientesEliminados_CellContentClick);
            this.dgvClientesEliminados.SelectionChanged += new System.EventHandler(this.dgvClientesEliminados_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID: ";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(71, 26);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 18);
            this.labelId.TabIndex = 2;
            // 
            // btnDevolverCliente
            // 
            this.btnDevolverCliente.Location = new System.Drawing.Point(28, 59);
            this.btnDevolverCliente.Name = "btnDevolverCliente";
            this.btnDevolverCliente.Size = new System.Drawing.Size(149, 23);
            this.btnDevolverCliente.TabIndex = 3;
            this.btnDevolverCliente.Text = "Mostrar Cliente";
            this.btnDevolverCliente.UseVisualStyleBackColor = true;
            this.btnDevolverCliente.Click += new System.EventHandler(this.btnDevolverCliente_Click);
            // 
            // UIDeletedClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 293);
            this.Controls.Add(this.btnDevolverCliente);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClientesEliminados);
            this.Font = new System.Drawing.Font("Ubuntu Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnDevolverCliente;
    }
}