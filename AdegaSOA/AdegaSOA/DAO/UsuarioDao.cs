using System;
using System.Data.SqlClient;

namespace AdegaSOA.DAO
{
    public class UsuarioDao
    {
        public bool VerificarIdUsuario(string cnpj, string senha)
        {
            int cont = 0;
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "SELECT COUNT(cnpj) FROM usuarioPJ WHERE cnpj = '" + cnpj + "' "
            + "AND senha = '" + senha + "'";
            SqlCommand objCommand = new SqlCommand(strQuery, objConexao);

            try
            {
                objCommand.ExecuteNonQuery();
                SqlDataReader objLeitor = objCommand.ExecuteReader();
                while (objLeitor.Read())
                {
                    cont = Convert.ToInt32(objLeitor[0]);
                }
                objLeitor.Close();
            }
            catch (SqlException err)
            {
                String strErro = "Erro: " + err.ToString();
                Console.Write(strErro);
            }
            return cont == 1;
        }

        public void CadastrarUsuarioPJ(string cnpj, string senha)
        {
            SqlConnection objConexao = Conexao.getConexao();
            String strQuery = "INSERT INTO usuarioPJ (cnpj, senha) " +
                "VALUES ('" + cnpj + "', '" + senha + "')";
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