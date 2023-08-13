using Byte_Coffee.Controlador;
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
    /// Interaction logic for Resevarcion.xaml
    /// </summary>
    public partial class Resevarcion : Window
    {
        private Controlador_reserva controlador_reserva;

        public Resevarcion()
        {
            InitializeComponent();
            controlador_reserva = new Controlador_reserva();
        }

        private void btnReserva_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtcorreo.Text;
            string Fecha_reserva = dtFecha_reserva.SelectedDate.Value.Date.ToString("dd/MM/yyyy");
            string Hora_reserva = dtHora_reserva.Text;
            controlador_reserva.Asignar_reservacion(correo, Fecha_reserva, Hora_reserva);
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();

        }
    }
}
