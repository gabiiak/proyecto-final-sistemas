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
            //prueba de chart/estadísticas de negocio
            var data = new[] {
                new { Month = "Enero", Sales = 30 , SalesEstimate = 40},
                new { Month = "Febrero", Sales = 20 , SalesEstimate = 30},
                new { Month = "Marzo", Sales = 40 , SalesEstimate = 20},
                new { Month = "Abril", Sales = 70 , SalesEstimate = 50}
            };

            chart1.DataSource = data;
            chart1.Series["Ventas"].XValueMember = "Month";
            chart1.Series["Ventas"].YValueMembers = "Sales";
            chart1.Series["Estimación de Ventas"].XValueMember = "Month";
            chart1.Series["Estimación de Ventas"].YValueMembers = "SalesEstimate";
            chart1.DataBind();

            //prueba de progress bar <- esto se puede enlazar a la BD en un futuro
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 34;
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            progressBar2.Value = 60;
        }

        // --- MÉTODO MÁGICO PARA ABRIR FORMULARIOS DENTRO DEL PANEL --- <-???
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
            formHijo.Dock = DockStyle.Fill; // <- lo cambié para que se vea el estado activo

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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            formularioActivo.Close();
        }
    }
}