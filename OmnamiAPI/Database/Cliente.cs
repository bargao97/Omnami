using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Cliente
    {
        public Cliente()
        {
            Endereco = new HashSet<Endereco>();
            Pagamento = new HashSet<Pagamento>();
            Pedido = new HashSet<Pedido>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
