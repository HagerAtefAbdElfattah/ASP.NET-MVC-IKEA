using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Repositories.GenericRepository
{
    public interface IGenericeRepository<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool WithTrack = false);
        public TEntity GetById(int id);
        public void Add(TEntity Item);
        public void Update(TEntity Item);
        public void Delete(int id);

        //public IEnumerable<TEntity> GetEnumerable();
        //public IQueryable<TEntity> GetQueryable();
    }
}
