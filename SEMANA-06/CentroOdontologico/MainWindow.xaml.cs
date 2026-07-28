using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CentroOdontologico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void btnCronograma_Click(object sender, RoutedEventArgs e)
        {

            //VALIDAR PACIENTE
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("Ingrese Nombre del Paciente", "Nombre invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPaciente.Focus();
                return;
            }
            //VALIDAR TRATAMIENTO
            if (cmbTratamiento.SelectedItem == null)
            {
                MessageBox.Show("Selecione un tratamiento", "Trantamiento invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTratamiento.Focus();
                return;
            }
            //VALIDAR PIEZA DENTAL
            if (cmbPiezaDental.SelectedItem == null)
            {
                MessageBox.Show("Selecione un Pieza Dental", "Pieza dental invalida", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbPiezaDental.Focus();
                return;
            }
            //VALIDAR FECHA
            if (calCita.SelectedDate == null)
            {
                MessageBox.Show("Selecione una fecha", "Fecha invalida", MessageBoxButton.OK, MessageBoxImage.Warning);
                calCita.Focus();
                return;
            }


            //=====OBTENER DATOS=====
            string paciente = txtPaciente.Text;
            string tratamiento = ((ComboBoxItem)cmbTratamiento.SelectedItem).Content.ToString();
            string piezaDental = ((ComboBoxItem)cmbPiezaDental.SelectedItem).Content.ToString();
            DateTime fechaCita = calCita.SelectedDate.Value;
            DateTime proximaCita = fechaCita.AddDays(15);
            string reporte =
                "Reporte de Cita\n" +
                "====================\n" +
                $"Paciente      :{paciente}\n" +
                $"Tratamiento   :{tratamiento}\n" +
                $"Pieza Dental  :{piezaDental}\n" +
                $"Fecha Cita    :{fechaCita.ToShortDateString()}\n" +
                $"Proxima Cita  :{proximaCita.ToShortDateString()}\n";
            txtReporte.Text = reporte;
        }
    }
}