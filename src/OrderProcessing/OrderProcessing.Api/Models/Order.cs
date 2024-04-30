namespace OrderProcessing.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsProcessed { get; set; }
    }
}
