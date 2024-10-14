using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class ProductInputRequestDto
    {
        public Guid ProdInputDetailId { get; set; }
        public Guid ProdInputId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float InputPrice { get; set; }
    }
}
