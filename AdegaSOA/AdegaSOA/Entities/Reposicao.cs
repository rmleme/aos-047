using System;

namespace AdegaSOA.Entities
{
    public class Reposicao : IEquatable<Reposicao>
    {
        public int vinhoId
        {
            get;
            set;
        }

        public string nome
        {
            get;
            set;
        }

        public TipoVinho tipo
        {
            get;
            set;
        }

        public double preco
        {
            get;
            set;
        }

        public int qtdeAtual
        {
            get;
            set;
        }

        public int qtdeMinima
        {
            get;
            set;
        }

        public int qtdeRepor
        {
            get;
            set;
        }

        public bool Equals(Reposicao other)
        {
            return (other != null) && (this.vinhoId == other.vinhoId);
        }
    }
}