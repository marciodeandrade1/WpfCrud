using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud.Data
{
    public  class ProdutoDbContext : DbContext
    {
        #region Constructor
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion
        #region Public properties
        public DbSet<Produto> Produtos { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(GetProdutos());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private Produto[] GetProdutos()
        {
            return new Produto[]
            {
            new Produto { Id = 1, Nome = "TShirt", Descricao = "Blue Color", Preco = 2.99, Unidade =1},
            new Produto { Id = 2, Nome = "Shirt", Descricao = "Formal Shirt", Preco = 12.99, Unidade =1},
            new Produto { Id = 3, Nome = "Socks", Descricao = "Wollen", Preco = 5.00, Unidade =2},
            new Produto { Id = 4, Nome = "Tshirt", Descricao = "Red", Preco = 2.99, Unidade =3},
            };
        }
        #endregion


    }
}
