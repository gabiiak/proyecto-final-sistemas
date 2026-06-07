namespace Login
{
    partial class UIDeletedPaymentMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIDeletedPaymentMethod));
            this.labelId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMetodosEliminados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodosEliminados)).BeginInit();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(-22, -6);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 13);
            this.labelId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-86, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Mostrar Metodo Eliminado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID: ";
            // 
            // dgvMetodosEliminados
            // 
            this.dgvMetodosEliminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMetodosEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodosEliminados.Location = new System.Drawing.Point(17, 101);
            this.dgvMetodosEliminados.Name = "dgvMetodosEliminados";
            this.dgvMetodosEliminados.RowHeadersWidth = 51;
            this.dgvMetodosEliminados.Size = new System.Drawing.Size(413, 189);
            this.dgvMetodosEliminados.TabIndex = 7;
            this.dgvMetodosEliminados.SelectionChanged += new System.EventHandler(this.dgvMetodosEliminados_SelectionChanged);
            // 
            // UIDeletedPaymentMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 310);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvMetodosEliminados);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UIDeletedPaymentMethod";
            this.Text = "UiDeletedPaymentMethod";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodosEliminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMetodosEliminados;
    }
}