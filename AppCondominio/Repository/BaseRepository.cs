using AppCondominio;
using AppCondominio.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCondominio.Repository
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly CondominioContext context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(CondominioContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }
    }
}