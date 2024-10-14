using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class AddSupplierRequestDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        public string? MoreInfo { get; set; }
    }
}
