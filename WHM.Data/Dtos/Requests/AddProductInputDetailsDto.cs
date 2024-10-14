namespace WHM.Data.Dtos.Requests
{
    public class AddProductInputDetailsDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float InputPrice { get; set; }
    }
}
