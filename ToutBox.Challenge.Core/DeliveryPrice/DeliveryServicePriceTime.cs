using System;
using System.Collections.Generic;
using System.Linq;

namespace ToutBox.Challange.Core.DeliveryPrice
{
    public class DeliveryServicePriceTime
    {
        public Guid Id { get; }

        public ZipCode SourceZipCode { get; }
        public ZipCode DestinationZipCode { get; }

        public DateTime RequestDateTime { get; }

        private IList<ServicePriceTime> _servicesPriceTime;
        public IReadOnlyList<ServicePriceTime> ServicesPriceTimes => _servicesPriceTime.ToList();
        
        private DeliveryServicePriceTime()
        {
            Id = Guid.NewGuid();
        }
        
        public DeliveryServicePriceTime(ZipCode sourceZipCode, ZipCode destinationZipCode, IList<ServicePriceTime> servicesPriceTime) : this()
        {
            SourceZipCode = sourceZipCode;
            DestinationZipCode = destinationZipCode;
            SetServicesPriceTime(servicesPriceTime);
        }

        public DeliveryServicePriceTime(string sourceZipCode, string destinationZipCode, IList<ServicePriceTime> servicesPriceTime) : this()
        {
            RequestDateTime = DateTime.UtcNow;
            this.SourceZipCode = new ZipCode(sourceZipCode);
            this.DestinationZipCode = new ZipCode(destinationZipCode);
            SetServicesPriceTime(servicesPriceTime);               
        }

        public void SetServicesPriceTime(IList<ServicePriceTime> servicePriceTimes)
        {
            if (servicePriceTimes != null && servicePriceTimes.Any())
            {
                _servicesPriceTime = servicePriceTimes;
            }
            else
            {
                throw new InvalidOperationException("Invalid list of services");
            }
        }
    }
}
