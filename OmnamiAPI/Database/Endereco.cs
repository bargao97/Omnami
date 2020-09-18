using System;
using System.Collections.Generic;

namespace OmnamiAPI.Database
{
    public partial class Endereco
    {
        public Endereco()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
