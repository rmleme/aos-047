using System.Collections.Generic;
using System.Web.Services;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Pedido
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Pedido : WebService
    {
        private AdegaSOA.Entities.Pedido pedido = new AdegaSOA.Entities.Pedido();

        [WebMethod]
        public List<AdegaSOA.Entities.Pedido> ListarPedidos()
        {
            return this.pedido.ListarPedidos();
        }

        [WebMethod]
        public AdegaSOA.Entities.Pedido GerarOrderId(AdegaSOA.Entities.Venda venda)
        {
            return this.pedido.GerarOrderId(venda);
        }

        [WebMethod]
        public AdegaSOA.Entities.Pedido ConsultarPedido(int pedidoId)
        {
            return this.pedido.ConsultarPedido(pedidoId);
        }

        [WebMethod]
        public AdegaSOA.Entities.Pedido CancelarPedido(AdegaSOA.Entities.Pedido pedido)
        {
            this.pedido.CancelarPedido(pedido.pedidoId);
            return pedido;
        }
    }
}