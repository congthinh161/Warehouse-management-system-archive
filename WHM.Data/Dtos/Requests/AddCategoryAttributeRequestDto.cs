using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class AddCategoryAttributeRequestDto
    {
        //public Guid CategoryAttributeId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AttributeId { get; set; }
    }
}
