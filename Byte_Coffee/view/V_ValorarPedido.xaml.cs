using Byte_Coffee.Controlador;
using Byte_Coffee.Models;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for V_ValorarPedido.xaml
    /// </summary>
    public partial class V_ValorarPedido : Window
    {
        private readonly ControladorPlatillo controladorPlatillo;
        public V_ValorarPedido(List<int> ListaAValorar)
        {
            InitializeComponent();
            List<int> ListaUnicos = ListaAValorar.Distinct().ToList();
            controladorPlatillo = new ControladorPlatillo();
            ListaPedidos.ItemsSource = controladorPlatillo.ListaDePlatillosPedidos(ListaUnicos);
        }

        private void BtnValorarPedido_Click(object sender, RoutedEventArgs e)
        {
            Button btnPedido = (Button)sender;
            Platillo platillo = (Platillo)btnPedido.DataContext;
            int idPlatillo = platillo.Id;
            ListBoxItem listBoxItem = FindAncestor<ListBoxItem>(btnPedido);
            RatingBar ratingBar = FindVisualChild<RatingBar>(listBoxItem);
            int ratingValue = (int)ratingBar.Value;
            controladorPlatillo.ValorarPedido(idPlatillo, Sesion.IdCliente, ratingValue);

        }


        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                    return ancestor;

                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);

            return null;
        }

    }
}