using System;
using System.Collections.Generic;

namespace ToutBox.Challenge.DataContracts.ApiResponseDtos
{
    public class CorreiosServicePriceTimeDTO
    {
        public string DestinationZipCode { get; set; }

        public IList<ServicePriceTimeDTO> ServicesPriceTime { get; set; }
    }

    public class ServicePriceTimeDTO
    {
        public string ServiceName { get; set; }
        public string ServicePrice { get; set; }
        public int ServiceTimeInDays { get; set; }
        
    }
}
