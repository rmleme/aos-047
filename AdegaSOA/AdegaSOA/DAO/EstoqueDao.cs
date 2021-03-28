using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AdegaSOA.Entities;

namespace AdegaSOA.DAO
{
    public class EstoqueDao
    {
        public List<Vinho> listarEstoque()
        {
            List<Vinho> listaVinho = new List<Vinho>();
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT vinhoId, nome, tipo, preco, prazo, qtdeAtual, qtdeMinima FROM vinho ORDER BY vinhoId";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    Vinho vinho = new Vinho();
                    vinho.vinhoId = Convert.ToInt32(objLeitor[0]);
                    vinho.nome = Convert.ToString(objLeitor[1]);
                    vinho.tipo = (TipoVinho)Enum.ToObject(typeof(TipoVinho), Convert.ToInt32(objLeitor[2]));
                    vinho.preco = Convert.ToDouble(objLeitor[3]);
                    vinho.prazo = Convert.ToInt32(objLeitor[4]);
                    vinho.qtdeAtual = Convert.ToInt32(objLeitor[5]);
                    vinho.qtdeMinima = Convert.ToInt32(objLeitor[6]);
                    listaVinho.Add(vinho);
                }
                objLeitor.Close();
                return listaVinho;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listaVinho;
            }
        }

        public int calcularDemanda(int vinhoId, DateTime data)
        {
            int demanda = 0;
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT SUM(vp.qtdeVinho) " +
                "FROM vinhopedido vp, pedido p " +
                "WHERE vp.pedidoId = p.pedidoId AND " +
                "vp.vinhoId = @vinhoId AND " +
                "p.data > @data";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            SqlParameter vinhoIdParam = new SqlParameter("@vinhoId", SqlDbType.Int);
            vinhoIdParam.Value = vinhoId;
            objCommand.Parameters.Add(vinhoIdParam);

            SqlParameter dataParam = new SqlParameter("@data", SqlDbType.DateTime);
            dataParam.Value = data;
            objCommand.Parameters.Add(dataParam);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    demanda = objLeitor[0] is DBNull ? 0 : Convert.ToInt32(objLeitor[0]);
                }
                objLeitor.Close();
                return demanda;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return demanda;
            }
        }

        public List<Reposicao> obterReposicao()
        {
            List<Reposicao> listaReposicao = new List<Reposicao>();
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT vinhoId, nome, tipo, preco, qtdeAtual, qtdeMinima FROM vinho WHERE qtdeAtual < qtdeMinima";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    Reposicao reposicao = new Reposicao();
                    reposicao.vinhoId = Convert.ToInt32(objLeitor[0]);
                    reposicao.nome = Convert.ToString(objLeitor[1]);
                    reposicao.tipo = (TipoVinho)Enum.ToObject(typeof(TipoVinho), Convert.ToInt32(objLeitor[2]));
                    reposicao.preco = Convert.ToDouble(objLeitor[3]);
                    reposicao.qtdeAtual = Convert.ToInt32(objLeitor[4]);
                    reposicao.qtdeMinima = Convert.ToInt32(objLeitor[5]);
                    reposicao.qtdeRepor = Convert.ToInt32(objLeitor[5]);
                    listaReposicao.Add(reposicao);
                }
                objLeitor.Close();
                return listaReposicao;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listaReposicao;
            }
        }

        public void atualizarStatusPedido(Pedido pedido)
        {
            switch (pedido.status)
            {
                case StatusPedido.Entregue: return;
                case StatusPedido.Estoque: pedido.status = StatusPedido.Transito;
                    break;
                case StatusPedido.Transito: pedido.status = StatusPedido.Entregue;
                    break;
                default: return;
            }

            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "UPDATE pedido SET status = " + Convert.ToInt32(Enum.Parse(typeof(StatusPedido), pedido.status.ToString())) + " WHERE pedidoId = " + pedido.pedidoId;
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
            }
        }
    }
}