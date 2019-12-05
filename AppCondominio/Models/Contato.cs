using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class Contato : BaseModel
    {
        [DataMember]
        [Required]
        public string Tel1 { get; set; }
        [DataMember]
        public string Tel2 { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
    }
}
