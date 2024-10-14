using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHM.Data.Dtos.Requests;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmCategoryAttributeService
    {
        public bool AddCategoryAttribute(AddCategoryAttributeRequestDto requestDto);
    }
}
