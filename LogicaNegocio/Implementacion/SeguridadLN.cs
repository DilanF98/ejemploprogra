using AccesoDatos.DBContext;
using AccesoDatos.EntidadesSeguridad;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades.EntidadesSeguridad;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class SeguridadLN : ISeguridadLN
    {

        private readonly ISeguridadAD gObjSegAD;
        public static SEGContext lObjSegCnx = new SEGContext("");

        public SeguridadLN(string pCnxBD)
        {
            gObjSegAD = new SeguridadAD(lObjSegCnx, pCnxBD);
        }

        public TusrUsuario obtenerUsuario(string pLogin)
        {
            return gObjSegAD.obtenerUsuario(pLogin);
        }

        public List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin)
        {
            return gObjSegAD.obtenerPerfilesXUsuario(pLogin);
        }

    }
}
