using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IContatoRepo
    {
        IList<Contato> GetContatos();
    }
}
