using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<UsuarioCLS> oLista = new List<UsuarioCLS>();
            oLista = new UsuariosBL().Listar();
            return Json(new { data= oLista },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(UsuarioCLS objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdUsuario == 0)
            {
                resultado = new UsuariosBL().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new UsuariosBL().Editar (objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje} , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new UsuariosBL().Eliminar(id, out mensaje);
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}