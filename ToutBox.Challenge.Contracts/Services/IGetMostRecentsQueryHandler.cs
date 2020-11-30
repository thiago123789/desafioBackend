using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challenge.Contracts.Common;

namespace ToutBox.Challenge.Contracts.Services
{
    public interface IGetMostRecentsQueryHandler : IQuery
    {
        Task<IList<string>> GetMostRecentsQueries(int size);
    }
}
