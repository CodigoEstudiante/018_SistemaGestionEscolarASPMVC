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
    public class CD_Matricula
    {
        public static List<Matricula> Listar()
        {

            List<Matricula> rptListaMatricula = new List<Matricula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMatricula", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaMatricula.Add(new Matricula()
                        {
                            IdMatricula = Convert.ToInt32(dr["IdMatricula"].ToString()),
                            oNivelDetalle = new NivelDetalle()
                            {
                                oNivel = new Nivel() { IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()) },
                                oGradoSeccion = new GradoSeccion() { IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()) }
                            },
                            oAlumno = new Alumno()
                            {
                                IdAlumno = Convert.ToInt32(dr["IdAlumno"].ToString()),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString()
                            }
                        });
                    }
                    dr.Close();

                    return rptListaMatricula;

                }
                catch (Exception ex)
                {
                    rptListaMatricula = new List<Matricula>();
                    return rptListaMatricula;
                }
            }
        }

        public static DataTable Reporte(string codigomatricula, string situacionmatricula,string codigoalumno, string DocumentoIdentidad,
            string Nombres, string Apellidos, string periodo, string nivelacademico,string gradoseccion)
        {
            List<Alumno> rptListaAlumno = new List<Alumno>();
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlDataAdapter da = new SqlDataAdapter("usp_ReporteMatricula", oConexion);
                da.SelectCommand.Parameters.AddWithValue("CodigoMatricula", codigomatricula);
                da.SelectCommand.Parameters.AddWithValue("SituacionMatricula", situacionmatricula);
                da.SelectCommand.Parameters.AddWithValue("CodigoAlumno", codigoalumno);
                da.SelectCommand.Parameters.AddWithValue("DocumentoIdentidad", DocumentoIdentidad);
                da.SelectCommand.Parameters.AddWithValue("Nombres", Nombres);
                da.SelectCommand.Parameters.AddWithValue("Apellidos", Apellidos);
                da.SelectCommand.Parameters.AddWithValue("Periodo", periodo);
                da.SelectCommand.Parameters.AddWithValue("NivelAcademico", nivelacademico);
                da.SelectCommand.Parameters.AddWithValue("GradoSeccion", gradoseccion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }

        public static int Registrar(string xml)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarMatricula", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }
    }
}
