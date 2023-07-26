using Byte_Coffee.Modelo;
using Byte_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    internal class MenuControlador
    {
        private readonly modeloMenu modeloPlatillo;

        public MenuControlador()
        {
            modeloPlatillo = new modeloMenu();
        }
        public void AgregarPlatillo(Platillo platillo)
        {
            modeloPlatillo.AgregarPlatillo(platillo);
        }
        public List<Platillo> CargarMenu()
        {
            return modeloPlatillo.CargarMenu();
        }
    }
}
