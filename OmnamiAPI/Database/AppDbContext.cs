using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OmnamiAPI.Database
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=OMNAMI;Persist Security Info=True;User ID=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__23A34130B9B215C8");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__ENDERECO__0657EF84B740C55F");

                entity.ToTable("ENDERECO");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.Property(e => e.Bairro)
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("CIDADE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("RUA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__ENDERECO__ID_CLI__4BAC3F29");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__FORNECED__0AE4966D465EF898");

                entity.ToTable("FORNECEDOR");

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.Property(e => e.DataFornecedor)
                    .HasColumnName("DATA_FORNECEDOR")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PK__PAGAMENT__F3C896DB8C838F4C");

                entity.ToTable("PAGAMENTO");

                entity.Property(e => e.IdPagamento).HasColumnName("ID_PAGAMENTO");

                entity.Property(e => e.Boleto)
                    .HasColumnName("BOLETO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumCartao)
                    .HasColumnName("NUM_CARTAO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPagamento)
                    .HasColumnName("TIPO_PAGAMENTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pagamento)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__PAGAMENTO__ID_CL__4E88ABD4");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NumPedido)
                    .HasName("PK__PEDIDO__5311FF2EDC20FECA");

                entity.ToTable("PEDIDO");

                entity.Property(e => e.NumPedido).HasColumnName("NUM_PEDIDO");

                entity.Property(e => e.DataPedido)
                    .HasColumnName("DATA_PEDIDO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.Property(e => e.IdPagamento).HasColumnName("ID_PAGAMENTO");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__PEDIDO__ID_CLIEN__534D60F1");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__PEDIDO__ID_ENDER__52593CB8");

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdPagamento)
                    .HasConstraintName("FK__PEDIDO__ID_PAGAM__5165187F");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__PRODUTOS__69B28A52730EEA4E");

                entity.ToTable("PRODUTOS");

                entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");

                entity.Property(e => e.Cor)
                    .HasColumnName("COR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IdFornecedor).HasColumnName("ID_FORNECEDOR");

                entity.Property(e => e.Material)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");

                entity.Property(e => e.Tamanho).HasColumnName("TAMANHO");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__PRODUTOS__ID_FOR__5812160E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
