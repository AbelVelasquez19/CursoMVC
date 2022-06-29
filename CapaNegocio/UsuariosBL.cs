using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuariosBL
    {
        private UsuarioDAL objCapaDatos = new UsuarioDAL();

        public List<UsuarioCLS> Listar()
        {
            return objCapaDatos.listar();
        }

        public int Registrar(UsuarioCLS obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if(string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres)){
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos)){
                Mensaje = "El apellido del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = RecursosBL.GenerarClave();
                string asunto = "Creacion de cuenta";
                string mensaje_correo = "<h3 style='background:red;color;#fff'>Su cuenta fue creada correctamente</h3></br><p>Su contrase para acceder es : !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!",clave);
                bool respuesta = RecursosBL.EnviarCorreo(obj.Correo,asunto,mensaje_correo);
                if (respuesta)
                {
                    obj.Clave = RecursosBL.ConvertirSha256(clave);
                    return objCapaDatos.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;
                }
              
            }
            else
            {
                return 0;
            }
            
        }

        public bool  Editar(UsuarioCLS obj, out string Mensaje)
        {
            Mensaje = String.Empty;
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellidos del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDatos.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
                
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDatos.Eliminar(id, out Mensaje);
        }
    }
}
