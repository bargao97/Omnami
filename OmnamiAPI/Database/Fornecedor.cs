using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Produtos = new HashSet<Produtos>();
        }

        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public DateTime? DataFornecedor { get; set; }

        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
