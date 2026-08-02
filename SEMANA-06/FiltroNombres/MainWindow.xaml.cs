using System.Runtime.CompilerServices;
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

namespace FiltroNombres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] Cadena;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtCadena.Text;
            if (string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show("Cadena de nombres vacía", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Cadena = nombres.Split(' ');
            lbxNombresListados.Items.Clear();
            foreach (string nombre in Cadena)
            {
                lbxNombresListados.Items.Add(nombre);
            }
            txtTotalNombres.Text = lbxNombresListados.Items.Count.ToString();

        }

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            if(Cadena == null || Cadena.Length == 0)
            {
                MessageBox.Show("Primero Lista los nombres", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filtro = txtLetra.Text;
            if(string.IsNullOrWhiteSpace(filtro))
            {
                MessageBox.Show("Ingrese letra a filtrar", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            lbxNombresFiltrados.Items.Clear();
            foreach (string nombre in Cadena)
            {
                if (nombre.StartsWith(filtro, StringComparison.OrdinalIgnoreCase))
                {
                    lbxNombresFiltrados.Items.Add(nombre);
                }
            }
            txtTotalFiltrados.Text = lbxNombresFiltrados.Items.Count.ToString();
        }
    }
}