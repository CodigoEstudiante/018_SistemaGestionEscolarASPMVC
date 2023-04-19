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
    public class CD_DocenteCurso
    {
        public static List<DocenteCurso> Listar()
        {
            List<DocenteCurso> rptListaDocenteCurso = new List<DocenteCurso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarDocenteCurso", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaDocenteCurso.Add(new DocenteCurso()
                        {
                            IdDocenteCurso = Convert.ToInt32(dr["IdDocenteCurso"].ToString()),
                            oNivelDetalleCurso = new NivelDetalleCurso()
                            {
                                oNivel = new Nivel() {
                                    IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()),
                                    DescripcionNivel = dr["DescripcionNivel"].ToString()
                                },
                                oGradoSeccion = new GradoSeccion() {
                                    IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()),
                                    DescripcionGrado = dr["DescripcionGrado"].ToString(),
                                    DescripcionSeccion = dr["DescripcionSeccion"].ToString()

                                },
                                oCurso = new Curso() {
                                    IdCurso = Convert.ToInt32(dr["IdCurso"].ToString()),
                                    Descripcion = dr["DescripcionCurso"].ToString()
                                }
                                
                            },
                            oDocente = new Docente() {
                                IdDocente = Convert.ToInt32(dr["IdDocente"].ToString()),
                                Codigo = dr["CodigoDocente"].ToString(),
                                Nombres = dr["NombreDocente"].ToString(),
                                Apellidos = dr["ApellidoDocente"].ToString()
                            },
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaDocenteCurso;

                }
                catch (Exception ex)
                {
                    rptListaDocenteCurso = null;
                    return rptListaDocenteCurso;
                }
            }
        }


        public static bool Registrar(DocenteCurso oDocenteCurso)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarDocenteCurso", oConexion);
                    cmd.Parameters.AddWithValue("IdNivel", oDocenteCurso.oNivelDetalleCurso.oNivel.IdNivel);
                    cmd.Parameters.AddWithValue("IdGradoSeccion", oDocenteCurso.oNivelDetalleCurso.oGradoSeccion.IdGradoSeccion);
                    cmd.Parameters.AddWithValue("IdCurso", oDocenteCurso.oNivelDetalleCurso.oCurso.IdCurso);
                    cmd.Parameters.AddWithValue("IdDocente", oDocenteCurso.oDocente.IdDocente);
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

        public static bool Eliminar(int idDocenteCurso)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarDocenteCurso", oConexion);
                    cmd.Parameters.AddWithValue("IdDocenteCurso", idDocenteCurso);
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
