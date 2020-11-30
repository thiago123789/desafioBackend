using System;
using Microsoft.Extensions.Configuration;

namespace ToutBox.Challenge.DataContracts.Config
{
    public class DefaultValuesConfig : IDefaultValuesConfig
    {
        private static string CORREIOS_SECTION_DEFAULT_VARIABLES = "DefaultParametersCorreios";

        private static string CORREIOS_DEFAULT_ZIPCODE = "DefaultZipCode";
        private static string CORREIOS_DEFAULT_FORMAT = "DefaultFormat";
        private static string CORREIOS_DEFAULT_HEIGHT = "DefaultHeight";
        private static string CORREIOS_DEFAULT_LENGTH = "DefaultLength";
        private static string CORREIOS_DEFAULT_WEIGHT = "DefaultWeight";
        private static string CORREIOS_DEFAULT_WIDTH =  "DefaultWidth";
        private static string CORREIOS_DEFAULT_RECEIVINGWARNING = "DefaultReceivingWarning";
        private static string CORREIOS_DEFAULT_OWNHANDS = "DefaultOwnHands";
        private static string CORREIOS_DEFAULT_DECLAREDVALUE = "DefaultDeclaredValue";

        public string DefaulZipCode { get; }
        public int DefaultFormat { get; }
        public decimal DefaultHeight { get; }
        public decimal DefaultLength { get; }
        public string DefaultWeight { get; }
        public string DefaultReceivingWarning { get; }
        public string DefaultOwnHands { get; }
        public decimal DefaultDeclaredValue { get; }
        public decimal DefaultWidth { get; }

        public DefaultValuesConfig(IConfiguration configuration)
        {
            var correiosDefault = configuration.GetSection(CORREIOS_SECTION_DEFAULT_VARIABLES);
            DefaulZipCode = correiosDefault[CORREIOS_DEFAULT_ZIPCODE];
            DefaultFormat = int.Parse(correiosDefault[CORREIOS_DEFAULT_FORMAT]); 
            DefaultHeight = decimal.Parse(correiosDefault[CORREIOS_DEFAULT_HEIGHT]);
            DefaultLength = decimal.Parse(correiosDefault[CORREIOS_DEFAULT_LENGTH]);
            DefaultWeight = correiosDefault[CORREIOS_DEFAULT_WEIGHT];
            DefaultReceivingWarning = correiosDefault[CORREIOS_DEFAULT_RECEIVINGWARNING];
            DefaultOwnHands = correiosDefault[CORREIOS_DEFAULT_OWNHANDS];
            DefaultDeclaredValue = decimal.Parse(correiosDefault[CORREIOS_DEFAULT_DECLAREDVALUE]);
            DefaultWidth = decimal.Parse(correiosDefault[CORREIOS_DEFAULT_WIDTH]);
        }
    }
}
