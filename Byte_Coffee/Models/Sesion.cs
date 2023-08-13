using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Models
{
    public static class Sesion
    {
        public static int IdCliente { get; set; }
        public static string Nombre { get; set; }

        public static List<int> PlatillosPedidos { get; set; }
        public static void IniciarSesion(int idCliente, string nombre)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            PlatillosPedidos = new List<int>();
        }
        public static void AgregarPedido(int idPlatillo)
        {
            PlatillosPedidos.Add(idPlatillo);
        }

        public static List<int> PedidosRealizados()
        {
            return PlatillosPedidos;
        }
    }
}
