using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Models
{
    internal class Platillo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Valoracion { get; set; }
        public string Imagen { get; set; }
    }
}
