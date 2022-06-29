﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//para enviar referencias para correo
using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class RecursosBL
    {
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }

        //encriptacion de texto en SHA256
        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            //usuar la referencia de "SYSTEM.SECURITY.CRYPTOGRAPHY"
            using(SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] resul = hash.ComputeHash(enc.GetBytes(texto));
                foreach(byte b in resul)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From=new MailAddress("abel.velasquez1997@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("abel.velasquez1997@gmail.com", "gtsfvauirdahkktd"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };
                smtp.Send(mail);
                resultado = true;
            }
            catch(Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }

        public static string ConvertirBase64(string ruta, out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = true;
            try
            {
                byte[] bytes=File.ReadAllBytes(ruta);
                textoBase64=Convert.ToBase64String(bytes);
            }
            catch (Exception ex) {
                conversion = false;
            }

            return textoBase64;
        }
    }
}
