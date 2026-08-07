using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class CountryRegionLN : ICountryRegionLN
    {
        private readonly ICountryRegionAD gObjRegionesAD = new CountryRegionAD();

        public List<CountryRegion> obtenerRegiones()
        {
            return gObjRegionesAD.obtenerRegiones();
        }

        public CountryRegion obtenerRegion(string pIdRegion)
        {
            return gObjRegionesAD.obtenerRegion(pIdRegion);
        }

        public bool insRegion(CountryRegion pRegion)
        {
            return gObjRegionesAD.insRegion(pRegion);
        }


        public bool modRegion(CountryRegion pRegion)
        {
            return gObjRegionesAD.modRegion(pRegion);
        }

        public bool delRegion(CountryRegion pRegion)
        {
            return gObjRegionesAD.delRegion(pRegion);
        }
    }
}
