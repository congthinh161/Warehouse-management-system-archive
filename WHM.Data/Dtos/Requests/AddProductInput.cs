namespace WHM.Data.Dtos.Requests
{
    public class AddProductInput
    {
        public Guid SuplierId { get; set; }
        public float PreMoney { get; set; }
        public string Description { get; set; }

        public List<AddProductInputDetailsDto> ProductInputDetails { get; set; }
    }
}
