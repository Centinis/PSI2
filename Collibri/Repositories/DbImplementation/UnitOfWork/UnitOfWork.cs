using Collibri.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace Collibri.Repositories.DbImplementation.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>, new()
    {
        private bool _disposed;
        private IDbContextTransaction _transaction;
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            Context = context;
        }
        
        public void CreateTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException dbException)
            {
                Log.Error(dbException, dbException.Message);
                Rollback();
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                _disposed = true;
            }
        }
    }      
}