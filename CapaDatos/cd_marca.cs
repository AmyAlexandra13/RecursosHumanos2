using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class cd_marca
    {

        public List<Marca> Listar()
        {

            List<Marca> Lista = new List<Marca>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    String query = "SELECT idMarca, Descripcion, Activo FROM MARCA ";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            Lista.Add(new Marca()
                            {
                                idMarca = Convert.ToInt32(dr["idMarca"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"])



                            });



                        }
                    }
                }


            }
            catch
            {

                Lista = new List<Marca>();
            }

            return Lista;
        }



        public int Resgistrar(Marca obj, out string Mensaje)
        {


            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconnection = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_RegistararMarca", oconnection);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resulatado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;



                    oconnection.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resulatado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {


                idautogenerado = 0;
                Mensaje = ex.Message;

            }
            return idautogenerado;

        }




        public bool Editar(Marca obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;


            try
            {



                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarMarcas", oconexion);
                    cmd.Parameters.AddWithValue("idMarca", obj.idMarca);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resulatado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    resultado = Convert.ToBoolean(cmd.Parameters["Resulatado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                resultado = false;
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
                    SqlCommand cmd = new SqlCommand("delete top (1) from MARCA WHERE idMarca = @idMarca", oconexion);
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
