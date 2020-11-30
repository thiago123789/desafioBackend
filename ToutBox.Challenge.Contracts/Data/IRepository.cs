using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challange.Core.DeliveryPrice;

namespace ToutBox.Challenge.Services.Contracts.Data
{
    public interface IRepository
    {
        Task<IList<string>> FindTenMostFrequentZipCodeQueried();
        Task<IList<string>> FindMostRecent(int size);
        void Append(DeliveryServicePriceTime deliveryServicePriceTime);
    }
}
