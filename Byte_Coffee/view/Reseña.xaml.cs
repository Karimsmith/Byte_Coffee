using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Byte_Coffee.view
{
    /// <summary>
    /// Interaction logic for Reseña.xaml
    /// </summary>
    public partial class Reseña : Window
    {
        public Reseña()
        {
            InitializeComponent();
        }

        private void btnGenerareseña_ClicK(object sender, RoutedEventArgs e)
        {
            AgregarReseña agregar = new AgregarReseña();
            agregar.Show();
            this.Close();
        }

        private void Btneliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_inicio(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        private void Button_Click_Reservacion(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_menu(object sender, RoutedEventArgs e)
        {

        }
    }
}
