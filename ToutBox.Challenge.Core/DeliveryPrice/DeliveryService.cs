using System;
using System.Collections.Generic;

namespace ToutBox.Challange.Core.DeliveryPrice
{
    public class DeliveryService
    {
        public static readonly DeliveryService SEDEX = new DeliveryService("SEDEX", "04014");
        public static readonly DeliveryService PAC = new DeliveryService("PAC", "04510");
        public static readonly DeliveryService SEDEX12 = new DeliveryService("SEDEX 12", "04782");
        public static readonly DeliveryService SEDEX10 = new DeliveryService("SEDEX 10", "04790");
        public static readonly DeliveryService SEDEX_HOJE = new DeliveryService("SEDEX HOJE", "04804");
        public static readonly IList<DeliveryService> ALL = new List<DeliveryService>(){ SEDEX, PAC, SEDEX12, SEDEX10, SEDEX_HOJE };

        public string ServiceName { get; }
        public string ServiceCode { get; }

        private DeliveryService()
        {
        }

        public DeliveryService(string serviceName, string serviceCode)
            => (ServiceName, ServiceCode) = (serviceName, serviceCode);
    }
}
