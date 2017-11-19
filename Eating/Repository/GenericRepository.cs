using Eating.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using Eating.Models;

namespace Eating.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private ApplicationDbContext _context { get; set; }
        

        //public GenericRepository(DbContext Context)
        //{
        //    _context = Context ?? throw new ArgumentNullException("context");
        //}

        public GenericRepository(ApplicationDbContext Context)
        {
            if (Context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = new ApplicationDbContext();
        }

        public void Create(TEntity instance)
        {
            _context.Set<TEntity>().Add(instance);
            SaveChanges();
        }

        public void Update(TEntity instance)
        {
            _context.Entry<TEntity>(instance).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(TEntity instance)
        {
            _context.Entry<TEntity>(instance).State = EntityState.Deleted;
            SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllById(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable(); ;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();

            // 因為Update 單一model需要先關掉validation，因此重新打開
            if (_context.Configuration.ValidateOnSaveEnabled == false)
            {
                _context.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        #region IDisposable Support
        // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~GenericRepository() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }

        
        #endregion
    }
}