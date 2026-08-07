using Entidades.EntidadesPropias;

namespace LogicaNegocio.Interfaces
{
    public interface ICountryRegionPALN
    {
        List<RegionesPA> obtenerRegionesPA();
        RegionesPA obtenerRegionPA(string pIdRegion);
        bool insRegionPA(RegionesPA pRegion);
        bool modRegionPA(RegionesPA pRegion);
        bool delRegionPA(RegionesPA pRegion);
    }
}
