using AccesoDatos.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface ICountryRegionLN
    {
        List<CountryRegion> obtenerRegiones();
        CountryRegion obtenerRegion(string pIdRegion);
        bool insRegion(CountryRegion pRegion);
        bool modRegion(CountryRegion pRegion);
        bool delRegion(CountryRegion pRegion);
    }
}
