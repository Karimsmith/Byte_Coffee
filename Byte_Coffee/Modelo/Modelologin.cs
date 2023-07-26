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
