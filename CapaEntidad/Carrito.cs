using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{


  //  Create table CARRITO(
//idCarrito int primary key identity,
//IdCliente  int References CLIENTE (idCliente),
//idProducto int References PRODUCTO (idProducto),
//Cantidad int

    public class Carrito
    {


        public int  idCarrito { get; set; }


        public Cliente oCliente { get; set; }

        public Producto oProducto { get; set; }



        public int Cantidad  { get; set; }



    }
}
