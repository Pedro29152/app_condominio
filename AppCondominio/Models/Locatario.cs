using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class Locatario : BaseModel
    {
        [DataMember]
        [Required]
        public string Documento { get; set; }
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        [Required]
        public Endereco Endereco { get; set; }
        [DataMember]
        [Required]
        public Contato Contato { get; set; }

        [DataMember]
        public IList<Contrato> Contratos { get; set; }
    }
}
