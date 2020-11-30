
namespace ToutBox.Challange.Core.DeliveryPrice
{
    public record ServicePriceTime()
    {
        public DeliveryService DeliveryService { get; init; }
        public decimal Price { get; init; }
        public int Time { get; init; }
        
        public ServicePriceTime(DeliveryService deliveryService, decimal price, int time) : this()
        {
            DeliveryService = deliveryService;
            Price = price;
            Time = time;
        }
    }
}
