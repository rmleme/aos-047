using System.Web.Services;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Seguranca
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Seguranca : WebService
    {
        private AdegaSOA.Entities.UsuarioPJ usuario = new AdegaSOA.Entities.UsuarioPJ();

        [WebMethod]
        public bool VerificarIdUsuario(string cnpj, string senha)
        {
            return this.usuario.VerificarIdUsuario(cnpj, senha);
        }
    }
}