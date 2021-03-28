using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using AdegaSOA.Entities;

namespace AdegaSOA.DAO
{
    public class PedidoDao
    {
        public List<Pedido> ListarPedidos()
        {
            List<Pedido> listaPedido = new List<Pedido>();
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT pedidoId, status, data, qtdeTotalVinho, valorTotal, cnpj, cpf, nomePF, cartaoPF, enderecoPF FROM pedido ORDER BY pedidoId";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.pedidoId = Convert.ToInt32(objLeitor[0]);
                    pedido.status = (StatusPedido)Enum.ToObject(typeof(StatusPedido), Convert.ToInt32(objLeitor[1]));
                    pedido.data = Convert.ToDateTime(objLeitor[2]);
                    pedido.qtdeTotalVinho = Convert.ToInt32(objLeitor[3]);
                    pedido.valorTotal = Convert.ToDouble(objLeitor[4]);
                    pedido.cnpj = Convert.ToString(objLeitor[5]);
                    pedido.cpf = Convert.ToString(objLeitor[6]);
                    pedido.nomePF = Convert.ToString(objLeitor[7]);
                    pedido.cartaoPF = Convert.ToString(objLeitor[8]);
                    pedido.enderecoPF = Convert.ToString(objLeitor[9]);
                    listaPedido.Add(pedido);
                }
                objLeitor.Close();
                return listaPedido;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return listaPedido;
            }
        }

        public Pedido GerarOrderId(Venda venda)
        {
            Pedido pedido = new Pedido();
            SqlConnection objConexao = null;
            String strQuery = null;
            SqlCommand objCommand = null;

            int qtdeTotalVinho = 0;
            double valorTotal = 0.0;
            foreach (Venda.VinhoSelecionado vinho in venda.vinhos)
            {
                double preco = 0.0;
                objConexao = Conexao.getConexao();
                strQuery = "SELECT preco FROM vinho WHERE vinhoId = " + vinho.vinhoId;
                objCommand = new SqlCommand(strQuery, objConexao);

                try
                {
                    objCommand.ExecuteNonQuery();
                    SqlDataReader objLeitor = objCommand.ExecuteReader();
                    while (objLeitor.Read())
                    {
                        preco = Convert.ToDouble(objLeitor[0]);
                    }
                    objLeitor.Close();
                }
                catch (SqlException err)
                {
                    String strErro = "Erro: " + err.ToString();
                    Console.Write(strErro);
                    return pedido;
                }

                qtdeTotalVinho += vinho.qtde;
                valorTotal += vinho.qtde * preco;
            }


            pedido.status = StatusPedido.Estoque;
            pedido.data = DateTime.Now;
            pedido.qtdeTotalVinho = qtdeTotalVinho;
            pedido.valorTotal = valorTotal;
            pedido.cnpj = venda.cnpj;
            pedido.cpf = venda.cpf;
            pedido.nomePF = venda.nomePF;
            pedido.cartaoPF = venda.cartaoPF;
            pedido.enderecoPF = venda.enderecoPF;

            objConexao = Conexao.getConexao();
            strQuery = "INSERT INTO pedido(status, data, qtdeTotalVinho, valorTotal, cnpj, cpf, nomePF, cartaoPF, enderecoPF) " +
                "VALUES(@status, @data, @qtdeTotalVinho, @valorTotal, @cnpj, @cpf, @nomePF, @cartaoPF, @enderecoPF) " +
                "SET @pedidoId = SCOPE_IDENTITY()";
            objCommand = new SqlCommand(strQuery, objConexao);
            this.fillQueryParameters(objCommand, pedido);
            SqlParameter pedidoIdParam = new SqlParameter("@pedidoID", SqlDbType.Int);
            pedidoIdParam.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(pedidoIdParam);

            try
            {
                objCommand.ExecuteNonQuery();
                pedido.pedidoId = (int)pedidoIdParam.Value;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return pedido;
            }


            foreach (Venda.VinhoSelecionado vinho in venda.vinhos)
            {
                objConexao = Conexao.getConexao();
                strQuery = "INSERT INTO vinhopedido(vinhoId, pedidoId, qtdeVinho) " +
                    "VALUES(" + vinho.vinhoId + ", " + pedido.pedidoId + ", " + vinho.qtde + ")";
                objCommand = new SqlCommand(strQuery, objConexao);

                try
                {
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    String strErro = "Erro: " + err.ToString();
                    Console.Write(strErro);
                    return pedido;
                }


                objConexao = Conexao.getConexao();
                strQuery = "UPDATE vinho SET qtdeAtual = qtdeAtual - " + vinho.qtde + " WHERE vinhoId = " + vinho.vinhoId;
                objCommand = new SqlCommand(strQuery, objConexao);

                try
                {
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    String strErro = "Erro: " + err.ToString();
                    Console.Write(strErro);
                    return pedido;
                }
            }

            return pedido;
        }

        private void fillQueryParameters(SqlCommand objCommand, Pedido pedido)
        {
            SqlParameter statusParam = new SqlParameter("@status", SqlDbType.Int);
            statusParam.Value = pedido.status;
            objCommand.Parameters.Add(statusParam);

            SqlParameter dataParam = new SqlParameter("@data", SqlDbType.DateTime);
            dataParam.Value = pedido.data;
            objCommand.Parameters.Add(dataParam);

            SqlParameter qtdeTotalVinhoParam = new SqlParameter("@qtdeTotalVinho", SqlDbType.Int);
            qtdeTotalVinhoParam.Value = pedido.qtdeTotalVinho;
            objCommand.Parameters.Add(qtdeTotalVinhoParam);

            SqlParameter valorTotalParam = new SqlParameter("@valorTotal", SqlDbType.Real);
            valorTotalParam.Value = pedido.valorTotal;
            objCommand.Parameters.Add(valorTotalParam);

            SqlParameter cnpjParam = new SqlParameter("@cnpj", SqlDbType.NVarChar);
            cnpjParam.Value = pedido.cnpj == null || pedido.cnpj.Trim().Equals(string.Empty) ? SqlString.Null : pedido.cnpj;
            objCommand.Parameters.Add(cnpjParam);

            SqlParameter cpfParam = new SqlParameter("@cpf", SqlDbType.NVarChar);
            cpfParam.Value = pedido.cpf == null || pedido.cpf.Trim().Equals(string.Empty) ? SqlString.Null : pedido.cpf;
            objCommand.Parameters.Add(cpfParam);

            SqlParameter nomePFParam = new SqlParameter("@nomePF", SqlDbType.NVarChar);
            nomePFParam.Value = pedido.nomePF == null || pedido.nomePF.Trim().Equals(string.Empty) ? SqlString.Null : pedido.nomePF;
            objCommand.Parameters.Add(nomePFParam);

            SqlParameter cartaoPFParam = new SqlParameter("@cartaoPF", SqlDbType.NVarChar);
            cartaoPFParam.Value = pedido.cartaoPF == null || pedido.cartaoPF.Trim().Equals(string.Empty) ? SqlString.Null : pedido.cartaoPF;
            objCommand.Parameters.Add(cartaoPFParam);

            SqlParameter enderecoPFParam = new SqlParameter("@enderecoPF", SqlDbType.NVarChar);
            enderecoPFParam.Value = pedido.enderecoPF == null || pedido.enderecoPF.Trim().Equals(string.Empty) ? SqlString.Null : pedido.enderecoPF;
            objCommand.Parameters.Add(enderecoPFParam);
        }

        public Pedido ConsultarPedido(int pedidoId)
        {
            Pedido pedido = new Pedido();
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT pedidoId, status, data, qtdeTotalVinho, valorTotal, cnpj, cpf, nomePF, cartaoPF, enderecoPF FROM pedido WHERE pedidoId = " + pedidoId;
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    pedido.pedidoId = Convert.ToInt32(objLeitor[0]);
                    pedido.status = (StatusPedido)Enum.ToObject(typeof(StatusPedido), Convert.ToInt32(objLeitor[1]));
                    pedido.data = Convert.ToDateTime(objLeitor[2]);
                    pedido.qtdeTotalVinho = Convert.ToInt32(objLeitor[3]);
                    pedido.valorTotal = Convert.ToDouble(objLeitor[4]);
                    pedido.cnpj = Convert.ToString(objLeitor[5]);
                    pedido.cpf = Convert.ToString(objLeitor[6]);
                    pedido.nomePF = Convert.ToString(objLeitor[7]);
                    pedido.cartaoPF = Convert.ToString(objLeitor[8]);
                    pedido.enderecoPF = Convert.ToString(objLeitor[9]);
                }
                objLeitor.Close();
                return pedido;
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return pedido;
            }
        }

        public bool CancelarPedido(int pedidoId)
        {
            List<VinhoPedido> listaVP = new List<VinhoPedido>();
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT vinhoId, pedidoId, qtdeVinho FROM vinhopedido WHERE pedidoId = " + pedidoId;
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    VinhoPedido vp = new VinhoPedido();
                    vp.vinhoId = Convert.ToInt32(objLeitor[0]);
                    vp.pedidoId = Convert.ToInt32(objLeitor[1]);
                    vp.qtdeVinho = Convert.ToInt32(objLeitor[2]);
                    listaVP.Add(vp);
                }
                objLeitor.Close();
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return false;
            }

            foreach (VinhoPedido vp in listaVP)
            {
                objConexao = Conexao.getConexao();
                strQuery = "UPDATE vinho SET qtdeAtual = qtdeAtual + " + vp.qtdeVinho + " WHERE vinhoId = " + vp.vinhoId;
                objCommand = new SqlCommand(strQuery, objConexao);
                try
                {
                    objCommand.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    String strErro = "Erro: " + err.ToString();
                    Console.Write(strErro);
                    return false;
                }

                objConexao = Conexao.getConexao();
                strQuery = "DELETE FROM vinhopedido WHERE pedidoId = " + vp.pedidoId + " AND vinhoId = " + vp.vinhoId;
                objCommand = new SqlCommand(strQuery, objConexao);
                try
                {
                    objCommand.ExecuteNonQuery();
                    SqlDataReader objLeitor = objCommand.ExecuteReader();
                    objLeitor.Close();
                }
                catch (SqlException err)
                {
                    String strErro = "Erro: " + err.ToString();
                    Console.Write(strErro);
                    return false;
                }
            }

            objConexao = Conexao.getConexao();
            strQuery = "DELETE FROM pedido WHERE pedidoId = " + pedidoId;
            objCommand = new SqlCommand(strQuery, objConexao);
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
                return false;
            }

            return true;
        }
    }
}