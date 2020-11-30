using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToutBox.Challange.Core.DeliveryPrice;

namespace ToutBox.Challenge.UnitTests.CoreTests
{
    [TestClass]
    public class ValueObjectsTests
    {
        [TestMethod]
        public void ZipCodeBuild_ValidZipCodeWithHifen_ShouldBeOk()
        {
            var zipCode = new ZipCode("50761-030");

            zipCode.Value.Should().Be("50761030");
        }

        [TestMethod]
        public void ZipCodeBuild_ValidZipCodeWithoutHifen_ShouldBeOk()
        {
            var zipCode = new ZipCode("50761030");

            zipCode.Value.Should().Be("50761030");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ZipCodeBuild_InvalidZipCodeWithNumbers_ShouldThrowException()
        {
            new ZipCode("5076103012321");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ZipCodeBuild_InvalidZipCodeWithLetters_ShouldThrowException()
        {
            new ZipCode("invalidzipcode");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ZipCodeBuild_InvalidZipCodeWithLowerLength_ShouldThrowException()
        {
            new ZipCode("5076103");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ZipCodeBuild_InvalidZipCodeWithEmptyString_ShouldThrowException()
        {
            new ZipCode("");
        }
    }
}
