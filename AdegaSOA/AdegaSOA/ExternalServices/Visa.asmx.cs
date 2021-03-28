using System;
using System.Web.Services;

namespace AdegaSOA.ExternalServices
{
    /// <summary>
    /// Summary description for Visa
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa/ext")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Visa : WebService
    {
        [WebMethod]
        public bool Creditar(string cartaoId, double valor)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de um serviço externo
            System.Diagnostics.Debug.WriteLine("Creditou R$" + valor + " no cartão " + cartaoId);
            return true;
        }

        [WebMethod]
        public bool Debitar(string cartaoId, double valor)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de um serviço externo
            Random random = new Random(DateTime.Now.Millisecond);
            if (random.NextDouble() >= 0.25)
            {
                // Tem crédito
                System.Diagnostics.Debug.WriteLine("Debitou R$" + valor + " do cartão " + cartaoId);
                return true;
            }
            else
            {
                // Não tem crédito
                return false;
            }
        }
    }
}