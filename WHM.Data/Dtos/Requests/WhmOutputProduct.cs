using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class WhmOutputProduct
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public float EstimatedPrice { get; set; }
        public int Quanity { get; set; } = 1;
        public int MaxQuanity { get; set; }
    }
}
