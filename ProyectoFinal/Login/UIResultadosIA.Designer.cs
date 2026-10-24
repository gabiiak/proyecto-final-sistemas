namespace Login
{
    partial class UIResultadosIA
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlMetricas = new System.Windows.Forms.Panel();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblConclusion = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblEquilibrio = new System.Windows.Forms.Label();
            this.lblDistincion = new System.Windows.Forms.Label();
            this.lblAciertos = new System.Windows.Forms.Label();
            this.lblPrueba = new System.Windows.Forms.Label();
            this.lblEntrenamiento = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlGraficoResultadosIA = new System.Windows.Forms.Panel();
            this.lblTituloGraficoResultadosIA = new System.Windows.Forms.Label();
            this.pnlMetricas.SuspendLayout();
            this.pnlGraficoResultadosIA.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblTitulo.Location = new System.Drawing.Point(25, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(465, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Resultados del Análisis de Inteligencia Artificial";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 65);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(300, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Evaluación del modelo predictivo de proveedores";
            // 
            // pnlMetricas
            // 
            this.pnlMetricas.BackColor = System.Drawing.Color.White;
            this.pnlMetricas.Controls.Add(this.lblNota);
            this.pnlMetricas.Controls.Add(this.lblConclusion);
            this.pnlMetricas.Controls.Add(this.lblReferencia);
            this.pnlMetricas.Controls.Add(this.lblEquilibrio);
            this.pnlMetricas.Controls.Add(this.lblDistincion);
            this.pnlMetricas.Controls.Add(this.lblAciertos);
            this.pnlMetricas.Controls.Add(this.lblPrueba);
            this.pnlMetricas.Controls.Add(this.lblEntrenamiento);
            this.pnlMetricas.Location = new System.Drawing.Point(25, 110);
            this.pnlMetricas.Name = "pnlMetricas";
            this.pnlMetricas.Size = new System.Drawing.Size(629, 380);
            this.pnlMetricas.TabIndex = 2;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.ForeColor = System.Drawing.Color.DimGray;
            this.lblNota.Location = new System.Drawing.Point(20, 344);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(222, 15);
            this.lblNota.TabIndex = 7;
            this.lblNota.Text = "Resultados obtenidos con datos simulados.";
            // 
            // lblConclusion
            // 
            this.lblConclusion.AutoSize = true;
            this.lblConclusion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.lblConclusion.Location = new System.Drawing.Point(20, 292);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(200, 17);
            this.lblConclusion.TabIndex = 6;
            this.lblConclusion.Text = "Conclusión: análisis pendiente.";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblReferencia.Location = new System.Drawing.Point(20, 240);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(226, 17);
            this.lblReferencia.TabIndex = 5;
            this.lblReferencia.Text = "Referencia básica de comparación: --";
            // 
            // lblEquilibrio
            // 
            this.lblEquilibrio.AutoSize = true;
            this.lblEquilibrio.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEquilibrio.Location = new System.Drawing.Point(20, 187);
            this.lblEquilibrio.Name = "lblEquilibrio";
            this.lblEquilibrio.Size = new System.Drawing.Size(241, 17);
            this.lblEquilibrio.TabIndex = 4;
            this.lblEquilibrio.Text = "Equilibrio entre precisión y detección: --";
            // 
            // lblDistincion
            // 
            this.lblDistincion.AutoSize = true;
            this.lblDistincion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDistincion.Location = new System.Drawing.Point(20, 130);
            this.lblDistincion.Name = "lblDistincion";
            this.lblDistincion.Size = new System.Drawing.Size(291, 17);
            this.lblDistincion.TabIndex = 3;
            this.lblDistincion.Text = "Capacidad para distinguir entregas puntuales: --";
            // 
            // lblAciertos
            // 
            this.lblAciertos.AutoSize = true;
            this.lblAciertos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAciertos.Location = new System.Drawing.Point(20, 77);
            this.lblAciertos.Name = "lblAciertos";
            this.lblAciertos.Size = new System.Drawing.Size(155, 17);
            this.lblAciertos.TabIndex = 2;
            this.lblAciertos.Text = "Porcentaje de aciertos: --";
            // 
            // lblPrueba
            // 
            this.lblPrueba.AutoSize = true;
            this.lblPrueba.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPrueba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblPrueba.Location = new System.Drawing.Point(385, 25);
            this.lblPrueba.Name = "lblPrueba";
            this.lblPrueba.Size = new System.Drawing.Size(202, 17);
            this.lblPrueba.TabIndex = 1;
            this.lblPrueba.Text = "Registros usados para probar: --";
            // 
            // lblEntrenamiento
            // 
            this.lblEntrenamiento.AutoSize = true;
            this.lblEntrenamiento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrenamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.lblEntrenamiento.Location = new System.Drawing.Point(20, 25);
            this.lblEntrenamiento.Name = "lblEntrenamiento";
            this.lblEntrenamiento.Size = new System.Drawing.Size(210, 17);
            this.lblEntrenamiento.TabIndex = 0;
            this.lblEntrenamiento.Text = "Registros usados para entrenar: --";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(635, 513);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 36);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // pnlGraficoResultadosIA
            // 
            this.pnlGraficoResultadosIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraficoResultadosIA.BackColor = System.Drawing.Color.White;
            this.pnlGraficoResultadosIA.Controls.Add(this.lblTituloGraficoResultadosIA);
            this.pnlGraficoResultadosIA.Location = new System.Drawing.Point(742, 110);
            this.pnlGraficoResultadosIA.Name = "pnlGraficoResultadosIA";
            this.pnlGraficoResultadosIA.Size = new System.Drawing.Size(545, 380);
            this.pnlGraficoResultadosIA.TabIndex = 4;
            // 
            // lblTituloGraficoResultadosIA
            // 
            this.lblTituloGraficoResultadosIA.AutoSize = true;
            this.lblTituloGraficoResultadosIA.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGraficoResultadosIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblTituloGraficoResultadosIA.Location = new System.Drawing.Point(20, 15);
            this.lblTituloGraficoResultadosIA.Name = "lblTituloGraficoResultadosIA";
            this.lblTituloGraficoResultadosIA.Size = new System.Drawing.Size(218, 20);
            this.lblTituloGraficoResultadosIA.TabIndex = 0;
            this.lblTituloGraficoResultadosIA.Text = "COMPARACIÓN DEL MODELO";
            // 
            // UIResultadosIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1334, 641);
            this.Controls.Add(this.pnlGraficoResultadosIA);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlMetricas);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "UIResultadosIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados del Análisis de IA";
            this.pnlMetricas.ResumeLayout(false);
            this.pnlMetricas.PerformLayout();
            this.pnlGraficoResultadosIA.ResumeLayout(false);
            this.pnlGraficoResultadosIA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlMetricas;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblConclusion;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblEquilibrio;
        private System.Windows.Forms.Label lblDistincion;
        private System.Windows.Forms.Label lblAciertos;
        private System.Windows.Forms.Label lblPrueba;
        private System.Windows.Forms.Label lblEntrenamiento;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlGraficoResultadosIA;
        private System.Windows.Forms.Label lblTituloGraficoResultadosIA;
    }
}