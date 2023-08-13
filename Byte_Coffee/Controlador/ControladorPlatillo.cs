using Byte_Coffee.Modelo;
using Byte_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorPlatillo
    {
        private readonly ModeloPlatillo modeloPlatillo;

        public ControladorPlatillo()
        {
            modeloPlatillo = new ModeloPlatillo();
        }
        public void AgregarPlatillo(Platillo platillo)
        {
            modeloPlatillo.AgregarPlatillo(platillo);
        }
        public List<Platillo> CargarMenu()
        {
            return modeloPlatillo.CargarMenu();
        }

        public List<Platillo> ListaDePlatillosPedidos(List<int> IdPedidosPlatillo)
        {
            return modeloPlatillo.ListaDePedidos(IdPedidosPlatillo);
        }
        public List<Platillo> MenuMasPedidos()
        {
            return modeloPlatillo.MenuMasPedidos();
        }
        public List<Platillo> MenuMejorValorados()
        {
            return modeloPlatillo.MenuMejorValorados();
        }
        public void CompletarPedido(List<int> IdPlatillosPedidos, int IdCliente)
        {
            modeloPlatillo.CompletarPedido(IdPlatillosPedidos, IdCliente);
        }
        public void ValorarPedido(int IdPlatillo, int IdCliente, int Valoracion)
        {
            modeloPlatillo.ValorarPedido(IdPlatillo, IdCliente, Valoracion);
        }

    }
}
