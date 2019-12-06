using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Models
{
    public class ControleEntrada
    {
        public ControleEntrada(Cliente cliente)
        {
            Cliente = cliente;
            Controles = cliente.ControlesInOut;
        }
        public Cliente Cliente { get; set; }
        public IList<ControleInOut> Controles { get; set; }
    }
}
