﻿namespace WHM.Data.Dtos.Responses
{
    public class ProductResponseDto
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float EstimatedPrice { get; set; }
    }
}
