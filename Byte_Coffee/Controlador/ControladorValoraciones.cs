using Byte_Coffee.Modelo;
using Byte_Coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class ControladorValoraciones
    {
        ModeloValoracion valoracion;
        public ControladorValoraciones()
        {
            valoracion = new ModeloValoracion();
        }
        public List<Valoraciones> valoraciones()
        {

            return valoracion.valoraciones();
        }
    }
}
