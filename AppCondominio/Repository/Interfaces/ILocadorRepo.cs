using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface ILocadorRepo
    {
        IList<Locador> GetLocadores();
        Locador GetLocador(int? Id);
        OrcamentoLocador GetOrcamento(Locador locador);
        void GravaLocador(Locador locador);
        void UpdateLocador(Locador locador);
        void DeleteLocador(Locador locador);
        bool LocadorExists(int id);
    }
}
