using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IClienteRepo
    {
        IList<Cliente> GetClientes();
        Cliente GetCliente(int? id);
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void RemoveCliente(Cliente cliente);
        bool ClienteExists(int id);
    }
}
