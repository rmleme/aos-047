using AdegaSOA.DAO;

namespace AdegaSOA.Entities
{
    public class UsuarioPJ
    {
        private UsuarioDao usuarioDao = new UsuarioDao();

        public string cnpj
        {
            get;
            set;
        }

        public string senha
        {
            get;
            set;
        }

        public bool VerificarIdUsuario(string cnpj, string senha)
        {
            return this.usuarioDao.VerificarIdUsuario(cnpj, senha);
        }

        public void CadastrarUsuarioPJ(string cnpj, string senha)
        {
            this.usuarioDao.CadastrarUsuarioPJ(cnpj, senha);
        }
    }
}