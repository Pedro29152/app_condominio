using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class GastosRepo : BaseRepository<Gastos>, IGastosRepo
    {
        public GastosRepo(CondominioContext context) : base(context)
        {
        }

        public Gastos CreateGastos(Gastos gastos)
        {
            DbSet.Add(gastos);
            context.SaveChanges();
            return gastos;
        }

        public void DeleteGastos(Gastos gastos)
        {
            DbSet.Remove(gastos);
            context.SaveChanges();
        }

        public bool GastosExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public Gastos GetGasto(int? Id)
        {
            return DbSet
                .Include(l => l.Locador)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<Gastos> GetGastos()
        {
            return DbSet
                .Include(l => l.Locador)
                .ToList();
        }

        public void UpdateGastos(Gastos gastos)
        {
            DbSet.Update(gastos);
            context.SaveChanges();
        }
    }
}
