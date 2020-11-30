using System;
namespace ToutBox.Challenge.DataContracts.Config
{
    public interface IDefaultValuesConfig
    {
        string DefaulZipCode { get; }
        int DefaultFormat { get; }
        decimal DefaultHeight { get; }
        decimal DefaultLength { get; }
        string DefaultWeight { get; }
        string DefaultReceivingWarning { get; }
        string DefaultOwnHands { get; }
        decimal DefaultDeclaredValue { get; }
        decimal DefaultWidth { get; }
    }
}
