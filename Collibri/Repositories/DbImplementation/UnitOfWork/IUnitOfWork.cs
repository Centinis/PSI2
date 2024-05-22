using Microsoft.EntityFrameworkCore;

namespace Collibri.Repositories.DbImplementation.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        public TContext Context { get; }

        public void CreateTransaction();
        public void Commit();
        public void Rollback();
        public void Save();
    }
}