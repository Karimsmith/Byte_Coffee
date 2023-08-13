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
using System.Windows.Threading;

namespace Byte_Coffee.view
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
            private readonly ControladorPlatillo controladorPlatillo;
            private readonly DispatcherTimer reloj;
            public menu()
            {
                InitializeComponent();
                controladorPlatillo = new ControladorPlatillo();
                List<Platillo> menuCargado = controladorPlatillo.CargarMenu();
                listaMenuCompleto.ItemsSource = menuCargado;
                List<Platillo> ocho_mas_pedidos = controladorPlatillo.MenuMasPedidos();
                listaOchoMasPedidos.ItemsSource = ocho_mas_pedidos;
                List<Platillo> ocho_mejor_valorados = controladorPlatillo.MenuMejorValorados();
                listaOchoMejorValorados.ItemsSource = ocho_mejor_valorados;
                NombreUsuario.Text = Sesion.Nombre;
                reloj = new DispatcherTimer();
                reloj.Interval = TimeSpan.FromSeconds(1);
                reloj.Tick += Reloj;
                reloj.Start();
                Loaded += V_Menu_Loaded;
            }
            private void V_Menu_Loaded(object sender, RoutedEventArgs e)
            {
                double anchoVentana = this.Width;
                Linea.X2 = anchoVentana;
            }
            private void Reloj(object sender, EventArgs e)
            {
                Hora.Text = DateTime.Now.ToString("HH:mm:ss");
            }

            private void BtnPedido_Click(object sender, RoutedEventArgs e)
            {
                BtnVerPedido.Visibility = Visibility.Visible;
                BtnValorarPedido.Visibility = Visibility.Visible;
                Button btnPedido = (Button)sender;
                Platillo platillo = (Platillo)btnPedido.DataContext;
                int idPlatillo = platillo.Id;
                Sesion.AgregarPedido(idPlatillo);
                BtnVerPedido.Visibility = Visibility.Visible;
            }

            private void BtnVerPedido_Click(object sender, RoutedEventArgs e)
            {
                V_ListaPedido pedidos = new V_ListaPedido(Sesion.PedidosRealizados());
                pedidos.Show();
            }

            private void BtnValorarPedido_Click(object sender, RoutedEventArgs e)
            {
                V_ValorarPedido valorarPedido = new V_ValorarPedido(Sesion.PedidosRealizados());
                valorarPedido.Show();
            }
        }
    }