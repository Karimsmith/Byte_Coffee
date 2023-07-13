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
    /// Interaction logic for sign.xaml
    /// </summary>
    public partial class sign : Window
    {
        private ControladorRegistro controladorcliente;
        DateTime fechaActual = DateTime.Now;
        public sign()
        {
            InitializeComponent();
            controladorcliente = new ControladorRegistro();

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            int dia, mes, anio;
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correo = txtcorreo.Text;
            string clave = txtclave.Password;
            dia = fechaActual.Day;
            mes = fechaActual.Month;
            anio = fechaActual.Year;
            ValidacionCampos();
            UserModel nuevoCliente = new UserModel()
            {

                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Email = correo,
                Fecha_Registro = $"{dia}/{mes}/{anio}",
                Clave = clave,
            };

            controladorcliente.AgregarCliente(nuevoCliente);

            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();

        }
        private bool ValidacionCampos()
        {
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string correo = txtcorreo.Text;
            string clave = txtclave.Password;
            UserModel cliente = new UserModel()
            {
                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2,
                Email = correo,
                Clave = clave

            };
            return  controladorcliente.ValidacionCampos(cliente);

        }

    }
}
