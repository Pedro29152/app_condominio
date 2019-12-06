using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AppCondominio.Models
{
    [DataContract]
    public class Locador : BaseModel
    {
        [DataMember]
        [Required]
        public string Documento { get; set; }
        [DataMember]
        [Required]
        public string Nome { get; set; }
        [DataMember]
        public Endereco Endereco { get; set; }
        [DataMember]
        public Contato Contato { get; set; }
        
        [DataMember]
        public IList<Gastos> Gastos { get; set; }

        [DataMember]
        public IList<Material> Materiais { get; set; }

        [DataMember]
        public IList<Contrato> Contratos { get; set; }

        [DataMember]
        public IList<ControleInOut> ControlesInOut { get; set; }
        //Verificar pagamentos
    }
}
