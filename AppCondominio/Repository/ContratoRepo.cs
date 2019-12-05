using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
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

        public Contrato CreateContrato(Contrato contrato)
        {
            DbSet.Add(contrato);
            context.SaveChanges();
            return contrato;
        }

        public IList<Contrato> GetContratos()
        {
            return DbSet.ToList();
        }

        public IList<Contrato> GetContratos(Locador locador)
        {
            return DbSet.Where(c => c.LocadorID == locador.Id).ToList();
        }

        public IList<Contrato> GetContratos(Locatario locatario)
        {
            return DbSet.Where(c => c.LocatarioID == locatario.Id).ToList();
        }
    }
}
