using System;
using System.Data;
using System.Threading.Tasks;

namespace ToutBox.Challenge.Services.Contracts.Data
{
    public interface IUnitOfWork
    {
        IRepository repository { get; }

        void ForceBeginTransaction();

        /// <summary>
        /// Commits the current transaction (does nothing when none exists).
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back the current transaction (does nothing when none exists).
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves changes to database, previously opening a transaction
        /// only when none exists. The transaction is opened with isolation
        /// level set in Unit of Work before calling this method.
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Sets the isolation level for new transactions.
        /// </summary>
        /// <param name="isolationLevel"></param>
        void SetIsolationLevel(IsolationLevel isolationLevel);
    }
}
