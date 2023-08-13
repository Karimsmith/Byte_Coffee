using Byte_Coffee.DB;
using Byte_Coffee.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Byte_Coffee.Modelo
{
    public class ModeloValoracion
    {
        private Condb condb;
        public ModeloValoracion()
        {
            condb = new Condb();
        }
        public List<Valoraciones> valoraciones()
        {
           List<Valoraciones> valoraciones = new List<Valoraciones>();
           NpgsqlConnection conexion = condb.EstablecerConexion();
            string sentencia = "SELECT clientes.nombre || ' '|| clientes.apellido1 || ' ' || clientes.apellido2,platillo.nombre,valoraciones.valoracion FROM valoraciones INNER JOIN clientes ON clientes.id = valoraciones.id_cliente INNER JOIN platillo ON platillo.id_platillo = valoraciones.id_platillo";
            NpgsqlCommand command = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Valoraciones val = new Valoraciones()
                {
                    Nombre_Cliente = reader.GetString(0),
                    Nombre_Platillo = reader.GetString(1),
                    Valoracion = reader.GetInt32(2)
                };         
                valoraciones.Add(val);
                
            }
            condb.CerrarConexion();
            return valoraciones;
        }
    }
}
