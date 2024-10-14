using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Responses
{
    public class CategoryResponseDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
    }
}
