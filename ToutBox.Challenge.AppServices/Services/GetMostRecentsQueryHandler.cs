using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.Services.Contracts.Data;

namespace ToutBox.Challenge.AppServices.Services
{
    public class GetMostRecentsQueryHandler : IGetMostRecentsQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetMostRecentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IList<string>> GetMostRecentsQueries(int size)
        {
            var repository = _unitOfWork.repository;
            return await repository.FindMostRecent(size);
        }
    }
}
