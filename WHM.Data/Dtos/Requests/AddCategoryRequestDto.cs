using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class AddCategoryRequestDto
    {
        public string CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
    }
}
