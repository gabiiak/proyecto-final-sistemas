using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Login
{
    public static class UIStyles
    {
        public static Color Primario = Color.FromArgb(24, 95, 165);
        public static Color AzulOscuro = Color.FromArgb(28, 58, 94);
        public static Color HoverSidebar = Color.FromArgb(55, 138, 221);
        public static Color BordeClaro = Color.FromArgb(181, 212, 244);
        public static Color FondoCampo = Color.FromArgb(244, 247, 251);
        public static Color GrisTexto = Color.FromArgb(136, 135, 128);
        public static Color BordePanel = Color.FromArgb(211, 209, 199);
        public static Color Blanco = Color.White;

        public static void ConfigurarLabel(Label lbl, string texto, Point ubicacion, Size tamaño)
        {
            lbl.Text = texto;
            lbl.ForeColor = GrisTexto;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = tamaño;
            lbl.AutoSize = false;
        }

        public static void ConfigurarTextBox(TextBox txt, Point ubicacion, Size tamaño, int tabIndex)
        {
            txt.Location = ubicacion;
            txt.Size = tamaño;
            txt.Font = new Font("Segoe UI", 10F);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = FondoCampo;
            txt.TabIndex = tabIndex;
        }

        public static void ConfigurarComboBox(ComboBox cmb, Point ubicacion, Size tamaño, int tabIndex,
            ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown)
        {
            cmb.Location = ubicacion;
            cmb.Size = tamaño;
            cmb.Font = new Font("Segoe UI", 10F);
            cmb.FormattingEnabled = true;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = FondoCampo;
            cmb.DropDownStyle = dropDownStyle;
            cmb.TabIndex = tabIndex;
        }

        public static void ConfigurarBotonPrimario(Button btn, string texto, Point ubicacion, int tabIndex,
            Size tamaño = default(Size))
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            if (tamaño != Size.Empty) btn.Size = tamaño;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Primario;
            btn.ForeColor = Blanco;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        public static void ConfigurarBotonSecundario(Button btn, string texto, Point ubicacion, int tabIndex,
            Size tamaño = default(Size))
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            if (tamaño != Size.Empty) btn.Size = tamaño;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = BordeClaro;
            btn.BackColor = Blanco;
            btn.ForeColor = Primario;
            btn.Font = new Font("Segoe UI", 10F);
            btn.Cursor = Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        public static void ConfigurarBotonFantasma(Button btn, string texto, Point ubicacion, int tabIndex,
            Size tamaño = default(Size))
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            if (tamaño != Size.Empty) btn.Size = tamaño;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = GrisTexto;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btn.Cursor = Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        public static void ConfigurarBotonEstado(Button btn, string texto, Point ubicacion,
            Color backColor, Color foreColor, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new Size(260, 44);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        public static void ConfigurarLabelHeader(Label lbl, string texto, Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = GrisTexto;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.Location = ubicacion;
            lbl.Size = new Size(70, 20);
        }

        public static void ConfigurarLabelHeaderValor(Label lbl, string texto, Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = AzulOscuro;
            lbl.Font = new Font("Segoe UI", 9.5F);
            lbl.Location = ubicacion;
            lbl.Size = new Size(230, 20);
        }

        public static void ConfigurarLabelKey(Label lbl, string texto, Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = GrisTexto;
            lbl.Font = new Font("Segoe UI", 8F);
            lbl.Location = ubicacion;
            lbl.Size = new Size(200, 16);
            lbl.AutoSize = false;
        }

        public static void ConfigurarLabelValor(Label lbl, Point ubicacion)
        {
            lbl.ForeColor = AzulOscuro;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.Location = ubicacion;
            lbl.Size = new Size(200, 22);
            lbl.AutoSize = false;
        }

        public static void ConfigurarBotonSidebar(Button btn, string texto, int indice)
        {
            btn.Text = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = HoverSidebar;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = BordeClaro;
            btn.Font = new Font("Segoe UI", 10F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(16, 0, 0, 0);
            btn.Dock = DockStyle.Top;
            btn.Height = 48;
            btn.Tag = indice;
        }

        public static void PintarPanelRedondeado(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            using (var pen = new Pen(BordePanel, 1f))
            {
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                int r = 8;
                using (var path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                    path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                    path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                    path.CloseFigure();
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}