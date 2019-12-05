using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AppCondominio.Models
{
    [DataContract]
    public class Endereco : BaseModel
    {
        [Required]
        [DataMember]
        public string Cep { get; set; }
        [Required]
        [DataMember]
        public string Logradouro { get; set; }
        [Required]
        [DataMember]
        public string Nr { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [Required]
        [DataMember]
        public string Bairro { get; set; }
        [Required]
        [DataMember]
        public string Cidade { get; set; }
        [Required]
        [DataMember]
        public string Estado{ get; set; }

        public override string ToString()
        {
            return $"{Cep} - {Logradouro} {Nr}, {Bairro}, {Cidade}, {Estado}";
        }
    }
}
