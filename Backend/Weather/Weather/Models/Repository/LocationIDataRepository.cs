using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models.Repository
{
    public interface LocationIDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
