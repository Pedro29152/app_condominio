using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class ClienteRepo : BaseRepository<Cliente>, IClienteRepo
    {
        public ClienteRepo(CondominioContext context) : base(context)
        {
        }

        public IList<Cliente> GetClientes()
        {
            return DbSet.ToList();
        }
    }
}
