using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class ContatoRepo : BaseRepository<Contato>, IContatoRepo
    {
        public ContatoRepo(CondominioContext context) : base(context)
        {
        }

        public IList<Contato> GetContatos()
        {
            return DbSet.ToList();
        }
    }
}
