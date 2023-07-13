using Byte_Coffee.DB;
using Byte_Coffee.Modelo;
using Byte_Coffee.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Byte_Coffee.Controlador
{
    
    public class ControladorRegistro
    {
        private ModeloRegistro modeloRegistro;

        public ControladorRegistro ()
        {
            modeloRegistro = new ModeloRegistro ();
        }
        public void AgregarCliente(UserModel cliente)
        {
            modeloRegistro.AgregarCliente(cliente);

        }

        public bool ValidacionCampos(UserModel cliente)
        {
            return modeloRegistro.ValidacionCampos (cliente);
        }

    }

}
