using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string email);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
       
    }
}
