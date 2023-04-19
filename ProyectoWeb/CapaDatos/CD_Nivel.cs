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
    public class CD_Nivel
    {

        public static List<Nivel> Listar()
        {
            List<Nivel> rptListaNivel = new List<Nivel>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarNivel", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaNivel.Add(new Nivel()
                        {
                            IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()),
                            oPeriodo = new Periodo()
                            {
                                IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString()),
                                Descripcion = dr["DescripcionPeriodo"].ToString(),
                            },
                            DescripcionNivel = dr["DescripcionNivel"].ToString(),
                            DescripcionTurno = dr["DescripcionTurno"].ToString(),
                            HoraInicio = Convert.ToDateTime(dr["HoraInicio"].ToString()),
                            HoraFin = Convert.ToDateTime(dr["HoraFin"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaNivel;

                }
                catch (Exception ex)
                {
                    rptListaNivel = null;
                    return rptListaNivel;
                }
            }
        }


        public static bool Registrar(Nivel oNivel)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarNivel", oConexion);
                    cmd.Parameters.AddWithValue("IdPeriodo", oNivel.oPeriodo.IdPeriodo);
                    cmd.Parameters.AddWithValue("DescripcionNivel", oNivel.DescripcionNivel);
                    cmd.Parameters.AddWithValue("DescripcionTurno", oNivel.DescripcionTurno);
                    cmd.Parameters.AddWithValue("HoraInicio", oNivel.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oNivel.HoraFin);
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


        public static bool Editar(Nivel oNivel)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarNivel", oConexion);
                    cmd.Parameters.AddWithValue("IdNivel", oNivel.IdNivel);
                    cmd.Parameters.AddWithValue("IdPeriodo", oNivel.oPeriodo.IdPeriodo);
                    cmd.Parameters.AddWithValue("DescripcionNivel", oNivel.DescripcionNivel);
                    cmd.Parameters.AddWithValue("DescripcionTurno", oNivel.DescripcionTurno);
                    cmd.Parameters.AddWithValue("HoraInicio", oNivel.HoraInicio);
                    cmd.Parameters.AddWithValue("HoraFin", oNivel.HoraFin);
                    cmd.Parameters.AddWithValue("Activo", oNivel.Activo);
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

        public static bool Eliminar(int idNivel)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarNivel", oConexion);
                    cmd.Parameters.AddWithValue("IdNivel", idNivel);
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
