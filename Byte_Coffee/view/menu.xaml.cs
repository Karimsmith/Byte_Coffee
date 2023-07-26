using Byte_Coffee.Controlador;
using Byte_Coffee.Models;
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
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        private MenuControlador _menuControlador;
        public menu()
        {
            InitializeComponent();
            _menuControlador = new MenuControlador();
            List<Platillo> platillos = _menuControlador.CargarMenu();
            listaPlatillos.ItemsSource = platillos;
        }
    }
}
