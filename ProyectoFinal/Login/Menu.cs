using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Login
{ 
    public partial class Menu : Form
    {
        // Variable para llevar el control del formulario que está abierto actualmente
        private Form formularioActivo = null;

        public Menu()
        {
            InitializeComponent();
            CargarGraficoVentas();
            CargarGraficoClientes();

        }
       
            // ... (Todo el código anterior del gráfico que ya tenías) ...

            // --- ¡ACTUALIZAMOS EL LABEL CON EL CONTEO DE TRANSACCIONES! ---
            
        
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
            if (formularioActivo != null)
            {
                formularioActivo.Close();

                // Buena práctica: volver a dejarlo en null para que el sistema 
                // sepa que ya no hay nada abierto en ese espacio.
                formularioActivo = null;
            }

            // --- ¡AQUÍ COLOCAMOS LA ACTUALIZACIÓN! ---
            // Cada vez que el usuario haga clic en 'Inicio' para regresar al menú principal,
            // el gráfico se limpiará y volverá a traer los datos frescos de la Capa de Negocio.
            CargarGraficoVentas();
            CargarGraficoClientes();
        }
        


        private void CargarGraficoVentas()
        {
            chartVentas.Series[0].Points.Clear();
            chartVentas.Series[0].ChartType = SeriesChartType.Column;
            chartVentas.Series[0].BorderWidth = 0;
            chartVentas.Series[0].Name = "Monto Vendido";

            // --- ¡ESTAS DOS LÍNEAS SON LA MAGIA! ---
            // 1. Obliga al gráfico a mostrar una etiqueta por cada punto exacto (sin saltarse ninguna)
            chartVentas.ChartAreas[0].AxisX.Interval = 1;

            // 2. Le dice al gráfico que los datos son categorías estrictas (1, 2, 3, 4) y no números al azar
            chartVentas.Series[0].IsXValueIndexed = true;
            // ---------------------------------------

            // Llamamos a tu capa de negocio
            var ventasUltimoMes = NVentas.GetVentasUltimas4Semanas();

            // Dibujamos las barras en el gráfico
            foreach (var item in ventasUltimoMes)
            {
                chartVentas.Series[0].Points.AddXY(item.Key, item.Value);
            }
            // Parte de cantidad de ventas de los ultimos 30 días
            int totalTransacciones = NVentas.GetCantidadVentasUltimos30Dias();
            lblCantidadVentasMes.Text = $"{totalTransacciones} ventas registradas";
        }
        private void CargarGraficoClientes()
        {
            // Limpiamos los puntos anteriores
            chartClientes.Series[0].Points.Clear();

            // Lo configuramos como gráfico de Torta (puedes cambiarlo a Doughnut si te gusta más)
            chartClientes.Series[0].ChartType = SeriesChartType.Pie;
            chartClientes.Series[0].Name = "Compras";

            // Habilitamos que se muestren los valores o etiquetas arriba del gráfico
            chartClientes.Series[0].IsValueShownAsLabel = true;

            // Pedimos el diccionario con el Top 5 a la Capa de Negocio
            var clientesFrecuentes = NVentas.GetClientesMasFrecuentes();

            // Cargamos los datos en el gráfico de torta
            foreach (var cliente in clientesFrecuentes)
            {
                // Key = Nombre del Cliente, Value = Cantidad de compras
                chartClientes.Series[0].Points.AddXY(cliente.Key, cliente.Value);
            }
        }

        private void btnMetodos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new UIPaymentMethodManagement());
        }

        private void btnGestionarVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new UISalesManagement());
        }
    }
}