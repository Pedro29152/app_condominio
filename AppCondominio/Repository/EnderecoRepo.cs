using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class EnderecoRepo : BaseRepository<Endereco>, IEnderecoRepo
    {
        public EnderecoRepo(CondominioContext context) : base(context)
        {
        }

        public IList<Endereco> GetEnderecos()
        {
            return DbSet.ToList();
        }
    }
}
