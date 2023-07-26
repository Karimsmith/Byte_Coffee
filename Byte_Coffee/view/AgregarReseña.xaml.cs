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
    /// Interaction logic for AgregarReseña.xaml
    /// </summary>
    public partial class AgregarReseña : Window
    {
        public AgregarReseña()
        {
            InitializeComponent();
        }

        private void txtCalificacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAgregar_ClicK(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregar_ClicKbtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Reseña reseña = new Reseña();
            reseña.Show();
            this.Close();
        }
    }
}
