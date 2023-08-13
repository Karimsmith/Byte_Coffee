using Byte_Coffee.Modelo;
using Byte_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class Controlador_reserva
    {
        modeloreserva modeloreserva;
        public Controlador_reserva() { 
        modeloreserva = new modeloreserva();
        }
        public void Asignar_reservacion(string correo, string Fecha_reserva, string Hora_reserva)
        {
            modeloreserva.Asignar_reservacion(correo,Fecha_reserva,Hora_reserva);
        }
    }
}
