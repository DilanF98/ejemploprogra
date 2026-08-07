using AccesoDatos.EntidadesSeguridad;
using Entidades.EntidadesSeguridad;

namespace AccesoDatos.Interfaces
{
    public interface ISeguridadAD
    {
        TusrUsuario obtenerUsuario(string pLogin);
        List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin);
    }
}
