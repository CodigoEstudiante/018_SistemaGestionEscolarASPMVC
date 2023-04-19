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
    public class CD_Currricula
    {
        public static List<Curricula> Listar(int IdNivel, int IdGradoSeccion, int IdCurso, int IdDocente)
        {
            
            List<Curricula> rptListaCurricula = new List<Curricula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerCurricula", oConexion);
                cmd.Parameters.AddWithValue("IdNivel", IdNivel);
                cmd.Parameters.AddWithValue("IdGradoSeccion", IdGradoSeccion);
                cmd.Parameters.AddWithValue("IdCurso", IdCurso);
                cmd.Parameters.AddWithValue("IdDocente", IdDocente);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCurricula.Add(new Curricula()
                        {
                            IdCurricula = Convert.ToInt32(dr["IdCurricula"].ToString()),
                            IdDocenteNivelDetalleCurso = Convert.ToInt32(dr["IdDocenteNivelDetalleCurso"].ToString()),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                    dr.Close();

                    return rptListaCurricula;

                }
                catch (Exception ex)
                {
                    rptListaCurricula = new List<Curricula>();
                    return rptListaCurricula;
                }
            }
        }


        public static bool Eliminar(int idCurricula)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarCurricula", oConexion);
                    cmd.Parameters.AddWithValue("IdCurricula", idCurricula);
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
