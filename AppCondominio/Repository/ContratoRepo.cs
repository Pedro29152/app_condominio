using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class ContratoRepo : BaseRepository<Contrato>, IContratoRepo
    {
        public ContratoRepo(CondominioContext context) : base(context)
        {
        }

        public bool ContratoExists(int id)
        {
            return DbSet.Any(l => l.Id == id);
        }

        public Contrato CreateContrato(Contrato contrato)
        {
            DbSet.Add(contrato);
            context.SaveChanges();
            return contrato;
        }

        public void DeleteContrato(Contrato contrato)
        {
            DbSet.Remove(contrato);
            context.SaveChanges();
        }

        public Contrato GetContrato(int? Id)
        {
            return DbSet
                .Include(c => c.Locador)
                .Include(c => c.Locatario)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<Contrato> GetContratos()
        {
            return DbSet
                .Include(c => c.Locador)
                .Include(c => c.Locatario)
                .ToList();
        }

        public IList<Contrato> GetContratos(Locador locador)
        {
            return DbSet.Where(c => c.LocadorID == locador.Id).ToList();
        }

        public IList<Contrato> GetContratos(Locatario locatario)
        {
            return DbSet.Where(c => c.LocatarioID == locatario.Id).ToList();
        }

        public void UpdateContrato(Contrato contrato)
        {
            DbSet.Update(contrato);
            context.SaveChanges();
        }
    }
}
