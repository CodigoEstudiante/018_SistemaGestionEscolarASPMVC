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
    public class CD_Periodo
    {
        public static List<Periodo> Listar()
        {
            List<Periodo> rptListaPeriodo = new List<Periodo>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarPeriodo", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaPeriodo.Add(new Periodo()
                        {
                            IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString()),
                            FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaPeriodo;

                }
                catch (Exception ex)
                {
                    rptListaPeriodo = null;
                    return rptListaPeriodo;
                }
            }
        }


        public static bool Registrar(Periodo oPeriodo)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarPeriodo", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oPeriodo.Descripcion);
                    cmd.Parameters.AddWithValue("FechaInicio", oPeriodo.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oPeriodo.FechaFin);
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


        public static bool Editar(Periodo oPeriodo)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EditarPeriodo", oConexion);
                    cmd.Parameters.AddWithValue("IdPeriodo", oPeriodo.IdPeriodo);
                    cmd.Parameters.AddWithValue("Descripcion", oPeriodo.Descripcion);
                    cmd.Parameters.AddWithValue("FechaInicio", oPeriodo.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", oPeriodo.FechaFin);
                    cmd.Parameters.AddWithValue("Activo", oPeriodo.Activo);
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

        public static bool Eliminar(int idPeriodo)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarPeriodo", oConexion);
                    cmd.Parameters.AddWithValue("IdPeriodo", idPeriodo);
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
