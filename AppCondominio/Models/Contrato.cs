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
    public class Contrato : BaseModel
    {
        [DataMember]
        [Required]
        public DateTime DataInicio { get; set; }
        [DataMember]
        public DateTime? DataFim { get; set; }
        [DataMember]
        [Required]
        public double Valor { get; set; }
        [DataMember]
        [Required]
        public IList<FormaPagamento> FormasPagamento { get; set; }
        [DataMember]
        [Required]
        public Locador Locador { get; set; }
        [ForeignKey("LocadorID")]
        public int LocadorID { get; set; }
        [DataMember]
        [Required]
        public Locatario Locatario { get; set; }
        [ForeignKey("LocatarioID")]
        public int LocatarioID { get; set; }
    }
}
