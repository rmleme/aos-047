using System.Web.Services;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Credito
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Credito : WebService
    {
        [WebMethod]
        public bool DebitarCartao(string cartaoId, double valor)
        {
            external2.Visa visaWS = new external2.Visa();
            return visaWS.Debitar(cartaoId, valor);
        }

        [WebMethod]
        public void CreditarCartao(string cartaoId, double valor)
        {
            external2.Visa visaWS = new external2.Visa();
            visaWS.Creditar(cartaoId, valor);
        }

        [WebMethod]
        public bool ConsultarSerasaSpc(string cartaoId)
        {
            external1.Serasa serasaWS = new external1.Serasa();
            return serasaWS.Consultar(cartaoId);
        }

        [WebMethod]
        public bool ConsultarSerasaSpcPJ(string cnpj)
        {
            external1.Serasa serasaWS = new external1.Serasa();
            return serasaWS.ConsultarPJ(cnpj);
        }
    }
}