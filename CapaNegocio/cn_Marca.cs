using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public  class cn_Marca
    {
        private cd_marca objCapaDato = new cd_marca();
        public List<Marca> Listar() { return objCapaDato.Listar(); }



        public int Resgistrar(Marca obj, out string Mensaje)
        {

            Mensaje = String.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripción de la marca no puede estar vacia)";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Resgistrar(obj, out Mensaje);


            }
            else
            {
                return 0;
            }

        }


        public bool Editar(Marca obj, out string Mensaje)
        {

            Mensaje = string.Empty;



            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripción de la categoria  no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }


        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);


        }


    }
}
