using Byte_Coffee.DB;
using Npgsql;
using System;
using System.Collections.Generic;
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
            string sentencia = "select email, clave from clientes where email=@correo and clave=@clave";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conn);
            comando.Parameters.AddWithValue("@correo", Correo);
            comando.Parameters.AddWithValue("@clave", Clave);
            NpgsqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
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
