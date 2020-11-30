using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToutBox.Challange.Core.DeliveryPrice;
using ToutBox.Challenge.Services.Contracts.Data;

namespace ToutBox.Challenge.Data
{
    public sealed class Repository : IRepository
    {
        private DbSet<DeliveryServicePriceTime> _dbSet;
        
        public Repository(ToutboxContext context)
        {
            _dbSet = context.Set<DeliveryServicePriceTime>();
        }

        public async Task<IList<string>> FindTenMostFrequentZipCodeQueried()
        {
            return await _dbSet.GroupBy(e => e.DestinationZipCode.Value)
                .OrderBy(e => e.Count())
                .Take(10)
                .Select(e => e.Key)
                .ToListAsync();
        }

        public async Task<IList<string>> FindMostRecent(int size)
        {
            return await _dbSet.AsQueryable()
                .OrderBy(e => e.RequestDateTime)
                .Take(size)
                .Select(e => e.DestinationZipCode.Value)
                .Distinct()
                .ToListAsync();
        }

        public void Append(DeliveryServicePriceTime deliveryServicePriceTime)
        {
            _dbSet.Add(deliveryServicePriceTime);
        }
    }
}
