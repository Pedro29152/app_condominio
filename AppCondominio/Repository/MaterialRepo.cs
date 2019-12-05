using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return DbSet
                .Include(m => m.Fornecedor)
                .Include(m => m.Locador)
                .ToList();
        }

        public Material GetMaterial(int? id)
        {
            return DbSet
                .Include(m => m.Fornecedor)
                .Include(m => m.Locador)
                .FirstOrDefault(m => m.Id == id);
        }

        public bool MaterialExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }

        public void RemoveMaterial(Material material)
        {
            DbSet.Remove(material);
            context.SaveChanges();
        }

        public void UpdateMaterial(Material material)
        {
            DbSet.Update(material);
            context.SaveChanges();
        }
    }
}
