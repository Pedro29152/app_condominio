using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class Fornecedor : BaseModel
    {
        [DataMember]
        [Required]
        public string CNPJ { get; set; }
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        [Required]
        public string Descricao { get; set; }

        public IList<Material> Materiais { get; set; }
    }
}
