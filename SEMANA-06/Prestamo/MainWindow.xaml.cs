using System;
using System.Windows;

namespace Prestamo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // BOTÓN CALCULAR
        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            // Validar cliente
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Ingrese un nombre válido.",
                    "Dato inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtCliente.Focus();
                return;
            }

            // Validar monto
            decimal monto;

            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingrese un monto válido.",
                    "Dato inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtMonto.Focus();
                return;
            }

            // Validar fecha de vencimiento
            if (dtpFechaVencimiento.SelectedDate == null)
            {
                MessageBox.Show("Seleccione la fecha de vencimiento.",
                    "Dato inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                dtpFechaVencimiento.Focus();
                return;
            }

            // Validar fecha de pago
            if (dtpFechaPago.SelectedDate == null)
            {
                MessageBox.Show("Seleccione la fecha de pago.",
                    "Dato inválido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                dtpFechaPago.Focus();
                return;
            }

            // Obtener fechas
            DateTime fechaVencimiento = dtpFechaVencimiento.SelectedDate.Value;
            DateTime fechaPago = dtpFechaPago.SelectedDate.Value;

            // Calcular días de mora
            int diasMora = (fechaPago - fechaVencimiento).Days;

            // Si pagó antes o el mismo día
            if (diasMora < 0)
            {
                diasMora = 0;
            }

            // Calcular porcentaje total de mora
            decimal moraPorcentaje = diasMora * 0.5m;

            // Calcular mora en soles
            decimal moraSoles = monto * moraPorcentaje / 100;

            // Calcular monto total
            decimal montoTotal = monto + moraSoles;

            // Mostrar resultados
            txtDiasMora.Text = diasMora.ToString();
            txtMoraPorcentaje.Text = moraPorcentaje.ToString("0.00") + " %";
            txtMora.Text = moraSoles.ToString("0.00");
            txtMontoTotal.Text = montoTotal.ToString("0.00");
        }

        // BOTÓN NUEVO
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();

            txtDiasMora.Clear();
            txtMora.Clear();
            txtMoraPorcentaje.Clear();
            txtMontoTotal.Clear();

            dtpFechaVencimiento.SelectedDate = null;
            dtpFechaPago.SelectedDate = null;

            txtCliente.Focus();
        }

        // BOTÓN FINALIZAR
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show(
                "¿Desea finalizar el programa?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}