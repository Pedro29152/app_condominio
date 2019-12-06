using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class ClienteRepo : BaseRepository<Cliente>, IClienteRepo
    {
        public ClienteRepo(CondominioContext context) : base(context)
        {   }

        public bool ClienteExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public Cliente GetCliente(int? id)
        {
            return DbSet
                .Include(c => c.Endereco)
                .Include(c => c.Contato)
                .Include(c => c.ControlesInOut)
                .FirstOrDefault(m => m.Id == id);
        }

        public IList<Cliente> GetClientes()
        {
            return DbSet
                .Include(c => c.Endereco)
                .Include(c => c.Contato)
                .Include(c => c.ControlesInOut)
                .ToList();
        }

        public void RemoveCliente(Cliente cliente)
        {
            DbSet.Remove(cliente);
            context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            DbSet.Update(cliente);
            context.SaveChanges();
        }

        public void CreateCliente(Cliente cliente)
        {
            DbSet.Add(cliente);
            context.SaveChanges();
        }
    }
}
