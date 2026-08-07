using AccesoDatos.EntidadesSeguridad;
using Entidades.EntidadesSeguridad;

namespace LogicaNegocio.Interfaces
{
    public interface ISeguridadLN
    {
        TusrUsuario obtenerUsuario(string pLogin);
        List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin);
    }
}
