using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class FornecedorRepo : BaseRepository<Fornecedor>, IFornecedorRepo
    {
        public FornecedorRepo(CondominioContext context) : base(context)
        {
        }

        public IList<Fornecedor> GetFornecedores()
        {
            return DbSet.ToList();
        }

        public OrcamentoMateriais GetOrcamento(Fornecedor fornecedor)
        {
            return new OrcamentoMateriais(fornecedor);
        }
    }
}
