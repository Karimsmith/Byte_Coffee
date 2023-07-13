using Byte_Coffee.DB;
using Byte_Coffee.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Byte_Coffee.Modelo
{
    internal class ModeloRegistro
    {
        private readonly Condb condb;
        private const string emailRegex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)+)"
                    + @"(?<=[^\.])@(([a-z0-9]+-)?[a-z0-9]+\.)*[a-z]"
                    + @"{2,63}(\.[a-z]{2,})?$";
        public ModeloRegistro()
        {
            condb = new Condb();
        }
        public void AgregarCliente(UserModel cliente)
        {
            if (ValidacionCampos(cliente))
            {
                NpgsqlConnection conexion = condb.EstablecerConexion();
                string sentencia = "INSERT INTO clientes (nombre, apellido1, apellido2,fecha_registro, email, clave) VALUES (@nombre, @apellido1,@apellido2,@fecha_registro,@email,@clave)";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido1", cliente.Apellido1);
                comando.Parameters.AddWithValue("@apellido2", cliente.Apellido2);
                comando.Parameters.AddWithValue("@fecha_Registro", cliente.Fecha_Registro);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@clave", cliente.Clave);

                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    _ = new UserModel()
                    {
                        Nombre = lector.GetString(0),
                        Apellido1 = lector.GetString(1),
                        Apellido2 = lector.GetString(2),
                        Fecha_Registro = lector.GetString(3),
                        Email = lector.GetString(4),
                        Clave = lector.GetString(5),
                    };
                }
            }
        }
        public bool ValidacionCampos(UserModel cliente)
        {
            NpgsqlConnection conexion = condb.EstablecerConexion();
            string sentencia = "SELECT Email FROM clientes  WHERE email=@email LIMIT 1";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@email", cliente.Email);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido1) || string.IsNullOrEmpty(cliente.Apellido2) ||
                string.IsNullOrEmpty(cliente.Email) || string.IsNullOrEmpty(cliente.Clave))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                condb.CerrarConexion();
                return false;
            }
            else if (!Regex.IsMatch(cliente.Email, emailRegex))
            {
                MessageBox.Show("El correo tiene un formato incorrecto");
                condb.CerrarConexion();

                return false;
            }
            else if (lector.Read())
            {
                MessageBox.Show("El correo ya existe");
                condb.CerrarConexion();

                return false;
            }
            else
            {
                MessageBox.Show("Â¡Trabajador Ingresado Correctamente!");
                condb.CerrarConexion();
                return true;
            }
        }
    }
}
