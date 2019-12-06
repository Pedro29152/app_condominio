using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IGastosRepo
    {
        IList<Gastos> GetGastos();
        Gastos GetGasto(int? Id);
        Gastos CreateGastos(Gastos gastos);
        void UpdateGastos(Gastos gastos);
        void DeleteGastos(Gastos gastos);
        bool GastosExists(int id);
    }
}
