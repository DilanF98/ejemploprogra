using Entidades.EntidadesPropias;

namespace AccesoDatos.Interfaces
{
    public interface ICountryRegionPAAD
    {
        List<RegionesPA> obtenerRegionesPA();
        RegionesPA obtenerRegionPA(string pIdRegion);
        bool insRegionPA(RegionesPA pRegion);
        bool modRegionPA(RegionesPA pRegion);
        bool delRegionPA(RegionesPA pRegion);
    }
}
