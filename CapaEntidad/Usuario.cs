using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad

    



{
    public class Usuario
    {


        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string Correo { get; set; }
        public string Clave { get; set; }

        public bool Restablecer { get; set; }

        public bool Activo { get; set; }
        public string Numero_de_doc { get; set; }
        public string Telefono { get; set; }
        public string Numero_Cuenta { get; set; }
        public string Salario { get; set; }
       
        



        


    }
}
