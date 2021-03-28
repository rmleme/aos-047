using System.Web.Services;
using AdegaSOA.Entities;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Usuario
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Usuario : WebService
    {
        private UsuarioPJ usuarioPJ = new UsuarioPJ();

        [WebMethod]
        public void CadastrarCliente(string cnpj, string senha)
        {
            this.usuarioPJ.CadastrarUsuarioPJ(cnpj, senha);
        }
    }
}