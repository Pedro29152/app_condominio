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
        public DbSet<ControleInOut> ControlesInOut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cliente ==> Endereco
            modelBuilder.Entity<Cliente>().HasOne(c => c.Endereco);
            //Cliente ==> Contato
            modelBuilder.Entity<Cliente>().HasOne(c => c.Contato);

            //Locador ==> Endereco
            modelBuilder.Entity<Locador>().HasOne(l => l.Endereco);
            //Locador ==> Contato
            modelBuilder.Entity<Locador>().HasOne(l => l.Contato);

            //Locatario ==> Endereco
            modelBuilder.Entity<Locatario>().HasOne(l => l.Endereco);

            //Contrato ==> Locador(LocadorID)
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Locador)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.LocadorID)
                .OnDelete(DeleteBehavior.Restrict);
            //Contrato ==> Locatario(LocatarioID)
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Locatario)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.LocatarioID)
                .OnDelete(DeleteBehavior.Restrict);

            //Locatario ==> Locador(LocadorID)
            modelBuilder.Entity<Gastos>()
                .HasOne(g => g.Locador)
                .WithMany(l => l.Gastos)
                .HasForeignKey(g=>g.LocadorID)
                .OnDelete(DeleteBehavior.Restrict);

            //Material ==> Fornecedor(FornecedorID)
            modelBuilder.Entity<Material>()
                .HasOne(m => m.Fornecedor)
                .WithMany(l => l.Materiais)
                .HasForeignKey(m => m.FornecedorID)
                .OnDelete(DeleteBehavior.Restrict);
            //Material ==> Locador(LocadorID)
            modelBuilder.Entity<Material>()
                .HasOne(m => m.Locador)
                .WithMany(l => l.Materiais)
                .HasForeignKey(m=>m.LocadorID)
                .OnDelete(DeleteBehavior.Restrict);

            //FormaPagamento ==> Contrato(ContratoID)
            modelBuilder.Entity<FormaPagamento>()
                .HasOne(f => f.Contrato)
                .WithMany(c => c.FormasPagamento)
                .HasForeignKey(f => f.ContratoID)
                .OnDelete(DeleteBehavior.Restrict);

            //ControleInOut ==> Cliente(ClienteID)
            modelBuilder.Entity<ControleInOut>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.ControlesInOut)
                .HasForeignKey(c => c.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);
            //ControleInOut ==> Locador(LocadorID)
            modelBuilder.Entity<ControleInOut>()
                .HasOne(c => c.Locador)
                .WithMany(l => l.ControlesInOut)
                .HasForeignKey(c => c.LocadorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
