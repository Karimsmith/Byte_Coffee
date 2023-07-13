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
                string sentencia = "INSERT INTO cliente (nombre, apellido1, apellido2,  Fecha_Registro, Email, clave) VALUES (@nombre, @apellido1,@apellido2,@correo_trabajador,@fecha_contratacion,@horario_trabajador,@puesto_trabajador,@salario_trabajador)";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido1", cliente.Apellido1);
                comando.Parameters.AddWithValue("@apellido2", cliente.Apellido2);
                comando.Parameters.AddWithValue("@Fecha_Registro", cliente.Fecha_Registro);
                comando.Parameters.AddWithValue("@correo", cliente.Email);
                comando.Parameters.AddWithValue("@Clave", cliente.Clave);

                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    UserModel clientes = new UserModel()
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
            string sentencia = $"SELECT Email FROM clientes  WHERE Emil=@correo LIMIT 1";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@Emil", cliente.Email);
            NpgsqlDataReader lector = comando.ExecuteReader();
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido1) || string.IsNullOrEmpty(cliente.Fecha_Registro) ||
                string.IsNullOrEmpty(cliente.Email) || string.IsNullOrEmpty(cliente.Clave))
            {
                MessageBox.Show("Todos los campos deben ser completados.");
                return false;
            }
            else if (!Regex.IsMatch(cliente.Email, emailRegex))
            {
                MessageBox.Show("El correo tiene un formato incorrecto");
                return false;
            }
            else if (lector.Read())
            {
                MessageBox.Show("El correo ya existe");
                return false;
            }
            else
            {
                MessageBox.Show("¡Trabajador Ingresado Correctamente!");
                return true;
            }
        }
    }
}
