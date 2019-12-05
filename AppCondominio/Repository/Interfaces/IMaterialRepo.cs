using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IMaterialRepo
    {
        IList<Material> GetMateriais();
        Material CreateMaterial(Material material);
        Material GetMaterial(int? id);
        void UpdateMaterial(Material material);
        void RemoveMaterial(Material material);
        bool MaterialExists(int id);
    }
}
