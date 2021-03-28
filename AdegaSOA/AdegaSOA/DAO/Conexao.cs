using System.Data.SqlClient;
using System.Web.Configuration;

namespace AdegaSOA.DAO
{
    public class Conexao
    {
        private static SqlConnection objConexao = null;

        public Conexao()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = WebConfigurationManager.ConnectionStrings["AdegaDB"].ConnectionString;
            objConexao.Open();
        }

        public static SqlConnection getConexao()
        {
            if (objConexao == null)
            {
                new Conexao();
            }
            return objConexao;
        }

        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }
}