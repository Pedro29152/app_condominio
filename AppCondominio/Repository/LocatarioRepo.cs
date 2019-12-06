using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class LocatarioRepo : BaseRepository<Locatario>, ILocatarioRepo
    {
        public LocatarioRepo(CondominioContext context) : base(context)
        {
        }

        public Locatario GetLocatario(int? Id)
        {
            return DbSet
                .Include(l => l.Endereco)
                .Include(l => l.Contato)
                .Include(l => l.Contratos)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<Locatario> GetLocatarios()
        {
            return DbSet
                .Include(l => l.Endereco)
                .Include(l => l.Contato)
                .Include(l => l.Contratos)
                .ToList();
        }

        public bool LocatarioExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public void UpdateLocatario(Locatario locatario)
        {
            DbSet.Update(locatario);
            context.SaveChanges();
        }

        public void DeleteLocatario(Locatario locatario)
        {
            DbSet.Remove(locatario);
            context.SaveChanges();
        }

        public void CreateLocatario(Locatario locatario)
        {
            DbSet.Add(locatario);
            context.SaveChanges();
        }
    }
}
