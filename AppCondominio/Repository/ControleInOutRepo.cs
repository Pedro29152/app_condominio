using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class ControleInOutRepo : BaseRepository<ControleInOut>, IControleInOutRepo
    {
        public ControleInOutRepo(CondominioContext context) : base(context)
        {
        }

        public bool ControleInOutExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public void CreateControleInOut(ControleInOut controleInOut)
        {
            DbSet.Add(controleInOut);
            context.SaveChanges();
        }

        public void DeleteControleInOut(ControleInOut controleInOut)
        {
            DbSet.Remove(controleInOut);
            context.SaveChanges();
        }

        public ControleInOut GetControleInOut(int? Id)
        {
            return DbSet
                .Include(c => c.Locador)
                .Include(c => c.Cliente)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<ControleInOut> GetControlesInOut()
        {
            return DbSet
                .Include(c => c.Locador)
                .Include(c => c.Cliente)
                .ToList();
        }

        public void UpdateControleInOut(ControleInOut controleInOut)
        {
            DbSet.Update(controleInOut);
            context.SaveChanges();
        }
    }
}
