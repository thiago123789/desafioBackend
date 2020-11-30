using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challange.Core.DeliveryPrice;

namespace ToutBox.Challenge.Services.Contracts.ThirdPart
{
    public interface ICorreiosService
    {
        Task<IList<ServicePriceTime>> CalcDeliveryPriceTime(string zipCode, IList<DeliveryService> deliveryServices);
    }
}
