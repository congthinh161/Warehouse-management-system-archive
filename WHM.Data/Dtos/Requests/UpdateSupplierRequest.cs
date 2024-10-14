﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHM.Data.Dtos.Requests
{
    public class UpdateSupplierRequest
    {
        public Guid SuplierId { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? MoreInfo { get; set; }
    }
}
