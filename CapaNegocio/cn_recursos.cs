using System;
using System.Text;
using System.Net.Mail;
using System.Net;


using System.Security.Cryptography;

namespace CapaNegocio
{
    public class cn_recursos
    {

        public static string Generarclave()
        {


            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);

            return clave;   
        }




        public static string ConvertSha(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));

            }
            return sb.ToString();


        }





        public static bool EnviarCorreo (string correo , string asunto , string mensaje)
        {
            bool resultado = false;

            try {
           
            
            MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("Samuelroa281@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje; 
                mail.IsBodyHtml = true;

       

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("Samuelroa281@gmail.com", "oncsflbbkoezvdso"),
                    Host ="smtp.gmail.com", 
                    Port = 587,
                    EnableSsl = true

                };

                smtp.Send(mail);
                resultado = true;   

            
            }
            catch (Exception e) {


                resultado = false;

            }

            return resultado;   
        }

    }
}
