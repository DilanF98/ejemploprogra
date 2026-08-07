using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Implementacion
{
    public class CountryRegionAD : ICountryRegionAD
    {

        private AWContext gObjCnxAW = new AWContext("");

        public List<CountryRegion> obtenerRegiones()
        {
            try
            {
                return gObjCnxAW.CountryRegions.ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public CountryRegion obtenerRegion(string pIdRegion)
        {
            try
            {
                return gObjCnxAW.CountryRegions.Find(pIdRegion);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public bool insRegion(CountryRegion pRegion)
        {
            bool lRespuesta = false;
            try
            {
                var lRegExiste = gObjCnxAW.CountryRegions.Find(pRegion.CountryRegionCode);
                if(lRegExiste == null)
                {
                    gObjCnxAW.CountryRegions.Add(pRegion);
                    gObjCnxAW.SaveChanges();
                    lRespuesta = true;
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lRespuesta;
        }

        public bool modRegion(CountryRegion pRegion)
        {
            bool lRespuesta = false;
            try
            {
                var lRegExiste = gObjCnxAW.CountryRegions.Find(pRegion.CountryRegionCode);
                if (lRegExiste != null)
                {
                    gObjCnxAW.Entry(lRegExiste).CurrentValues.SetValues(pRegion);
                    gObjCnxAW.Entry(lRegExiste).State = EntityState.Modified;                    
                    gObjCnxAW.SaveChanges();
                    lRespuesta = true;
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lRespuesta;
        }

        public bool delRegion(CountryRegion pRegion)
        {
            bool lRespuesta = false;
            try
            {
                var lRegExiste = gObjCnxAW.CountryRegions.Find(pRegion.CountryRegionCode);
                if (lRegExiste != null)
                {
                    gObjCnxAW.Entry(lRegExiste).CurrentValues.SetValues(pRegion);
                    gObjCnxAW.Entry(lRegExiste).State = EntityState.Deleted;
                    gObjCnxAW.SaveChanges();
                    lRespuesta = true;
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lRespuesta;
        }

    }
}
