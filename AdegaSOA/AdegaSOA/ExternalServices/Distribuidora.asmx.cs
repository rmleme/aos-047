using System.Web.Services;

namespace AdegaSOA.ExternalServices
{
    /// <summary>
    /// Summary description for Distribuidora
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa/ext")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Distribuidora : WebService
    {
        [WebMethod]
        public bool ProcessarReposicao(string xmlReposicao)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de um serviço externo
            System.Diagnostics.Debug.WriteLine(xmlReposicao);
            return true;
        }
    }
}