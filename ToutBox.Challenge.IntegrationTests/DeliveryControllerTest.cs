using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using ToutBox.Challenge.API;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToutBox.Challenge.API.Controllers;
using ToutBox.Challenge.Contracts.Services;
using ToutBox.Challenge.Data;
using ToutBox.Challenge.DataContracts.ApiResponseDtos;

namespace ToutBox.Challenge.IntegrationTests
{
    [TestClass]
    public class DeliveryControllerTest
    {
        private readonly DeliveryController _deliveryController;
        private readonly Mock<IGetMostRecentsQueryHandler> _getMostRecentHandlerMock;
        private readonly Mock<IGetMostFrequentsZipCodesQueryHandler> _getMostFrequentsZipCodesQueryHandlerMock;
        private readonly Mock<ICalculateDeliveryPriceCommandHandler> _calculateDeliveryPriceCommandHandlerMock;
        
        public DeliveryControllerTest()
        {
            _getMostRecentHandlerMock = new Mock<IGetMostRecentsQueryHandler>();
            _getMostFrequentsZipCodesQueryHandlerMock = new Mock<IGetMostFrequentsZipCodesQueryHandler>();
            _calculateDeliveryPriceCommandHandlerMock = new Mock<ICalculateDeliveryPriceCommandHandler>();
            
            _deliveryController = new DeliveryController( 
                _getMostFrequentsZipCodesQueryHandlerMock.Object, 
                _getMostRecentHandlerMock.Object,
                _calculateDeliveryPriceCommandHandlerMock.Object);
        }

        [TestMethod]
        public async Task GetLastQueries()
        {
            _getMostRecentHandlerMock
                .Setup(e => 
                    e.GetMostRecentsQueries(It.IsAny<int>()))
                .ReturnsAsync(new List<string>(){ "50761030", "50070070" });
            
            var response = await _deliveryController.GetMostRecents();

            response.Result.Should().BeOfType(typeof(OkObjectResult));

            var reponseObjectResult = ((OkObjectResult) response.Result);
            reponseObjectResult.Value.Should().BeOfType(typeof(List<string>));
            ((List<string>) reponseObjectResult.Value).Count.Should().Be(2);
        }

        [TestMethod]
        public async Task GetMostFrquentZipCodes()
        {
            _getMostFrequentsZipCodesQueryHandlerMock
                .Setup(e => 
                    e.GetMostFrequentsZipCodes())
                .ReturnsAsync(new List<string>(){ "50761030", "50070070" });
            
            var response = await _deliveryController.GetMostFrequentsZipCodes();

            response.Result.Should().BeOfType(typeof(OkObjectResult));

            var reponseObjectResult = ((OkObjectResult) response.Result);
            reponseObjectResult.Value.Should().BeOfType(typeof(List<string>));
            ((List<string>) reponseObjectResult.Value).Count.Should().Be(2);
        }

        [TestMethod]
        public async Task CalcDeliveryPrice()
        {
            _calculateDeliveryPriceCommandHandlerMock
                .Setup(e => 
                    e.CalculateDeliveryPrice(It.IsAny<string>()))
                .ReturnsAsync(new CorreiosServicePriceTimeDTO());
            
            var response = await _deliveryController.CalculateDeliveryPrice("50761030");

            response.Result.Should().BeOfType(typeof(OkObjectResult));

            var reponseObjectResult = ((OkObjectResult) response.Result);
            reponseObjectResult.Value.Should().BeOfType(typeof(CorreiosServicePriceTimeDTO));
        }
    }
}
