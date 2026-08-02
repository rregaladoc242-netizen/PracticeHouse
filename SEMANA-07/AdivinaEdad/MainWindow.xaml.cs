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

namespace AdivinaEdad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int edadMinima;
        private int edadMaxima;
        private int edadPropuesta;
        private int intentos;

        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIntento_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtInferior.Text , out edadMinima))
            {
                MessageBox.Show("Ingrese una edad mínima válida" , "Edad invalida" , MessageBoxButton.OK  , MessageBoxImage.Warning);
                txtInferior.Focus();
                return;
            }

            if(!int.TryParse(txtSuperior.Text , out edadMaxima))
            {
                MessageBox.Show("Ingrese una edad máxima válida", "Edad invalida", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSuperior.Focus();
                return;
            }

            if(edadMinima >= edadMaxima)
            {
                MessageBox.Show("Ingrese un rango de edades válido", "Rango invalido", MessageBoxButton.OK, MessageBoxImage.Error);
                txtInferior.Focus();
                return;
            }

            edadPropuesta = random.Next(edadMinima , edadMaxima + 1);
            intentos++;
            txtEdadPropuesta.Text = edadPropuesta.ToString();


        }

        private void btnCorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (intentos == 0)
            {
                MessageBox.Show("Haga clic en primer Intento", "Intento invalido", MessageBoxButton.OK, MessageBoxImage.Warning);                 
                return;
            }
            MessageBox.Show($"Adivinaste en {intentos} intetos" , "Felicidades", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnIncorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (intentos == 0)
            {
                MessageBox.Show("Haga clic en primer Intento", "Intento invalido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
                edadPropuesta = random.Next(edadMinima, edadMaxima + 1);
                intentos++;
                txtEdadPropuesta.Text = edadPropuesta.ToString();
        }
    }
}