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
    public class CD_GradoSeccion
    {
        public static List<GradoSeccion> Listar()
        {
            List<GradoSeccion> rptListaGradoSeccion = new List<GradoSeccion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarGradoSeccion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaGradoSeccion.Add(new GradoSeccion()
                        {
                            IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()),
                            DescripcionGrado = dr["DescripcionGrado"].ToString(),
                            DescripcionSeccion = dr["DescripcionSeccion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaGradoSeccion;

                }
                catch (Exception ex)
                {
                    rptListaGradoSeccion = null;
                    return rptListaGradoSeccion;
                }
            }
        }


        public static bool Registrar(GradoSeccion oGradoSeccion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarGradoSeccion", oConexion);
                    cmd.Parameters.AddWithValue("DescripcionGrado", oGradoSeccion.DescripcionGrado);
                    cmd.Parameters.AddWithValue("DescripcionSeccion", oGradoSeccion.DescripcionSeccion);
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


        public static bool Editar(GradoSeccion oGradoSeccion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarGradoSeccion", oConexion);
                    cmd.Parameters.AddWithValue("IdGradoSeccion", oGradoSeccion.IdGradoSeccion);
                    cmd.Parameters.AddWithValue("DescripcionGrado", oGradoSeccion.DescripcionGrado);
                    cmd.Parameters.AddWithValue("DescripcionSeccion", oGradoSeccion.DescripcionSeccion);
                    cmd.Parameters.AddWithValue("Activo", oGradoSeccion.Activo);
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

        public static bool Eliminar(int idGradoSeccion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarGradoSeccion", oConexion);
                    cmd.Parameters.AddWithValue("IdGradoSeccion", idGradoSeccion);
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
