using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Models
{
    public class UserModel
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Fecha_Registro { get; set; }
        public string Ultima_Reserva { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

    }
}
