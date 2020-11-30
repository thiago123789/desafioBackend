using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ToutBox.Challange.Core.DeliveryPrice;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.DataContracts.ApiResponseDtos;
using ToutBox.Challenge.DataContracts.Config;
using ToutBox.Challenge.Services.Contracts.Data;
using ToutBox.Challenge.Services.Contracts.ThirdPart;

namespace ToutBox.Challenge.AppServices.Services
{
    public class CalculateDeliveryPriceCommandHandler : ICalculateDeliveryPriceCommandHandler
    {
        private readonly ICorreiosService _correiosService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDefaultValuesConfig _defaultValuesConfig;
        
        public CalculateDeliveryPriceCommandHandler(
            ICorreiosService correiosService, 
            IUnitOfWork unitOfWork,
            IDefaultValuesConfig defaultValuesConfig)
        {
            _correiosService = correiosService;
            _unitOfWork = unitOfWork;
            _defaultValuesConfig = defaultValuesConfig;
        }

        public async Task<CorreiosServicePriceTimeDTO> CalculateDeliveryPrice(string zipCode)
        {
            var repository = _unitOfWork.repository;

            var servicePriceTime = await _correiosService.CalcDeliveryPriceTime(zipCode, DeliveryService.ALL);

            var deliveryPriceTime =
                new DeliveryServicePriceTime(_defaultValuesConfig.DefaulZipCode, zipCode, servicePriceTime);

            var returnValue = ConvertObjectToDtoReturn(deliveryPriceTime);

            repository.Append(deliveryPriceTime);

            await _unitOfWork.CommitAsync();

            return returnValue;
        }

        private CorreiosServicePriceTimeDTO ConvertObjectToDtoReturn(DeliveryServicePriceTime deliveryPriceTime)
        {
            var returnValue = new CorreiosServicePriceTimeDTO()
            {
                DestinationZipCode = deliveryPriceTime.DestinationZipCode.Value
            };

            var servicePriceTimeDtoReturn = new List<ServicePriceTimeDTO>();
            foreach (var servicePriceToDto in deliveryPriceTime.ServicesPriceTimes)
            {
                if (servicePriceToDto.Price != Decimal.Zero && servicePriceToDto.Time != (int) Decimal.Zero)
                {
                    servicePriceTimeDtoReturn.Add(new ServicePriceTimeDTO()
                    {
                        ServiceName = servicePriceToDto.DeliveryService.ServiceName,
                        ServicePrice = servicePriceToDto.Price.ToString(CultureInfo.InvariantCulture),
                        ServiceTimeInDays = servicePriceToDto.Time
                    });   
                }
            }

            returnValue.ServicesPriceTime = servicePriceTimeDtoReturn;
            return returnValue;
        }
    }
}
