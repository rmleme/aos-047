using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using AdegaSOA.DAO;

namespace AdegaSOA.Entities
{
    public class Estoque
    {
        private EstoqueDao estoqueDao = new EstoqueDao();

        public List<Vinho> GetEstoque()
        {
            return this.estoqueDao.listarEstoque();
        }

        public List<Reposicao> VerificarEstoque()
        {
            return this.estoqueDao.obterReposicao();
        }

        public List<Reposicao> VerificarDemanda(List<Vinho> listaVinho)
        {
            List<Reposicao> listaReposicao = new List<Reposicao>();
            foreach (Vinho vinho in listaVinho)
            {
                int demanda = this.CalcularDemanda(vinho.vinhoId);
                if (demanda > vinho.qtdeAtual)
                {
                    Reposicao reposicao = new Reposicao();
                    reposicao.vinhoId = vinho.vinhoId;
                    reposicao.nome = vinho.nome;
                    reposicao.tipo = vinho.tipo;
                    reposicao.preco = vinho.preco;
                    reposicao.qtdeAtual = vinho.qtdeAtual;
                    reposicao.qtdeMinima = vinho.qtdeMinima;
                    reposicao.qtdeRepor = demanda;
                    listaReposicao.Add(reposicao);
                }
            }
            return listaReposicao;
        }

        // Acessar banco e obter quantidade 
        // de vinhos comprados nos últimos 15 dias
        private int CalcularDemanda(int vinhoId)
        {
            return this.estoqueDao.calcularDemanda(vinhoId, DateTime.Today.AddDays(-15));
        }

        public bool AutorizarReposicao(List<Reposicao> listaReposicao)
        {
            // Não faz nada, uma vez que é apenas uma simulação
            // de uma autorização humana
            Random random = new Random(DateTime.Now.Millisecond);
            return random.NextDouble() >= 0.25;
        }

        public string GerarXml(List<Reposicao> listaReposicao)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = new UTF8Encoding();
            settings.IndentChars = ("    ");
            StringBuilder output = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(output, settings);

            writer.WriteStartElement("r", "Reposicoes", "http://ipt.br/soa");
            foreach (Reposicao reposicao in listaReposicao)
            {
                writer.WriteStartElement("Reposicao", "http://ipt.br/soa");

                writer.WriteElementString("Nome", "http://ipt.br/soa", reposicao.nome);

                writer.WriteElementString("Tipo", "http://ipt.br/soa", reposicao.tipo.ToString());

                writer.WriteStartElement("Preco", "http://ipt.br/soa");
                writer.WriteValue(reposicao.preco);
                writer.WriteEndElement();

                writer.WriteStartElement("Quantidade", "http://ipt.br/soa");
                writer.WriteValue(reposicao.qtdeMinima * 2);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.Flush();
            writer.Close();

            output.Replace("utf-16", "utf-8");
            return output.ToString();
        }

        public bool VerificarDataEntrega()
        {
            // Retorna true após o usuário clicar em aceitar e o WS enviar a mensagem
            return true;
        }

        public void AtualizarStatusPedido(Pedido pedido)
        {
            this.estoqueDao.atualizarStatusPedido(pedido);
        }

        public List<Reposicao> VerificarReposicao()
        {
            // Obtém a lista dos vinhos cuja quantidade está abaixo da mínima
            List<Reposicao> listaReposicaoPorQtde = this.VerificarEstoque();

            // Obtém a lista dos vinhos cuja demanda está alta
            List<Reposicao> listaReposicaoPorDemanda = this.VerificarDemanda(this.GetEstoque());

            // Unifica as duas listas, evitando duplicidades
            List<Reposicao> listaReposicao = new List<Reposicao>(listaReposicaoPorQtde);
            foreach (Reposicao reposicao in listaReposicaoPorDemanda)
            {
                if (!listaReposicao.Contains(reposicao))
                {
                    listaReposicao.Add(reposicao);
                }
            }

            return listaReposicao.Count == 0 ? null : listaReposicao;
        }
    }
}