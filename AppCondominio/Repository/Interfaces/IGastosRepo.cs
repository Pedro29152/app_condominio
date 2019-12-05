using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IGastosRepo
    {
        IList<Gastos> GetGastos();
        Gastos CreateGastos(Gastos gastos);
    }
}
