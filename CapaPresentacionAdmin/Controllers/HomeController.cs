using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {


        
            public ActionResult Index()

        {

            //IWebDriver DRIVER = new ChromeDriver();

            // DRIVER.Url = "https://localhost:44310/";


            //IWebElement d0 = DRIVER.FindElement(By.XPath("//*[@id='sidenavAccordion']/div[1]/div/a[2]"));
            //d0.Click();
            //Boolean t = d0.Displayed;


            //IWebElement d1 = DRIVER.FindElement(By.XPath("//*[@id='ayoutSidenav_content']/main/div/div[1]/div[2]/div[1]/div/button"));
            //d1.Click();
            //Boolean s = d1.Displayed;

            //IWebElement d2 = DRIVER.FindElement(By.XPath("//*[@id='txtnombres']"));
            //d1.SendKeys("Samuel");
            //Boolean M = d1.Displayed;

            //IWebElement d3 = DRIVER.FindElement(By.XPath("//*[@id='txtapellidos']"));
            //d3.SendKeys("Roa");
            //Boolean r = d3.Displayed;


            //IWebElement d4 = DRIVER.FindElement(By.XPath("//*[@id='txtcorreo']"));
            //d4.SendKeys("Samuelroa281@gmail.com");
            //Boolean mm = d4.Displayed;

            //IWebElement d5 = DRIVER.FindElement(By.XPath("//*[@id='FormModal']/div/div/div[3]/button[2]"));
            //d5.Click();
            //Boolean mmm = d5.Displayed;
            return View();

        }







        public ActionResult Usuario ()
        {
            return View();
        
        
        }




        [HttpGet]
            public JsonResult ListarUsuarios() {


                              
            List<Usuario> Olista = new List<Usuario>();


               Olista = new Cn_Usuarios().Listar();


               return Json (new { data = Olista },JsonRequestBehavior.AllowGet);



            

            }





        [HttpPost]
        public JsonResult GuardarUsuario( Usuario objeto)
        {


            object resultado;
              string Mensaje = string.Empty;

            if ( objeto.idUsuario == 0)
            {

                resultado = new Cn_Usuarios().Resgistrar(objeto, out Mensaje); 
            }else
            {

                resultado = new Cn_Usuarios().Editar(objeto, out Mensaje);


            }
            return Json(new { resultado = resultado,  Mensaje= Mensaje }, JsonRequestBehavior.AllowGet); 

                    }




        [HttpPost]
        public JsonResult EliminarUsuario(int id){

            bool respuesta = false ;

            String Mensaje = string.Empty;

            respuesta = new Cn_Usuarios().Eliminar(id, out Mensaje);


            return Json(new { resultado =respuesta , Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }



    }


    
 


}
