namespace OrderProcessing.Api.Models
{
    public class Receipt
    {
        public IReadOnlyCollection<Order> Orders { get; set; } = new List<Order>();
        public DateTime ProcessedDateTime { get; set; }
    }
}
