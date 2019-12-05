using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class FormaPagamentoRepo : BaseRepository<FormaPagamento>, IFormaPagamentoRepo
    {
        public FormaPagamentoRepo(CondominioContext context) : base(context)
        {
        }

        public IList<FormaPagamento> GetFormasPagamento()
        {
            return DbSet.ToList();
        }
    }
}
