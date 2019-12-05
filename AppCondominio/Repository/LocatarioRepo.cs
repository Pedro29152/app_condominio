using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
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

        public IList<Locatario> GetLocatarios()
        {
            return DbSet.ToList();
        }
    }
}
