using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface ILocatarioRepo
    {
        IList<Locatario> GetLocatarios();
        Locatario GetLocatario(int? Id);
        void CreateLocatario(Locatario locatario);
        void UpdateLocatario(Locatario locatario);
        void DeleteLocatario(Locatario locatario);
        bool LocatarioExists(int id);
    }
}
