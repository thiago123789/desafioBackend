using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ToutBox.Challange.Core.DeliveryPrice;
using ToutBox.Challenge.DataContracts.Config;
using ToutBox.Challenge.Services.Contracts.ThirdPart;

namespace ToutBox.Challenge.Correios
{
    public class CorreiosService : ICorreiosService
    {
        private readonly IDefaultValuesConfig defaultValuesConfig;

        public CorreiosService(IDefaultValuesConfig defaultValuesConfig)
        {
            this.defaultValuesConfig = defaultValuesConfig;
        }

        public async Task<IList<ServicePriceTime>> CalcDeliveryPriceTime(string destinationZipCode, IList<DeliveryService> deliveryServices)
        {
            var retorno = new List<ServicePriceTime>();

            var client = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);

            foreach (var service in deliveryServices)
            {
                var result = await client.CalcPrecoPrazoAsync(
                    string.Empty,
                    string.Empty,
                    service.ServiceCode,
                    defaultValuesConfig.DefaulZipCode,
                    destinationZipCode,
                    defaultValuesConfig.DefaultWeight,
                    defaultValuesConfig.DefaultFormat,
                    defaultValuesConfig.DefaultLength,
                    defaultValuesConfig.DefaultHeight,
                    defaultValuesConfig.DefaultWidth,
                    defaultValuesConfig.DefaultWidth,
                    defaultValuesConfig.DefaultOwnHands,
                    defaultValuesConfig.DefaultDeclaredValue,
                    defaultValuesConfig.DefaultReceivingWarning);

                foreach (var resultServices in result.Servicos)
                {

                    var deliveryPrice = Convert.ToDecimal(resultServices.Valor, new CultureInfo("pt-Br"));
                    var okDeliveryTime = int.TryParse(resultServices.PrazoEntrega, out var deliveryTime);
                    
                    if (deliveryPrice != Decimal.MinValue && okDeliveryTime)
                    {
                        retorno.Add(new ServicePriceTime(service, deliveryPrice, deliveryTime));
                    }
                }
            }

            return retorno;
        }
    }
}
