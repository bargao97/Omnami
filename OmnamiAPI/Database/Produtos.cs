using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Produtos
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int? Tamanho { get; set; }
        public string Cor { get; set; }
        public string Material { get; set; }
        public int Quantidade { get; set; }
        public int? IdFornecedor { get; set; }

        public virtual Fornecedor IdFornecedorNavigation { get; set; }
    }
}
