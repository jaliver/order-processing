namespace OrderProcessing.Api.Models
{
    public class Receipt
    {
        public Order? Order { get; set; }
        public DateTime ProcessedDateTime { get; set; }
    }
}
