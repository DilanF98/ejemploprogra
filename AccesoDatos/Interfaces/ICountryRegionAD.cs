using AccesoDatos.Entidades;

namespace AccesoDatos.Interfaces
{
    public interface ICountryRegionAD
    {
        List<CountryRegion> obtenerRegiones();
        CountryRegion obtenerRegion(string pIdRegion);
        bool insRegion(CountryRegion pRegion);
        bool modRegion(CountryRegion pRegion);
        bool delRegion(CountryRegion pRegion);
    }
}
