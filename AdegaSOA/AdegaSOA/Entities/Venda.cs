using System.Collections.Generic;

namespace AdegaSOA.Entities
{
    public class Venda
    {
        public List<VinhoSelecionado> vinhos
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

        public class VinhoSelecionado
        {
            public int vinhoId
            {
                get;
                set;
            }

            public int qtde
            {
                get;
                set;
            }
        }
    }
}