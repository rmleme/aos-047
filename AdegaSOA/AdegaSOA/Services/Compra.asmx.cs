using System.Web.Services;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Compra
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Compra : WebService
    {
        public const int QUANTIDADE_MINIMA_PJ = 10;
        public const double VALOR_MINIMO_PJ = 300.00;

        [WebMethod]
        public bool ChecarLimitesMinimos(int quantidade, double valor)
        {
            return quantidade >= QUANTIDADE_MINIMA_PJ && valor >= VALOR_MINIMO_PJ;
        }
    }
}