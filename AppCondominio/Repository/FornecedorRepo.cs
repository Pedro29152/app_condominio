using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class FornecedorRepo : BaseRepository<Fornecedor>, IFornecedorRepo
    {
        public FornecedorRepo(CondominioContext context) : base(context)
        {   }
        
        public bool FornecedorExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public Fornecedor GetFornecedor(int? Id)
        {
            return DbSet
                .Include(l => l.Materiais)
                .FirstOrDefault(m => m.Id == Id);
        }

        public IList<Fornecedor> GetFornecedores()
        {
            return DbSet
                .Include(l => l.Materiais)
                .ToList();
        }

        public void DeleteFornecedor(Fornecedor fornecedor)
        {
            DbSet.Remove(fornecedor);
            context.SaveChanges();
        }

        public void GravaFornecedor(Fornecedor fornecedor)
        {
            DbSet.Add(fornecedor);
            context.SaveChanges();
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            DbSet.Update(fornecedor);
            context.SaveChanges();
        }

        public OrcamentoMateriais GetOrcamento(Fornecedor fornecedor)
        {
            return new OrcamentoMateriais(fornecedor);
        }
    }
}
