using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;



namespace CapaNegocio
{
    public class Cn_Usuarios
    {


        private Cd_Usuarios objCapaDato = new Cd_Usuarios();
        public List<Usuario> Listar() { return objCapaDato.Listar(); }

        public int Resgistrar(Usuario obj, out string Mensaje) {

            Mensaje = String.Empty;


            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "Falta el nombre (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "Falta el apellido (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {

                Mensaje = "Falta el Correo (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Numero_de_doc) || string.IsNullOrWhiteSpace(obj.Numero_de_doc))
            {

                Mensaje = "Falta el Numero de documento (No puede estar vacio)";
            }


            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {

                Mensaje = "Falta el Telefono (No puede estar vacio)";
            }

            else if (string.IsNullOrEmpty(obj.Numero_Cuenta) || string.IsNullOrWhiteSpace(obj.Numero_Cuenta))
            {

                Mensaje = "Falta el Numero de cuenta (No puede estar vacio)";
            }

            else if (string.IsNullOrEmpty(obj.Salario) || string.IsNullOrWhiteSpace(obj.Salario))
            {

                Mensaje = "Falta el salario (No puede estar vacio)";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                string Clave = cn_recursos.Generarclave();

                string asunto = "Creacion de cuenta";

                string mensaje_correo = "<h3>Su cuenta fue creada correctamente</h3> </br>  <p>Su contraseña para acceder es : !Clave! </p>";

                mensaje_correo = mensaje_correo.Replace("!Clave!", Clave);


                bool respuesta = cn_recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);
                obj.Clave = cn_recursos.ConvertSha(Clave);

                return objCapaDato.Resgistrar(obj, out Mensaje);


                //if (respuesta)
                //{

                //    obj.Clave = cn_recursos.ConvertSha(Clave);

                //    return objCapaDato.Resgistrar(obj, out Mensaje);

                //}
                //else
                //{

                //    Mensaje = "No se puede enviar el correo";
                //    return 0;
                //}
            }


            else
            {

                return 0;
            }
        

            

        }


   


        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;



            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "Falta el nombre (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "Falta el apellido (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {

                Mensaje = "Falta el Correo (No puede estar vacio)";
               
            }

            else if (string.IsNullOrEmpty(obj.Numero_de_doc) || string.IsNullOrWhiteSpace(obj.Numero_de_doc))
            {

                Mensaje = "Falta el numero de documneto  (No puede estar vacio)";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {

                Mensaje = "Falta el Telefono (No puede estar vacio)";
            }

            else if (string.IsNullOrEmpty(obj.Numero_Cuenta) || string.IsNullOrWhiteSpace(obj.Numero_Cuenta))
            {

                Mensaje = "Falta el Numero de cuenta (No puede estar vacio)";
            }

            else if (string.IsNullOrEmpty(obj.Salario) || string.IsNullOrWhiteSpace(obj.Salario))
            {

                Mensaje = "Falta el salario (No puede estar vacio)";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar (obj, out Mensaje);
            }else { return false; }
     
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);

            
        }


    }



    }
