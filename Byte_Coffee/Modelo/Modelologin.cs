using Byte_Coffee.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Modelo
{
    public class Modelologin
    {
        private Condb condb;
        public Modelologin() { 
        condb = new Condb();
        }
        public (int, string) TomarDatosCliente(string correo)
        {
            NpgsqlConnection conexion = condb.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.tomar_datos_usuario(@correo_usuario)", conexion);
            comando.Parameters.AddWithValue("@correo_usuario", correo);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);
                condb.CerrarConexion();
                return (id, nombre);
            }
            else
            {
                condb.CerrarConexion();
                return (-1, null);
            }

        }
            public bool Validar(string Correo, String Clave)
        {
            NpgsqlConnection conn = condb.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.validar_cliente(@_email_cliente, @_clave_cliente)", conn);
            comando.Parameters.AddWithValue("@_email_cliente", Correo);
            comando.Parameters.AddWithValue("@_clave_cliente", Clave);
            bool reader = (bool)comando.ExecuteScalar();
            if (reader)
            {
                condb.CerrarConexion();
                return true;
            }
            else
            {
                condb.CerrarConexion();
                return false;

            }

        }
    }
}
