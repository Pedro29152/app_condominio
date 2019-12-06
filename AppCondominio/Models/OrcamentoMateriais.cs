using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class OrcamentoMateriais
    {
        public OrcamentoMateriais(Fornecedor Fornecedor)
        {
            this.Fornecedor = Fornecedor;
            Materiais = Fornecedor.Materiais;
            QuantidadeDeMateriais = Materiais.Count;
            Total = Materiais.Sum(m => m.Quantidade * m.ValorUnitario);
        }

        [DataMember]
        public Fornecedor Fornecedor { get; set; }
        [DataMember]
        public double Total { get; set; }
        [DataMember]
        public int QuantidadeDeMateriais { get; set; }
        [DataMember]
        public IList<Material> Materiais { get; set; }
    }
}
