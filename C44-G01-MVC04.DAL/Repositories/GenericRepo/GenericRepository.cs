using C44_G01_MVC04.DAL.Contexts;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericeRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity> GetAll(bool WithTrack = false)
        {
            if (WithTrack)
                return _context.Set<TEntity>().ToList();
            else
                return _context.Set <TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity;
        }
        public int Add(TEntity Item)
        {
            _context.Set<TEntity>().Add(Item);
            return _context.SaveChanges();
        }

        public int Update(TEntity Item)
        {
            _context.Set<TEntity>().Update(Item);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }
    }
}
