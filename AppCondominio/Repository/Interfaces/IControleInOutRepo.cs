using AppCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository.Interfaces
{
    public interface IControleInOutRepo
    {
        IList<ControleInOut> GetControlesInOut();
        ControleInOut GetControleInOut(int? Id);
        void CreateControleInOut(ControleInOut controleInOut);
        void UpdateControleInOut(ControleInOut controleInOut);
        void DeleteControleInOut(ControleInOut controleInOut);
        bool ControleInOutExists(int id);
    }
}
