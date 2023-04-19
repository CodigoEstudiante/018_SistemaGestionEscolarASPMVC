using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Listar()
        {

            List<Usuario> oListaUsuario = CD_Usuario.ObtenerUsuarios();
            return Json(new { data = oListaUsuario }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Obtener(int idusuario = 0)
        {
            Usuario oUsuario = CD_Usuario.ObtenerUsuarios().Where(x => x.IdUsuario == idusuario).FirstOrDefault();

            return Json(oUsuario, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Usuario oUsuario)
        {
            bool respuesta = false;

            if (oUsuario.IdUsuario == 0)
            {
                respuesta = CD_Usuario.RegistrarUsuario(oUsuario);
            }
            else
            {
                respuesta = CD_Usuario.ModificarUsuario(oUsuario);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idusuario = 0)
        {
            bool respuesta = CD_Usuario.EliminarUsuario(idusuario);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}