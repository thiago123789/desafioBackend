using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.Services.Contracts.Data;

namespace ToutBox.Challenge.AppServices.Services
{
    public class GetMostFrequentsZipCodesQueryHandler : IGetMostFrequentsZipCodesQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetMostFrequentsZipCodesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<string>> GetMostFrequentsZipCodes()
        {
            var respository = _unitOfWork.repository;
            return await respository.FindTenMostFrequentZipCodeQueried();
        }
    }
}
