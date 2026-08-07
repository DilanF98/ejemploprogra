using AccesoDatos.DBContext;
using AccesoDatos.Interfaces;
using Entidades.EntidadesPropias;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AccesoDatos.Implementacion
{
    public class CountryRegionPAAD : ICountryRegionPAAD
    {
        private readonly string gCadenaCnx;

        public CountryRegionPAAD(string pCadenaCnx)
        {
            gCadenaCnx = pCadenaCnx;
        }

        public List<RegionesPA> obtenerRegionesPA()
        {
            List<RegionesPA> lObjRespuesta = new List<RegionesPA>();
            try
            {
                using (AWContext lContext = new AWContext(gCadenaCnx))
                {
                    var lCmd = lContext.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "Person.PA_recCountryRegion";
                    lCmd.CommandType = CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lDatos = lCmd.ExecuteReader();
                    while (lDatos.Read())
                    {
                        RegionesPA lDatoRegion = new RegionesPA();
                        lDatoRegion.codRegion = lDatos["CountryRegionCode"].ToString();
                        lDatoRegion.nomRegion = lDatos["Name"].ToString();
                        lDatoRegion.fecModRegion = Convert.ToDateTime(lDatos["ModifiedDate"].ToString());
                        lObjRespuesta.Add(lDatoRegion);
                    }
                    if(lCmd.Connection.State == ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }                    
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public RegionesPA obtenerRegionPA(string pIdRegion)
        {
            RegionesPA lObjRespuesta = new RegionesPA();
            try
            {
                using (AWContext lContext = new AWContext(gCadenaCnx))
                {
                    var lCmd = lContext.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "Person.PA_recCountryRegionXId";
                    lCmd.CommandType = CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@CountryRegionCode", pIdRegion));
                    lCmd.Connection.Open();
                    var lDatos = lCmd.ExecuteReader();
                    while (lDatos.Read())
                    {
                        lObjRespuesta.codRegion = lDatos["CountryRegionCode"].ToString();
                        lObjRespuesta.nomRegion = lDatos["Name"].ToString();
                        lObjRespuesta.fecModRegion = Convert.ToDateTime(lDatos["ModifiedDate"].ToString());                        
                    }
                    if (lCmd.Connection.State == ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool insRegionPA(RegionesPA pRegion)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AWContext lContext = new AWContext(gCadenaCnx))
                {
                    var lCmd = lContext.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "Person.PA_insCountryRegion";
                    lCmd.CommandType = CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@CountryRegionCode", pRegion.codRegion));
                    lCmd.Parameters.Add(new SqlParameter("@Name", pRegion.nomRegion));
                    lCmd.Parameters.Add(new SqlParameter("@ModifiedDate", pRegion.fecModRegion));
                    lCmd.Connection.Open();
                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }                                      
                    if (lCmd.Connection.State == ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modRegionPA(RegionesPA pRegion)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AWContext lContext = new AWContext(gCadenaCnx))
                {
                    var lCmd = lContext.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "Person.PA_modCountryRegion";
                    lCmd.CommandType = CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@CountryRegionCode", pRegion.codRegion));
                    lCmd.Parameters.Add(new SqlParameter("@Name", pRegion.nomRegion));
                    lCmd.Parameters.Add(new SqlParameter("@ModifiedDate", pRegion.fecModRegion));
                    lCmd.Connection.Open();
                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delRegionPA(RegionesPA pRegion)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AWContext lContext = new AWContext(gCadenaCnx))
                {
                    var lCmd = lContext.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "Person.PA_delCountryRegion";
                    lCmd.CommandType = CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@CountryRegionCode", pRegion.codRegion));
                    lCmd.Connection.Open();
                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }


    }
}
