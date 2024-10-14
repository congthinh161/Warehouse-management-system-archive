namespace WHM.Data.Dtos.Requests
{
    public class ProductRequestDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float EstimatedPrice { get; set; }
    }
}
