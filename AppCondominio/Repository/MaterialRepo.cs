using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCondominio.Repository
{
    public class MaterialRepo : BaseRepository<Material>, IMaterialRepo
    {
        public MaterialRepo(CondominioContext context) : base(context)
        {
        }

        public Material CreateMaterial(Material material)
        {
            DbSet.Add(material);
            context.SaveChanges();
            return material;
        }

        public IList<Material> GetMateriais()
        {
            return DbSet.ToList();
        }
    }
}
