using HOTELINKA.DOMAIN.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.REPOSITORY.Repository
{
    public class BaseRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> All<T>() where T : Entity
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<IQueryable<T>> AllAsync<T>() where T : Entity
        {
            return await Task.Factory.StartNew(() => _context.Set<T>().AsQueryable());
        }

        public void Insert<T>(IEnumerable<T> list) where T : Entity
        {
            list.ToList().ForEach(f => Insert(f));
        }

        public void Insert<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.Entry(entity).State = EntityState.Added;
        }

        public async Task InsertAsync<T>(IEnumerable<T> list) where T : Entity
        {
            await Task.Factory.StartNew(() => Insert(list));
        }

        public async Task InsertAsync<T>(T entity) where T : Entity
        {
            await Task.Factory.StartNew(() => Insert(entity));
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update<T>(IEnumerable<T> list) where T : Entity
        {
            list.ToList().ForEach(f => Update(f));
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            await Task.Factory.StartNew(() => Update(entity));
        }

        public async Task UpdateAsync<T>(IEnumerable<T> list) where T : Entity
        {
            await Task.Factory.StartNew(() => Update(list));
        }

        #region DISPOSED

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
