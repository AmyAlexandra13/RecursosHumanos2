using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad


   // create table CLIENTE(
//idCliente int primary key identity,
//Nombre Varchar (100),
//Apellidos Varchar(100),
//Correo Varchar(100),
//Clave varchar(150),
//Restablecer bit default 0,
//fechaRegistro datetime default getdate()
{
    public class Cliente
    {


        public int idCliente { get; set;  }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Restablecer { get; set; }



    }
}
