using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challenge.Contracts.Common;

namespace ToutBox.Challenge.Contracts.Services
{
    public interface IGetMostFrequentsZipCodesQueryHandler : IQuery
    {
        Task<IList<string>> GetMostFrequentsZipCodes();
    }
}
