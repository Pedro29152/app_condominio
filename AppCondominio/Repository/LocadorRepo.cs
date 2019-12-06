using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppCondominio.Repository
{
    public class LocadorRepo : BaseRepository<Locador>, ILocadorRepo
    {
        public LocadorRepo(CondominioContext context) : base(context)
        {
        }


        public Locador GetLocador(int? Id)
        {
            return DbSet
                .Include(l => l.Contratos).ThenInclude(c => c.Locatario)
                .Include(l => l.Endereco)
                .Include(l => l.Contato)
                .Include(l => l.Gastos)
                .Include(l => l.Materiais)
                .Include(l => l.ControlesInOut)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<Locador> GetLocadores()
        {
            return DbSet
                .Include(l => l.Endereco)
                .Include(l => l.Contato)
                .Include(l => l.Gastos)
                .Include(l => l.Materiais)
                .Include(l => l.Contratos)
                .Include(l => l.ControlesInOut)
                .ToList();
        }

        public OrcamentoLocador GetOrcamento(Locador locador)
        {
            return new OrcamentoLocador(locador);
        }

        public void GravaLocador(Locador locador)
        {
            DbSet.Add(locador);
            context.SaveChanges();
        }

        public void UpdateLocador(Locador locador)
        {
            DbSet.Update(locador);
            context.SaveChanges();
        }

        public void DeleteLocador(Locador locador)
        {
            DbSet.Remove(locador);
            context.SaveChanges();
        }

        public bool LocadorExists(int id)
        {
            return DbSet.Any(l => l.Id == id);
        }
    }
}
