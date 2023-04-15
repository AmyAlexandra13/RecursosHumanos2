using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad



    //idDetalleVenta INT primary key identity,
//idVenta   int References VENTA(idVenta),
//idProducto int References PRODUCTO(idProducto),
//Cantidad int,
// decimal (10,2 )
{
    public class Detalle_Venta
    {


        public int idDetalleVenta { get; set; }

        public int idVenta { get; set;}


        public Producto oProducto { get; set; }


        public int Cantidad { get; set; }

        public decimal Total { get; set; }


        public string idTrasaccion { get; set; }

    }
}
