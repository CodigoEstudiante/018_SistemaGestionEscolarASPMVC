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
    public class CD_NivelDetalle
    {
        public static List<NivelDetalle> Listar()
        {
            List<NivelDetalle> rptListaNivelDetalle = new List<NivelDetalle>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ListarNivelDetalle", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaNivelDetalle.Add(new NivelDetalle()
                        {
                            IdNivelDetalle = Convert.ToInt32(dr["IdNivelDetalle"].ToString()),
                            oNivel = new Nivel() {
                                IdNivel = Convert.ToInt32(dr["IdNivel"].ToString()),
                                DescripcionNivel = dr["DescripcionNivel"].ToString(),
                                DescripcionTurno = dr["DescripcionTurno"].ToString()
                            },
                            oGradoSeccion = new GradoSeccion() {
                                IdGradoSeccion = Convert.ToInt32(dr["IdGradoSeccion"].ToString()),
                                DescripcionGrado = dr["DescripcionGrado"].ToString(),
                                DescripcionSeccion = dr["DescripcionSeccion"].ToString()
                            },
                            TotalVacantes = Convert.ToInt32(dr["TotalVacantes"].ToString()),
                            VacantesDisponibles = Convert.ToInt32(dr["VacantesDisponibles"].ToString()),
                            VacantesOcupadas = Convert.ToInt32(dr["VacantesOcupadas"].ToString()),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaNivelDetalle;

                }
                catch (Exception ex)
                {
                    rptListaNivelDetalle = null;
                    return rptListaNivelDetalle;
                }
            }
        }


        public static bool Registrar(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarNivelDetalle", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
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

        public static bool RegistrarVacantes(string xml)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVacantes", oConexion);
                    cmd.Parameters.Add("xml", SqlDbType.Xml).Value = xml;
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
