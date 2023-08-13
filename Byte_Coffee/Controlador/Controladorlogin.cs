using Byte_Coffee.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Coffee.Controlador
{
    public class Controladorlogin
    {
        private Modelologin modelologin;

        public Controladorlogin()
            {
            modelologin = new Modelologin();
            }
        public bool Validar(string correo, string clave)
        {
            return modelologin.Validar(correo, clave);
        }
        public (int, string) TomarDatosCliente(string correo)
        {
            return modelologin.TomarDatosCliente(correo);
        }
    }
}
