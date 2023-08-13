using Byte_Coffee.DB;
using Byte_Coffee.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Modelo
{
    public class modeloreserva
    {
        private Condb condb;
        public modeloreserva()
        {
            condb = new Condb();
        }
        public void Asignar_reservacion(string correo, string Fecha_reserva, string Hora_reserva)
        {
            NpgsqlConnection conexion = condb.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("call stored_procedures.crear_reserva(@correo,@Fecha_reserva,@Hora_reserva)", conexion);
            comando.Parameters.AddWithValue("@correo",correo);
            comando.Parameters.AddWithValue("@Fecha_reserva", Fecha_reserva);
            comando.Parameters.AddWithValue("@Hora_reserva", Hora_reserva);
            comando.ExecuteNonQuery();
            condb.CerrarConexion();
        }
    }
}
