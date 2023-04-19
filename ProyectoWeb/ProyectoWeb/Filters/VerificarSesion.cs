using ProyectoWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        private int? IdUsuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try {

                

                if (HttpContext.Current.Session["IdUsuario"] != null)
                    IdUsuario = (int)HttpContext.Current.Session["IdUsuario"];
                else
                    IdUsuario = null;

                if (IdUsuario == null) {
                    if (filterContext.Controller is LoginController == false) {
                        filterContext.HttpContext.Response.Redirect("/Login/Index");
                    }
                }
            }
            catch (Exception ex) {

                filterContext.Result = new RedirectResult("/Login/Index");
            }

            base.OnActionExecuting(filterContext);
        }


    }
}