using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class OrcamentoLocador
    {
        public OrcamentoLocador(Locador Locador)
        {
            this.Locador = Locador;
            Gastos = Locador.Gastos;
            Materiais = Locador.Materiais;
            Contratos = Locador.Contratos;
            TotalGanho = Locador.Contratos.Sum(c => c.Valor);
            TotalGasto = Locador.Gastos.Sum(g => g.Valor) + Locador.Materiais.Sum(m => m.ValorUnitario * m.QuantidadeTotal);
        }

        [DataMember]
        public double TotalGasto { get; set; }
        [DataMember]
        public double TotalGanho { get; set; }
        [DataMember]
        public Locador Locador { get; set; }
        [DataMember]
        public IList<Gastos> Gastos { get; set; }
        [DataMember]
        public IList<Material> Materiais { get; set; }
        [DataMember]
        public IList<Contrato> Contratos { get; set; }

    }
}
