using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Byte_Coffee.DB
{
    public class Condb
    {
        NpgsqlConnection conexion = new NpgsqlConnection();
        static String servidor = "mahmud.db.elephantsql.com";
        static String nombre_base_datos = "xchvzdjj";
        static String usuario = "xchvzdjj";
        static String clave = "bPUPz1PviGoQ0n9vFAdM7mcydNGMkhDk";
        static String puerto = "5432";
        String urlConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + clave + ";" + "database=" + nombre_base_datos + ";";

        public NpgsqlConnection EstablecerConexion()
        {

            try
            {
               conexion.ConnectionString = urlConexion;
               conexion.Open();

            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
        public NpgsqlConnection CerrarConexion()
        {

            try
            {
                conexion.Close();

            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se pudo cerrar la conexion a la base de datos de PostgreSQL, error: " + e.ToString());

            }

            return conexion;
        }
    }
}
