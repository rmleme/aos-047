using System.Collections.Generic;
using System.Web.Services;
using AdegaSOA.Entities;

namespace AdegaSOA.Services
{
    /// <summary>
    /// Summary description for Estoque
    /// </summary>
    [WebService(Namespace = "http://ipt.br/soa")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Estoque : WebService
    {
        private AdegaSOA.Entities.Estoque estoque = new AdegaSOA.Entities.Estoque();

        [WebMethod]
        public List<Vinho> ListarEstoque()
        {
            return this.estoque.GetEstoque();
        }

        [WebMethod]
        public List<Reposicao> VerificarEstoque()
        {
            return this.estoque.VerificarEstoque();
        }

        [WebMethod]
        public List<Reposicao> SolicitarReposicao(List<Reposicao> listaReposicao)
        {
            // A lista de reposicao já é retornada pela operação VerificarReposicao(),
            // retorna a lista de reposição apenas se ela for autorizada
            return this.estoque.AutorizarReposicao(listaReposicao) ? listaReposicao : null;
        }

        [WebMethod]
        public void EnviarArquivoXml(List<Reposicao> listaReposicao)
        {
            external3.Distribuidora distribuidoraWS = new external3.Distribuidora();
            distribuidoraWS.ProcessarReposicao(this.estoque.GerarXml(listaReposicao));
        }

        [WebMethod]
        public bool VerificarDataEntrega()
        {
            return this.estoque.VerificarDataEntrega();
        }

        [WebMethod]
        public void AtualizarStatusPedido(AdegaSOA.Entities.Pedido pedido)
        {
            this.estoque.AtualizarStatusPedido(pedido);
        }

        [WebMethod]
        public List<Reposicao> VerificarReposicao()
        {
            return this.estoque.VerificarReposicao();
        }
    }
}