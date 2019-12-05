using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
        public IList<Cliente> Clientes { get; set; }

        [DataMember]
        public IList<Gastos> Gastos { get; set; }

        [DataMember]
        public IList<Material> Materiais { get; set; }

        [DataMember]
        public IList<Contrato> Contratos { get; set; }
        //Verificar pagamentos
    }
}
