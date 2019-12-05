using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IEnderecoRepo
    {
        IList<Endereco> GetEnderecos();
    }
}
