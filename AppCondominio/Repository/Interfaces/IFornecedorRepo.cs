using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IFornecedorRepo
    {
        IList<Fornecedor> GetFornecedores();
        OrcamentoMateriais GetOrcamento(Fornecedor fornecedor);
    }
}
