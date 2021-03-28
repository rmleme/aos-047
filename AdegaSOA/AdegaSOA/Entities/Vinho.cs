namespace AdegaSOA.Entities
{
    public class Vinho
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

        public int prazo
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
    }
}
