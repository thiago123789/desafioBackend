using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToutBox.Challenge.UnitTests
{
    [TestClass]
    public class CorreiosTest
    {
        public CorreiosTest()
        {
        }

        [TestMethod]
        public void CorreiosService_ConsultarPrecoPrazoEntrega_ShouldBeOk()
        {
            var client = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);

            var calculoPrecoPrazo = client.CalcPrecoPrazoAsync("", "", "04014", "50070070", "50761030", "1", 3, 30, 0, 30, 30, "N", 0, "N");
            var resultado = calculoPrecoPrazo.Result;

            Assert.IsNotNull(resultado);
        }
    }
}
