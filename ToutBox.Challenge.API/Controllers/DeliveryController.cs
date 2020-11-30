using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.DataContracts.ApiResponseDtos;

namespace ToutBox.Challenge.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IGetMostFrequentsZipCodesQueryHandler _getMostFrequentsZipCodesQueryHandler;
        private readonly IGetMostRecentsQueryHandler _getMostRecentsQueryHandler;
        private readonly ICalculateDeliveryPriceCommandHandler _calculateDeliveryPriceCommandHandler;

        public DeliveryController(
            IGetMostFrequentsZipCodesQueryHandler getMostFrequentsZipCodesQueryHandler,
            IGetMostRecentsQueryHandler getMostRecentsQueryHandler,
            ICalculateDeliveryPriceCommandHandler calculateDeliveryPriceCommandHandler
            )

        {
            _calculateDeliveryPriceCommandHandler = calculateDeliveryPriceCommandHandler;
            _getMostFrequentsZipCodesQueryHandler = getMostFrequentsZipCodesQueryHandler;
            _getMostRecentsQueryHandler = getMostRecentsQueryHandler;
        }

        [HttpGet("LastQueries")]
        public async Task<ActionResult<IList<string>>> GetMostRecents([FromQuery]int size = 10)
        {
            var result = await _getMostRecentsQueryHandler.GetMostRecentsQueries(size);
            return Ok(result);
        }

        [HttpGet("MostFrequentZipCodes")]
        public async Task<ActionResult<IList<string>>> GetMostFrequentsZipCodes()
        {
            var result = await _getMostFrequentsZipCodesQueryHandler.GetMostFrequentsZipCodes();
            return Ok(result);
        }

        [HttpPost("CalcDeliveryPrice")]
        public async Task<ActionResult<CorreiosServicePriceTimeDTO>> CalculateDeliveryPrice([FromQuery]string zipCode)
        {
            var result = await _calculateDeliveryPriceCommandHandler.CalculateDeliveryPrice(zipCode);
            return Ok(result);
        }
    }
}