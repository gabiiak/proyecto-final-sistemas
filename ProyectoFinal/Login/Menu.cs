using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Menu : Form
    {
        // Variable para llevar el control del formulario que está abierto actualmente
        private Form formularioActivo = null;

        public Menu()
        {
            InitializeComponent();
        }

        // --- MÉTODO MÁGICO PARA ABRIR FORMULARIOS DENTRO DEL PANEL ---
        private void AbrirFormularioHijo(Form formHijo)
        {
            // Si ya hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formHijo;

            // Configuramos el formulario hijo para que no parezca una ventana independiente
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None; // Le quitamos los bordes y botones de cerrar/minimizar
            formHijo.Dock = DockStyle.Fill; // Hacemos que llene el panel

            // Lo agregamos al panel contenedor y lo mostramos
            contenedor.Controls.Add(formHijo);
            contenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        // --- EVENTOS DE LOS BOTONES DEL MENÚ LATERAL ---
        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Llamamos al método pasándole una nueva instancia de tu UI de Productos
            AbrirFormularioHijo(new UIProductManagement());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Llamamos al método pasándole una nueva instancia de tu UI de Clientes
            AbrirFormularioHijo(new UIClientManagement());
        }

        
    }
}