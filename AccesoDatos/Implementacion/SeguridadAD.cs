using AccesoDatos.DBContext;
using AccesoDatos.EntidadesSeguridad;
using AccesoDatos.Interfaces;
using Entidades.EntidadesSeguridad;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Implementacion
{
    public class SeguridadAD : ISeguridadAD
    {

        private readonly string gCnxBD;
        private SEGContext gObjCnxSeg;

        public SeguridadAD(SEGContext pObjCnxSeg, string pCnxBD)
        {
            gObjCnxSeg = pObjCnxSeg;
            gCnxBD = pCnxBD;            
        }

        public TusrUsuario obtenerUsuario(string pLogin)
        {
            try
            {
                return gObjCnxSeg.TusrUsuarios.Find(pLogin);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        public List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin)
        {
            List<TusrPerfilesXUsuario> lObjRespuesta = new List<TusrPerfilesXUsuario>();
            try
            {
                using (SEGContext lObjCnn = new SEGContext(gCnxBD))
                {
                    var lCmd = lObjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "PA_recPerfilesXUsuario";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@TC_Usuario", pLogin));
                    lCmd.Connection.Open();
                    var lDatos = lCmd.ExecuteReader();
                    while (lDatos.Read())
                    {
                        TusrPerfilesXUsuario lDatoUsuario = new TusrPerfilesXUsuario();
                        lDatoUsuario.TnPerfil = Convert.ToInt32(lDatos["TN_Perfil"].ToString());
                        lDatoUsuario.TcUsuario = lDatos["TC_Usuario"].ToString();
                        lObjRespuesta.Add(lDatoUsuario);
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
