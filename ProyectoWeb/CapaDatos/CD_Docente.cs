using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Docente
    {
        public static List<Docente> Listar()
        {
            List<Docente> rptListaDocente = new List<Docente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarDocente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaDocente.Add(new Docente()
                        {
                            IdDocente = Convert.ToInt32(dr["IdDocente"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                            Sexo = dr["Sexo"].ToString(),
                            GradoEstudio = dr["GradoEstudio"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Email = dr["Email"].ToString(),
                            NumeroTelefono = dr["NumeroTelefono"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaDocente;

                }
                catch (Exception ex)
                {
                    rptListaDocente = null;
                    return rptListaDocente;
                }
            }
        }


        public static bool Registrar(Docente oDocente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDocente", oConexion);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oDocente.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oDocente.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDocente.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDocente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oDocente.Sexo);
                    cmd.Parameters.AddWithValue("GradoEstudio", oDocente.GradoEstudio);
                    cmd.Parameters.AddWithValue("Ciudad", oDocente.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oDocente.Direccion);
                    cmd.Parameters.AddWithValue("Email", oDocente.Email);
                    cmd.Parameters.AddWithValue("NumeroTelefono", oDocente.NumeroTelefono);
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


        public static bool Editar(Docente oDocente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarDocente", oConexion);
                    cmd.Parameters.AddWithValue("IdDocente", oDocente.IdDocente);
                    cmd.Parameters.AddWithValue("DocumentoIdentidad", oDocente.DocumentoIdentidad);
                    cmd.Parameters.AddWithValue("Nombres", oDocente.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDocente.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDocente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", oDocente.Sexo);
                    cmd.Parameters.AddWithValue("GradoEstudio", oDocente.GradoEstudio);
                    cmd.Parameters.AddWithValue("Ciudad", oDocente.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", oDocente.Direccion);
                    cmd.Parameters.AddWithValue("Email", oDocente.Email);
                    cmd.Parameters.AddWithValue("NumeroTelefono", oDocente.NumeroTelefono);
                    cmd.Parameters.AddWithValue("Activo", oDocente.Activo);
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

        public static bool Eliminar(int idDocente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDocente", oConexion);
                    cmd.Parameters.AddWithValue("IdDocente", idDocente);
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
    }
}
