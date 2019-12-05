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
    public class Gastos : BaseModel
    {
        [DataMember]
        [Required]
        public string Tipo { get; set; }
        [DataMember]
        [Required]
        public string Descricao { get; set; }
        [DataMember]
        public double Limite { get; set; }
        [DataMember]
        [Required]
        public double Valor { get; set; }

        [DataMember]
        public Locador Locador { get; set; }
        [ForeignKey("LocadorID")]
        public int LocadorID { get; set; }
    }
}
