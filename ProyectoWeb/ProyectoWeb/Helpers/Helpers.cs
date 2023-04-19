using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Helpers
{
    public static class Helpers 
    {
        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper) {

            StringBuilder sb = new StringBuilder();

            if (HttpContext.Current.Session["IdUsuario"] != null) {

                int IdUsuario = (int)HttpContext.Current.Session["IdUsuario"];

                Usuario rptUsuario = CD_Usuario.ObtenerDetalleUsuario(IdUsuario);


                foreach (Menu item in rptUsuario.oListaMenu)
                {
                    sb.AppendLine("<li class='nav-item dropdown'>");
                    sb.AppendLine("<a class='nav-link dropdown-toggle' href='#' data-toggle='dropdown'>" + item.Nombre + "</a>");

                    sb.AppendLine("<div class='dropdown-menu'>");
                    foreach (SubMenu subitem in item.oSubMenu)
                    {
                        sb.AppendLine("<a class='dropdown-item' href='/" + subitem.NombreFormulario + "/" + subitem.Accion + "'>" + subitem.Nombre + "</a>");

                    }
                    sb.AppendLine("</div>");

                    sb.AppendLine("</li>");
                }


            }


            return new MvcHtmlString(sb.ToString());
        }

    }
}