namespace WHM.Data.Dtos.Requests
{
    public class AddProductAttributeRequestDto
    {
        public Guid ProductId { get; set; }
        public List<AddProductAttributeDataRequestDto> Attributes { get; set; }
    }

    public class AddProductAttributeDataRequestDto
    {
        public Guid AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public string? AttributeValueDescription { get; set; }
    }
}
