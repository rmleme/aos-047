using System;
using System.Collections.Generic;
using AdegaSOA.DAO;

namespace AdegaSOA.Entities
{
    public class Pedido
    {
        private PedidoDao pedidoDao = new PedidoDao();

        public int pedidoId
        {
            get;
            set;
        }

        public StatusPedido status
        {
            get;
            set;
        }

        public DateTime data
        {
            get;
            set;
        }

        public int qtdeTotalVinho
        {
            get;
            set;
        }

        public double valorTotal
        {
            get;
            set;
        }

        public string cnpj
        {
            get;
            set;
        }

        public string cpf
        {
            get;
            set;
        }

        public string nomePF
        {
            get;
            set;
        }

        public string cartaoPF
        {
            get;
            set;
        }

        public string enderecoPF
        {
            get;
            set;
        }

        public List<Pedido> ListarPedidos()
        {
            return this.pedidoDao.ListarPedidos();
        }

        public Pedido GerarOrderId(Venda venda)
        {
            return this.pedidoDao.GerarOrderId(venda);

        }

        public Pedido ConsultarPedido(int pedidoId)
        {
            return this.pedidoDao.ConsultarPedido(pedidoId);
        }

        public void CancelarPedido(int pedidoId)
        {
            this.pedidoDao.CancelarPedido(pedidoId);
        }
    }
}