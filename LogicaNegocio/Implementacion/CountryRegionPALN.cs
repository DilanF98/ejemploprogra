using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades.EntidadesPropias;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class CountryRegionPALN : ICountryRegionPALN
    {
        private readonly ICountryRegionPAAD gObjRegionesPAAD;

        public CountryRegionPALN(string pCadenaCnx)
        {
            gObjRegionesPAAD = new CountryRegionPAAD(pCadenaCnx);
        }

        public List<RegionesPA> obtenerRegionesPA()
        {
            return gObjRegionesPAAD.obtenerRegionesPA();
        }

        public RegionesPA obtenerRegionPA(string pIdRegion)
        {
            return gObjRegionesPAAD.obtenerRegionPA(pIdRegion);
        }

        public bool insRegionPA(RegionesPA pRegion)
        {
            return gObjRegionesPAAD.insRegionPA(pRegion);
        }

        public bool modRegionPA(RegionesPA pRegion)
        {
            return gObjRegionesPAAD.modRegionPA(pRegion);
        }

        public bool delRegionPA(RegionesPA pRegion)
        {
            return gObjRegionesPAAD.delRegionPA(pRegion);
        }

    }
}
