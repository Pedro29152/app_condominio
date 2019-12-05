using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IMaterialRepo
    {
        IList<Material> GetMateriais();
        Material CreateMaterial(Material material);
    }
}
