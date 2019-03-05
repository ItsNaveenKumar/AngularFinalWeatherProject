using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models.Repository
{
    public interface UserLocationIDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(long id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
