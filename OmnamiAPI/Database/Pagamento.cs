using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Pagamento
    {
        public Pagamento()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdPagamento { get; set; }
        public string Cpf { get; set; }
        public string TipoPagamento { get; set; }
        public string NumCartao { get; set; }
        public string Boleto { get; set; }
        public string Nome { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
