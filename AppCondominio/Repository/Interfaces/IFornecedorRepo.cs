using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IFornecedorRepo
    {
        IList<Fornecedor> GetFornecedores();
        Fornecedor GetFornecedor(int? Id);
        void GravaFornecedor(Fornecedor fornecedor);
        void UpdateFornecedor(Fornecedor fornecedor);
        void DeleteFornecedor(Fornecedor fornecedor);
        bool FornecedorExists(int id);
        OrcamentoMateriais GetOrcamento(Fornecedor fornecedor);
    }
}
