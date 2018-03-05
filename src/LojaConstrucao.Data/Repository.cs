using LojaConstrucao.Domain;    
using System.Collections.Generic;
using System.Linq;

namespace LojaConstrucao.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public TEntity GetById(int id)
        {
            //return _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);

            var query = _context.Set<TEntity>().Where(e => e.Id == id);
            if(query.Any())
            {
                return query.First();
            }

            return null;
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> All()
        {
           return _context.Set<TEntity>().AsEnumerable();
        }
    }
}