using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad




   // Create table VENTA(
//idVenta int primary key identity,
//IdCliente  int References CLIENTE (idCliente),
//TotalProducto int,
//MontoTotal decimal (10,2),
//Contacto varchar(50),
//idDistrito varchar(10),
//Telefono varchar(50),
//Direccion varchar(500),
//idTrasaccion varchar(50),
//fechaVenta datetime default getdate()


{
    public class Venta
    {


        public int idVenta { get; set; }

        public int IdCliente { get; set; }

        public int TotalProducto { get; set; }

        public decimal MontoTotal { get; set; }
        public string Telefono { get; set; }

        public string Contacto { get; set; }

        public string idDistrito { get; set; }

        public string Direccion { get; set; }

        public string idTrasaccion { get; set; }



          public List<Detalle_Venta> odetalle_Ventas { get; set;  }
    }
}
