using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Interface;
using Eating.Models;
using System.Data.Entity;

namespace Eating.Repository
{
    public class SetTimeRepository<TEntity> : ISetTimeRepository<TEntity>
        where TEntity : class
    {

        private ApplicationDbContext _context { get; set; }


        public SetTimeRepository(ApplicationDbContext Context)
        {
            if (Context == null)
            {
                throw new ArgumentNullException("context");
            }
            this._context = new ApplicationDbContext();
        }
        public void DeleteList(IEnumerable<TEntity> instances)
        {
            _context.Entry<IEnumerable<TEntity>>(instances).State = EntityState.Deleted;
            SaveChanges();
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
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
    }
}