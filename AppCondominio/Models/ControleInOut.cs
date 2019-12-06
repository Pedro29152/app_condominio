using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    [DataContract]
    public class ControleInOut : BaseModel
    {
        [DataMember]
        [Required]
        public DateTime DataEntrada { get; set; }
        [DataMember]
        public DateTime? DataSaida { get; set; }

        [DataMember]
        [Required]
        public int LocadorID { get; set; }
        [DataMember]
        public Locador Locador { get; set; }
        [DataMember]
        [Required]
        public int ClienteID { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
    }
}
