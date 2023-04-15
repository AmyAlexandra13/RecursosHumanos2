using System;
using System.Collections.Generic;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cd_Usuarios
    {

        public List<Usuario> Listar(){

            List<Usuario> Lista= new List<Usuario>();
           

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    
                    String query = "Select   IdUsuario , Nombres, Apellidos, Correo, Clave, Restablecer, Activo, Telefono , Numero_Cuenta, Numero_de_doc, Salario From USUARIO"; 
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                                      

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while(dr.Read()){

                            Lista.Add(
                                
                                
                                new Usuario()
                                {
                                    idUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombre = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Restablecer = Convert.ToBoolean(dr["Restablecer"]) ,
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    Numero_de_doc = dr["Numero_de_doc"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Numero_Cuenta = dr["Numero_Cuenta"].ToString(),
                                    Salario = dr["Salario"].ToString()
                                }
                                
                                
                                );
                        }
                    }
                }


            }
            catch (NullReferenceException  ex)
            {
        
               Console.WriteLine(ex.ToString());


            }
            catch(SqlException EXSQL)
            {
                Console.WriteLine(EXSQL.ToString());
            }

            return Lista;
        }





        public int Resgistrar(Usuario obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;

            try { 
                
                using(SqlConnection oconnection= new SqlConnection(Conexion.cn)) { 

                    SqlCommand cmd = new SqlCommand("sp_Resgistrarusauario", oconnection);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    //cmd.Parameters.AddWithValue("Reestablecer", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resulatado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("Numero_de_doc", obj.Numero_de_doc);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);   
                    cmd.Parameters.AddWithValue("Numero_Cuenta", obj.Numero_Cuenta);
                    cmd.Parameters.AddWithValue("Salario", obj.Salario);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconnection.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resulatado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            } catch(Exception ex)
            {


                idautogenerado = 0;
                Mensaje = ex.Message;

               

            }
            return idautogenerado;

        }

        public bool Editar(Usuario obj, out string Mensaje) {

            bool resultado = false;
            Mensaje = string.Empty;


            try { 

                using(SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario2", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.idUsuario);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resulatado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("Numero_de_doc", obj.Numero_de_doc);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Numero_Cuenta", obj.Numero_Cuenta);
                    cmd.Parameters.AddWithValue("Salario", obj.Salario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    resultado= Convert.ToBoolean(cmd.Parameters["Resulatado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch(Exception ex){
            
            resultado=false;
                Mensaje = ex.Message;
            
            
            }

            return resultado;
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;



            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Delete top (1) from USUARIO WHERE idUsuario = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {


                resultado = false;
                Mensaje = ex.Message;

            }



            return resultado;
        }




    }
}