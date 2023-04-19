using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public static int LoginUsuario(string Usuario , string Clave)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_LoginUsuario", oConexion);
                    cmd.Parameters.AddWithValue("Usuario", Usuario);
                    cmd.Parameters.AddWithValue("Clave", Clave);
                    cmd.Parameters.Add("IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }

            }

            return respuesta;

        }



        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> rptListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaUsuario.Add(new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            LoginUsuario = dr["LoginUsuario"].ToString(),
                            Clave = dr["LoginClave"].ToString(),
                            IdRol = Convert.ToInt32(dr["IdRol"].ToString()),
                            oRol = new Rol() { Descripcion = dr["DescripcionRol"].ToString() },
                            Activo = Convert.ToBoolean(dr["Activo"]),
                            DescripcionReferencia = dr["DescripcionReferencia"].ToString()
                        });
                    }
                    dr.Close();

                    return rptListaUsuario;

                }catch(Exception ex)
                {
                    rptListaUsuario = null;
                    return rptListaUsuario;
                }
            }
        }


        public static bool RegistrarUsuario(Usuario oUsuario)
        {

            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarUsuario", oConexion);
                    cmd.Parameters.AddWithValue("Nombres", oUsuario.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oUsuario.Apellidos);
                    cmd.Parameters.AddWithValue("IdRol", oUsuario.IdRol);
                    cmd.Parameters.AddWithValue("Usuario", oUsuario.LoginUsuario);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("DescripcionReferencia", oUsuario.DescripcionReferencia);
                    cmd.Parameters.AddWithValue("IdReferencia", oUsuario.IdReferencia);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public static bool ModificarUsuario(Usuario oUsuario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarUsuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombres", oUsuario.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oUsuario.Apellidos);
                    cmd.Parameters.AddWithValue("IdRol", oUsuario.IdRol);
                    cmd.Parameters.AddWithValue("Usuario", oUsuario.LoginUsuario);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("DescripcionReferencia", oUsuario.DescripcionReferencia);
                    cmd.Parameters.AddWithValue("IdReferencia", oUsuario.IdReferencia);
                    cmd.Parameters.AddWithValue("Activo", oUsuario.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }

        public static bool EliminarUsuario(int IdUsuario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarUsuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }


        public static Usuario ObtenerDetalleUsuario(int IdUsuario)
        {
            Usuario rptUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerDetalleUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if(doc.Element("Usuario") != null)
                            {
                                rptUsuario = (from dato in doc.Elements("Usuario")
                                              select new Usuario()
                                              {
                                                  IdUsuario = int.Parse(dato.Element("IdUsuario").Value),
                                                  Nombres = dato.Element("Nombres").Value,
                                                  Apellidos = dato.Element("Apellidos").Value,
                                                  DescripcionReferencia = dato.Element("DescripcionReferencia").Value,
                                                  IdReferencia = int.Parse(dato.Element("IdReferencia").Value)

                                              }).FirstOrDefault();
                                rptUsuario.oRol = doc.Element("Usuario").Elements("DetalleRol") == null ? new Rol() : (from dato in doc.Element("Usuario").Elements("DetalleRol")
                                                   select new Rol()
                                                   {
                                                       Descripcion = dato.Element("Descripcion").Value
                                                   }).FirstOrDefault();
                                rptUsuario.oListaMenu = doc.Element("Usuario").Element("DetalleMenu") == null ? new List<Menu>() : (from menu in doc.Element("Usuario").Element("DetalleMenu").Elements("Menu")
                                                         select new Menu()
                                                         {
                                                             Nombre = menu.Element("NombreMenu").Value,
                                                             Icono = menu.Element("Icono").Value,
                                                             oSubMenu = (from submenu in menu.Element("DetalleSubMenu").Elements("SubMenu")
                                                                         select new SubMenu() {
                                                                             Nombre = submenu.Element("NombreSubMenu").Value,
                                                                             NombreFormulario = submenu.Element("NombreFormulario").Value,
                                                                             Accion = submenu.Element("Accion").Value,
                                                                             Activo = (submenu.Element("Activo").Value.ToString() == "1" ? true : false),

                                                                         }).ToList()

                                                         }).ToList();
                            }
                            else
                            {
                                rptUsuario = null;
                            }
                        }

                        dr.Close();

                    }

                    return rptUsuario;
                }
                catch (Exception ex)
                {
                    rptUsuario = null;
                    return rptUsuario;
                }
            }
        }
    }
}
