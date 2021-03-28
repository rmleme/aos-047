using System;
using System.Web.Services;

namespace AdegaSOA.ExternalServices
{
    /// <summary>
    /// Summary description for Serasa
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa/ext")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Serasa : WebService
    {
        [WebMethod]
        public bool Consultar(string cartaoId)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de um serviço externo
            Random random = new Random(DateTime.Now.Millisecond);
            return random.NextDouble() >= 0.25;
        }

        [WebMethod]
        public bool ConsultarPJ(string cnpj)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de um serviço externo
            Random random = new Random(DateTime.Now.Millisecond);
            return random.NextDouble() >= 0.25;
        }
    }
}
