using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmCategoryService
    {
        public Task<List<CategoryResponseDto>> GetCategorys();
        public bool AddCategory(AddCategoryRequestDto whmCategory);
        public bool UpdateCategory(UpdateCategoryRequest whmCategory);
        public WhmCategory GetCategoryById(Guid categoryId);
        public List<CategoryResponseDto> SearchCategoryByName(string categoryName);
    }
}
