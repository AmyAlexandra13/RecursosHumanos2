using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//idCategoria int primary key identity,
//Descripcion varchar (100),
//Activo bit default 1,
//fechaRegistro datetime default getdate()

namespace CapaEntidad
{
    public class Categoria
    {

     public int idCategoria { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
