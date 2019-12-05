using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface ILocatarioRepo
    {
        IList<Locatario> GetLocatarios();
    }
}
