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
        public string FormaPagamento { get; set; }
        [ForeignKey("LocadorID")]
        [Required]
        public int LocadorID { get; set; }
        [DataMember]
        public Locador Locador { get; set; }
        [ForeignKey("LocatarioID")]
        [Required]
        public int LocatarioID { get; set; }
        [DataMember]
        public Locatario Locatario { get; set; }
    }
}
