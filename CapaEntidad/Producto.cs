using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





//idProducto int primary key identity ,
//Nombre varchar (500),
//Descripcion varchar(500),
//idMarca int References MARCA(idMarca),
//idCategoria int References CATEGORIA (idCategoria),
//Precio decimal(10, 2) default 0 ,
//Stock int ,
//RutaImgen varchar(100),
//NombreImagen varchar(100),
//Activo bit default 1,
//fechaRegistro datetime default getdate()//



namespace CapaEntidad
{
    public  class Producto
    {


        public int idProducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Marca oMarca { get; set; }

        public Categoria oCategoria { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string RutaImgen { get; set; }

        public string NombreImagen { get; set; }


        public bool Activo { get; set; }










    }
}
