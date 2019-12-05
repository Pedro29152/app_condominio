using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
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

        public IList<Gastos> GetGastos()
        {
            return DbSet.ToList();
        }
    }
}
