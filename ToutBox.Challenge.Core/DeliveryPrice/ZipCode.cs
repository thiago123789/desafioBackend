using System;
namespace ToutBox.Challange.Core.DeliveryPrice
{
    public record ZipCode
    {
        private static readonly char ZIPCODE_SEPARATOR = '-';
        private static readonly string INVALID_ZIPCODE_MESSAGE = "invalid zip code";
        private static readonly string ZIPCODE_WITH_NOT_ONLY_NUMBERS = "Invalid zip code value, must have only digits";

        private char[] _value;
        public string Value => new string(_value);

        public ZipCode(string value)
        {
            _value = new char[8];
            setZipCodeValue(value);
        }

        public ZipCode(ZipCode value)
        {
            this._value = value.Value.ToCharArray();
        }
        
        private void setZipCodeValue(string valueAsString)
        {
            if (valueAsString.Length < 8 || valueAsString.Length > 9)
            {
                throw new InvalidOperationException(INVALID_ZIPCODE_MESSAGE);
            }

            var zipCodeAsCharArray = valueAsString.ToCharArray();
            int valueArrayIndex = (int) decimal.Zero;

            foreach (var ch in zipCodeAsCharArray)
            {
                if (char.IsDigit(ch) )
                {
                    _value[valueArrayIndex] = ch;
                    valueArrayIndex++;
                }
                else if (ch.Equals(ZIPCODE_SEPARATOR))
                {
                    continue;
                }
                else
                {
                    throw new InvalidOperationException(ZIPCODE_WITH_NOT_ONLY_NUMBERS);
                }
            }
        }
    }
}
