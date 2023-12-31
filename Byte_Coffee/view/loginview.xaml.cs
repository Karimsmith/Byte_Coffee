﻿using Byte_Coffee.Controlador;
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
    /// Interaction logic for loginview.xaml
    /// </summary>
    public partial class loginview : Window
    {
        private Controladorlogin controladorlogin;
        
        public loginview()
        {

            InitializeComponent();
            controladorlogin = new Controladorlogin();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed) 
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

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtUser.Text;
            string clave = txtclave.Password;
            var resultado = controladorlogin.TomarDatosCliente(correo);
            if (controladorlogin.Validar(correo, clave))
            {
                Sesion.IniciarSesion(resultado.Item1, resultado.Item2);
                Inicio inicio = new Inicio();
                inicio.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sign sign = new sign();
            sign.Show();
            this.Close();
        }
    }
}
