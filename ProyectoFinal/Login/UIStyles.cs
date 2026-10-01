using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public enum Tema
    {
        Claro,
        Oscuro
    }

    public static class UIStyles
    {
        // ── Tema activo ────────────────────────────────────────────────
        public static Tema TemaActual { get; private set; } = Tema.Claro;

        public static event EventHandler TemaCambiado;

        // Sin esto la paleta quedaría en Color.Empty (transparente) hasta que alguien
        // llame a AplicarTema. Se corre al primer acceso a la clase.
        static UIStyles()
        {
            AplicarTema(LeerTema(), notificar: false);
        }

        // ── Paleta ─────────────────────────────────────────────────────
        // Claro
        public static Color Primario;
        // Variante de Primario para fondos oscuros (texto de botones secundarios).
        public static Color PrimarioClaro;
        public static Color AzulOscuro;
        public static Color HoverSidebar;
        public static Color BordeClaro;
        public static Color FondoCampo;
        public static Color GrisTexto;
        public static Color BordePanel;
        public static Color Blanco = Color.White;
        public static Color Superficie;
        public static Color TextoPrincipal;
        public static Color TextoCampo;
        public static Color BordeBoton;
        public static Color FondoDataGrid;
        public static Color FondoDataGridAlterno;
        public static Color TextoDataGrid;
        public static Color EncabezadoDataGrid;
        public static Color TextoEncabezado;
        public static Color BordeDataGrid;
        public static Color SeleccionDataGrid;
        public static Color TextoSobreSeleccion;

        // ── Aplicación del tema ────────────────────────────────────────
        public static void AplicarTema(Tema tema, bool notificar = true)
        {
            TemaActual = tema;

            if (tema == Tema.Oscuro)
            {
                // Se conservan los azules de la paleta (identidad de la app) y se invierten
                // las superficies y los textos.
                Primario = Color.FromArgb(24, 95, 165);
                HoverSidebar = Color.FromArgb(55, 138, 221);
                BordeClaro = Color.FromArgb(181, 212, 244);
                PrimarioClaro = Color.FromArgb(122, 176, 235);

                AzulOscuro = Color.FromArgb(18, 38, 62);      // sidebar
                FondoCampo = Color.FromArgb(32, 38, 48);      // fondo de contenido y campos
                Superficie = Color.FromArgb(40, 47, 59);      // header y botones secundarios
                GrisTexto = Color.FromArgb(154, 162, 174);    // texto secundario
                TextoPrincipal = Color.FromArgb(226, 232, 240);
                TextoCampo = Color.FromArgb(226, 232, 240);
                BordePanel = Color.FromArgb(58, 66, 79);
                BordeBoton = Color.FromArgb(70, 90, 120);

                FondoDataGrid = Color.FromArgb(38, 44, 56);
                FondoDataGridAlterno = Color.FromArgb(44, 51, 64);
                TextoDataGrid = Color.FromArgb(226, 232, 240);
                EncabezadoDataGrid = Color.FromArgb(24, 30, 40);
                TextoEncabezado = Color.FromArgb(181, 212, 244);
                BordeDataGrid = Color.FromArgb(60, 68, 82);
                SeleccionDataGrid = Color.FromArgb(24, 95, 165);
                TextoSobreSeleccion = Color.White;
            }
            else
            {
                Primario = Color.FromArgb(24, 95, 165);
                HoverSidebar = Color.FromArgb(55, 138, 221);
                BordeClaro = Color.FromArgb(181, 212, 244);
                PrimarioClaro = Color.FromArgb(24, 95, 165);

                AzulOscuro = Color.FromArgb(28, 58, 94);
                FondoCampo = Color.FromArgb(244, 247, 251);
                Superficie = Color.White;
                GrisTexto = Color.FromArgb(136, 135, 128);
                TextoPrincipal = Color.FromArgb(28, 58, 94);
                TextoCampo = Color.FromArgb(0, 0, 0);          // igual al default del TextBox
                BordePanel = Color.FromArgb(211, 209, 199);
                BordeBoton = Color.FromArgb(181, 212, 244);

                FondoDataGrid = Color.White;
                // Replica el (248,250,253) que traían los .Designer, para no cambiar
                // la apariencia del tema claro.
                FondoDataGridAlterno = Color.FromArgb(248, 250, 253);
                TextoDataGrid = Color.FromArgb(33, 37, 41);
                EncabezadoDataGrid = Color.FromArgb(244, 247, 251);
                TextoEncabezado = Color.FromArgb(28, 58, 94);
                BordeDataGrid = Color.FromArgb(211, 209, 199);
                SeleccionDataGrid = Color.FromArgb(181, 212, 244);
                TextoSobreSeleccion = Color.FromArgb(24, 42, 66);
            }

            GuardarTema();
            if (notificar) TemaCambiado?.Invoke(null, EventArgs.Empty);
        }

        public static void AlternarTema()
        {
            AplicarTema(TemaActual == Tema.Claro ? Tema.Oscuro : Tema.Claro);
        }

        // ── Persistencia ───────────────────────────────────────────────
        private static string RutaArchivo
        {
            get
            {
                string dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TSystem");
                return Path.Combine(dir, "tema.txt");
            }
        }

        public static Tema LeerTema()
        {
            try
            {
                if (File.Exists(RutaArchivo))
                    return File.ReadAllText(RutaArchivo).Trim() == "Oscuro" ? Tema.Oscuro : Tema.Claro;
            }
            catch { }
            return Tema.Claro;
        }

        private static void GuardarTema()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));
                File.WriteAllText(RutaArchivo, TemaActual.ToString());
            }
            catch { }
        }

        // ── Controles ──────────────────────────────────────────────────
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
            txt.ForeColor = TextoCampo;   // sin esto el texto queda negro sobre fondo oscuro
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
            cmb.ForeColor = TextoCampo;
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
            btn.FlatAppearance.BorderColor = BordeBoton;
            btn.BackColor = Superficie;
            btn.ForeColor = PrimarioClaro;
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
            lbl.ForeColor = TextoPrincipal;
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
            lbl.ForeColor = TextoPrincipal;
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

        // ── Aplicación recursiva sobre un form ────────────────────────
        // Los .Designer tienen colores light hardcodeados (White, FromArgb(244,247,251),
        // etc.). En vez de editar 17 Designers, se recorren los controles y se traduce
        // cada color conocido a su equivalente del tema activo.
        public static void AplicarTemaAForm(Form form)
        {
            if (form == null) return;

            form.BackColor = FondoCampo;
            form.ForeColor = TextoPrincipal;

            foreach (Control c in form.Controls)
                AplicarTemaAControl(c);
        }

        private static void AplicarTemaAControl(Control c)
        {
            if (c is DataGridView dgv)
            {
                ConfigurarDataGrid(dgv);
            }
            else
            {
                TraducirColor(c);
                foreach (Control hijo in c.Controls)
                    AplicarTemaAControl(hijo);
            }

            if (c.HasChildren)
                foreach (Control hijo in c.Controls)
                    if (hijo is DataGridView dgvHijo)
                        ConfigurarDataGrid(dgvHijo);
        }

        // Traduce un color light hardcodeado al equivalente del tema actual.
        private static void TraducirColor(Control c)
        {
            Color back = c.BackColor;

            if (c is TextBox || c is ComboBox || c is ListBox || c is NumericUpDown)
            {
                c.BackColor = FondoCampo;
                c.ForeColor = TextoCampo;
                return;
            }

            c.BackColor = Traducir(back, Superficie, FondoCampo);

            // Los Labels con fondo transparente heredan el del form, así que sólo se
            // les toca el color de texto.
            if (c is Label lbl && back.A == 0)
            {
                lbl.ForeColor = Traducir(lbl.ForeColor, GrisTexto, GrisTexto);
                return;
            }

            c.ForeColor = Traducir(c.ForeColor, TextoCampo, TextoSobreSeleccion);

            if (c is Button btn)
                btn.FlatAppearance.BorderColor =
                    Traducir(btn.FlatAppearance.BorderColor, BordeBoton, HoverSidebar);
        }

        private static Color Traducir(Color origen, Color nuevo, Color porDefecto)
        {
            // Colores light hardcodeados en los Designers.
            if (origen.ToArgb() == Color.White.ToArgb()) return nuevo;
            if (origen.ToArgb() == Color.FromArgb(244, 247, 251).ToArgb()) return porDefecto;
            if (origen.ToArgb() == Color.FromArgb(248, 250, 253).ToArgb()) return porDefecto;
            if (origen.ToArgb() == Color.FromArgb(230, 241, 251).ToArgb()) return Superficie;
            if (origen.ToArgb() == Color.FromArgb(210, 228, 247).ToArgb()) return Superficie;
            if (origen.ToArgb() == Color.FromArgb(211, 209, 199).ToArgb()) return BordePanel;
            if (origen.ToArgb() == Color.FromArgb(28, 58, 94).ToArgb()) return TextoPrincipal;
            if (origen.ToArgb() == Color.FromArgb(136, 135, 128).ToArgb()) return GrisTexto;
            if (origen.ToArgb() == Color.FromArgb(24, 95, 165).ToArgb()) return PrimarioClaro;
            return origen;
        }

        // ── DataGridView ───────────────────────────────────────────────
        //.EnableHeadersVisualStyles = false es obligatorio: si queda en true, el header ignora
        // los colores que le pongamos y se dibuja con el tema del sistema.
        public static void ConfigurarDataGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = FondoDataGrid;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.GridColor = BordeDataGrid;

            dgv.DefaultCellStyle.BackColor = FondoDataGrid;
            dgv.DefaultCellStyle.ForeColor = TextoDataGrid;
            dgv.DefaultCellStyle.SelectionBackColor = SeleccionDataGrid;
            dgv.DefaultCellStyle.SelectionForeColor = TextoSobreSeleccion;

            // Sin esto las filas alternadas conservan el color light que traen los
            // .Designer y se ven como bandas blancas en modo oscuro.
            dgv.AlternatingRowsDefaultCellStyle.BackColor = FondoDataGridAlterno;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextoDataGrid;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = SeleccionDataGrid;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = TextoSobreSeleccion;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = EncabezadoDataGrid;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = EncabezadoDataGrid;

            dgv.RowHeadersDefaultCellStyle.BackColor = EncabezadoDataGrid;
            dgv.RowHeadersDefaultCellStyle.ForeColor = TextoEncabezado;
        }
    }
}
