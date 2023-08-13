using Byte_Coffee.Controlador;
using Byte_Coffee.DB;
using Byte_Coffee.Models;
using Npgsql;
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
using static System.Collections.Specialized.BitVector32;

namespace Byte_Coffee.view
{
    /// <summary>
    /// Interaction logic for V_ListaPedido.xaml
    /// </summary>
    public partial class V_ListaPedido : Window
    {
        private readonly ControladorPlatillo controladorPlatillo;
        private Condb conxBD;
        public V_ListaPedido(List<int> listaIdPlatillosPedidos)
        {
            InitializeComponent();
            conxBD = new Condb();
            controladorPlatillo = new ControladorPlatillo();
            listaPedidos.ItemsSource = controladorPlatillo.ListaDePlatillosPedidos(listaIdPlatillosPedidos);
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT SUM(precio) FROM platillo WHERE id_platillo = ANY(@listaIdPlatillosPedidos)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@listaIdPlatillosPedidos", listaIdPlatillosPedidos);
            decimal totalPrecios = (decimal)comando.ExecuteScalar();
            conxBD.CerrarConexion();
            totalprecio.Text = totalPrecios.ToString();
        }
        private void BtnCompletarPedido_Click(object sender, RoutedEventArgs e)
        {

            this.IsEnabled = false;
            controladorPlatillo.CompletarPedido(Sesion.PlatillosPedidos, Sesion.IdCliente);
            this.Close();

        }
    }
}
