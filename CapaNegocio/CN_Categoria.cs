using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;



namespace CapaNegocio
{
    public class CN_Categoria
    {


        private CD_CATEGORIA objCapaDato = new CD_CATEGORIA();
        public List<Categoria> Listar() { return objCapaDato.Listar(); }



        public int Resgistrar(Categoria obj, out string Mensaje)
        {

            Mensaje = String.Empty;


            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripción de la categoria  no puede estar vacio)";
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


        public bool Editar(Categoria obj, out string Mensaje)
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
