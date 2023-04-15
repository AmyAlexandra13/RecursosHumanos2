using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;


namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }


        public ActionResult Marca()
        {
            return View();
        }


        public ActionResult Producto()
        {
            return View();
        }

//     categoria 
        #region Categoria 

        [HttpGet]
        public JsonResult ListarCategoria()
        {


            List<Categoria> Olista = new List<Categoria>();

            Olista = new CN_Categoria().Listar();


            return Json(new { data = Olista }, JsonRequestBehavior.AllowGet);


        }





        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {


            object resultado;
            string Mensaje = string.Empty;

            if (objeto.idCategoria == 0)
            {

                resultado = new CN_Categoria().Resgistrar(objeto, out Mensaje);
            }
            else
            {

                resultado = new CN_Categoria().Editar(objeto, out Mensaje);


            }
            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {

            bool respuesta = false;

            String Mensaje = string.Empty;

            respuesta = new CN_Categoria().Eliminar(id, out Mensaje);


            return Json(new { resultado = respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }




        #endregion


        // marca ///
        #region Marca 

        [HttpGet]
    public JsonResult ListarMarca()
    {

        List<Marca> Olista = new List<Marca>();
        Olista = new cn_Marca().Listar();
        return Json(new { data = Olista }, JsonRequestBehavior.AllowGet);

    }



    [HttpPost]
    public JsonResult GuardarMarca(Marca objeto)
    {

        object resultado;
        string Mensaje = string.Empty;

        if (objeto.idMarca == 0)
        {

            resultado = new cn_Marca().Resgistrar(objeto, out Mensaje);
        }
        else
        {

            resultado = new cn_Marca().Editar(objeto, out Mensaje);


        }
        return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

    }





    [HttpPost]
    public JsonResult EliminarMarca(int id)
    {

        bool respuesta = false;

        String Mensaje = string.Empty;

        respuesta = new CN_Categoria().Eliminar(id, out Mensaje);


        return Json(new { resultado = respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

    }
        #endregion


    }

}