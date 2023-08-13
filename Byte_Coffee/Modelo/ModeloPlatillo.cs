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
    public class ModeloPlatillo
    {
        private readonly Condb conxBD;

        public ModeloPlatillo()
        {
            conxBD = new Condb();
        }

        public void AgregarPlatillo(Platillo platillo)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "INSERT INTO Platillo (nombre,categoria,precio,descripcion,imagen) VALUES(@nombre,@categoria,@precio,@descripcion,@imagen)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@nombre", platillo.Nombre);
            comando.Parameters.AddWithValue("@categoria", platillo.Categoria);
            comando.Parameters.AddWithValue("@precio", platillo.Precio);
            comando.Parameters.AddWithValue("@descripcion", platillo.Descripcion);
            comando.Parameters.AddWithValue("@imagen", platillo.Imagen);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                _ = new Platillo()
                {
                    Nombre = lector.GetString(0),
                    Categoria = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4)
                };
            }
            conxBD.CerrarConexion();
        }
        public List<Platillo> CargarMenu()
        {
            List<Platillo> menu = new List<Platillo>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM stored_procedures.cargar_menu()", conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4),
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
        public List<Platillo> MenuMasPedidos()
        {
            List<Platillo> menu = new List<Platillo>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT platillo.id_platillo,platillo.nombre,platillo.precio,platillo.descripcion,platillo.imagen,AVG(valoraciones.valoracion)::numeric(5) FROM platillo INNER JOIN pedidos ON pedidos.id_platillo_pedido=platillo.id_platillo INNER JOIN valoraciones ON platillo.id_platillo=valoraciones.id_platillo GROUP BY platillo.id_platillo,platillo.nombre,platillo.precio,platillo.descripcion,platillo.imagen,valoraciones.valoracion ORDER BY COUNT(pedidos.id_platillo_pedido) DESC LIMIT 8";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4),
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
        public List<Platillo> MenuMejorValorados()
        {
            List<Platillo> menu = new List<Platillo>();
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "SELECT platillo.id_platillo,platillo.nombre,platillo.precio,platillo.descripcion,platillo.imagen,AVG(valoraciones.valoracion)::numeric(5) FROM valoraciones INNER JOIN platillo ON platillo.id_platillo=valoraciones.id_platillo WHERE valoracion = (SELECT MAX (valoracion) FROM valoraciones) GROUP BY platillo.id_platillo,platillo.nombre,platillo.precio,platillo.descripcion,platillo.imagen,valoraciones.valoracion";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            NpgsqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Platillo platillo = new Platillo()
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Descripcion = lector.GetString(3),
                    Imagen = lector.GetString(4),
                    Valoracion = lector.GetInt32(5)
                };
                menu.Add(platillo);
            }
            conxBD.CerrarConexion();
            return menu;
        }
        public List<Platillo> ListaDePedidos(List<int> IdPedidosPlatillo)
        {
            List<Platillo> PedidosRealizados = new List<Platillo>();
            foreach (int id in IdPedidosPlatillo)
            {
                NpgsqlConnection conexion = conxBD.EstablecerConexion();
                string sentencia = "SELECT platillo.id_platillo,platillo.nombre,platillo.precio,platillo.imagen,valoraciones.valoracion FROM platillo INNER JOIN valoraciones ON platillo.id_platillo=valoraciones.id_platillo WHERE platillo.id_platillo=@id ";
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Platillo platillo = new Platillo()
                    {
                        Id = lector.GetInt32(0),
                        Nombre = lector.GetString(1),
                        Precio = lector.GetDecimal(2),
                        Imagen = lector.GetString(3)
                    };
                    PedidosRealizados.Add(platillo);
                }
                conxBD.CerrarConexion();
            }
            return PedidosRealizados;

        }
        public void CompletarPedido(List<int> IdPlatillosPedidos, int IdCliente)
        {
            using (NpgsqlConnection conexion = conxBD.EstablecerConexion())
            {
                using (NpgsqlCommand comando = new NpgsqlCommand("SELECT stored_procedures.insertar_pedido_completo(@id_cliente)", conexion))
                {
                    comando.Parameters.AddWithValue("@id_cliente", IdCliente);
                    int idPedidoCompleto = (int)comando.ExecuteScalar();

                    foreach (int IdPlatilloPedido in IdPlatillosPedidos)
                    {
                        using (NpgsqlCommand comandoPedidos = new NpgsqlCommand("SELECT stored_procedures.insertar_pedidos_individuales(@id_platillo_pedido, @id_cliente, @id_pedido_completo)", conexion))
                        {
                            comandoPedidos.Parameters.AddWithValue("@id_platillo_pedido", IdPlatilloPedido);
                            comandoPedidos.Parameters.AddWithValue("@id_cliente", IdCliente);
                            comandoPedidos.Parameters.AddWithValue("@id_pedido_completo", idPedidoCompleto);
                            comandoPedidos.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public void ValorarPedido(int IdPlatillo, int IdCliente, int Valoracion)
        {
            NpgsqlConnection conexion = conxBD.EstablecerConexion();
            string sentencia = "INSERT INTO valoraciones(id_platillo,id_cliente,valoracion) VALUES(@id_platillo,@id_cliente,@valoracion)";
            NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
            comando.Parameters.AddWithValue("@id_platillo", IdPlatillo);
            comando.Parameters.AddWithValue("@id_cliente", IdCliente);
            comando.Parameters.AddWithValue("@valoracion", Valoracion);
            comando.ExecuteNonQuery();
            conxBD.CerrarConexion();
        }
    }
}
