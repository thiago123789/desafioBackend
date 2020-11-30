using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToutBox.Challenge.Contracts.Common;
using ToutBox.Challenge.DataContracts.ApiResponseDtos;

namespace ToutBox.Challenge.Contracts.Services
{
    public interface ICalculateDeliveryPriceCommandHandler : ICommand
    {
        Task<CorreiosServicePriceTimeDTO> CalculateDeliveryPrice(string zipCode);
    }
}
