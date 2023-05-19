using CompanySales.Domain.Models;
using CompanySales.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CompanySales.Infrastructure.Context
{
    public class CompanySalesContext : DbContext
    {
        public CompanySalesContext(DbContextOptions<CompanySalesContext> options) : base(options)
        {

        }
        public DbSet<VendedorModel> Vendedores { get; set; }
        public DbSet<ItemModel> Itens { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>()
                    .HasMany(Item => Item.Venda)
                    .WithOne(Venda => Venda.Item)
                    .HasForeignKey(Venda => Venda.IdItem);

            modelBuilder.Entity<VendedorModel>()
                .HasMany(Vendedor => Vendedor.Venda)
                .WithOne(Venda => Venda.Vendedor)
                .HasForeignKey(Venda => Venda.IdVendedor);

            modelBuilder.ApplyConfiguration(new VendedorConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new VendaConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
