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
    public class FormaPagamento : BaseModel
    {
        [DataMember]
        [Required]
        public string Nome { get; set; }

        [ForeignKey("ContratoID")]
        public int ContratoID { get; set; }
        public Contrato Contrato { get; set; }
    }
}
