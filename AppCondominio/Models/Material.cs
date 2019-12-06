using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class Material : BaseModel
    {
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        [Required]
        public string Descricao { get; set; }
        [DataMember]
        [Required]
        public double ValorUnitario { get; set; }
        [DataMember]
        [Required]
        public double Quantidade { get; set; }
        [DataMember]
        public Fornecedor Fornecedor { get; set; }
        [ForeignKey("FornecedorID")]
        public int FornecedorID { get; set; }

        [DataMember]
        public Locador Locador { get; set; }
        [ForeignKey("LocadorID")]
        public int LocadorID { get; set; }
    }
}
