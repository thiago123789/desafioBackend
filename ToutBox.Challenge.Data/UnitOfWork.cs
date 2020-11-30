using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ToutBox.Challenge.Services.Contracts.Data;

namespace ToutBox.Challenge.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ToutboxContext _dbContext;
        
        private IDbContextTransaction _transaction;
        private System.Data.IsolationLevel? _isolationLevel;

        private IRepository _repository;
        
        public IRepository repository => _repository ??= new Repository(_dbContext);
        
        public UnitOfWork(ToutboxContext genericDbContext)
        {
            _dbContext = genericDbContext;
            StartNewTransactionIfNeeded();
        }

        private void StartNewTransactionIfNeeded()
        {
            if (_transaction == null)
            {
                if (_isolationLevel.HasValue)
                {
                    _transaction = _dbContext.Database.BeginTransaction(_isolationLevel.GetValueOrDefault());
                }
                else
                {
                    _transaction = _dbContext.Database.BeginTransaction();
                }
            }
        }

        public void ForceBeginTransaction()
        {
            StartNewTransactionIfNeeded();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            
            if (_transaction != null)
            {
                await Task.Run(() => CommitDisposeAction());
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            
            if (_transaction != null)
            {
                CommitDisposeAction();
            }
        }

        private void CommitDisposeAction()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            if (_transaction == null) return;

            _transaction.Rollback();

            _transaction.Dispose();
            _transaction = null;
        }

        public async Task<int> SaveChangesAsync()
        {
            StartNewTransactionIfNeeded();

            return await _dbContext.SaveChangesAsync();
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }
        
        public void Dispose()
        {
            _transaction?.Dispose();

            _transaction = null;
        }
    }
}
