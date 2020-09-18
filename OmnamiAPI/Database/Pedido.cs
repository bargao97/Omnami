using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Pedido
    {
        public int NumPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public int? IdPagamento { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Pagamento IdPagamentoNavigation { get; set; }
    }
}
