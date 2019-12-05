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
    public class Cliente : BaseModel
    {
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        [Required]
        public string Cpf { get; set; }
        [DataMember]
        [Required]
        public Endereco Endereco { get; set; }
        [DataMember]
        [Required]
        public Contato Contato { get; set; }

        [DataMember]
        public Locador Locador { get; set; }
        [ForeignKey("LocadorID")]
        public int LocadorID { get; set; }
    }
}
