using AppCondominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio
{
    public class CondominioContext : DbContext
    {
        public CondominioContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Locatario> Locatarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasOne(c => c.Endereco);
            modelBuilder.Entity<Cliente>().HasOne(c => c.Contato);
            modelBuilder.Entity<Cliente>().HasOne(c => c.Locador).WithMany(l => l.Clientes).HasForeignKey(c => c.LocadorID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contrato>().HasOne(c => c.Locador).WithMany(c => c.Contratos).HasForeignKey(c => c.LocadorID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contrato>().HasOne(c => c.Locatario).WithMany(c => c.Contratos).HasForeignKey(c => c.LocatarioID).OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Locador>().HasOne(l => l.Endereco);
            modelBuilder.Entity<Locador>().HasOne(l => l.Contato);
            
            modelBuilder.Entity<Locatario>().HasOne(l => l.Endereco);

            modelBuilder.Entity<Gastos>().HasOne(g => g.Locador).WithMany(l => l.Gastos).HasForeignKey(g=>g.LocadorID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Material>().HasOne(m => m.Fornecedor).WithMany(l => l.Materiais).HasForeignKey(m => m.FornecedorID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Material>().HasOne(m => m.Locador).WithMany(l => l.Materiais).HasForeignKey(m=>m.LocadorID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FormaPagamento>().HasOne(f => f.Contrato).WithMany(c => c.FormasPagamento).HasForeignKey(f => f.ContratoID).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Endereco>();
            modelBuilder.Entity<Contato>();
        }
    }
}
