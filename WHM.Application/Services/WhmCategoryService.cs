using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Whm.Data.EF;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services
{
    public class WhmCategoryService : IWhmCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmCategoryService> _logger;
        private readonly IMapper _mapper;
        public WhmCategoryService(IUnitOfWork unitOfWork, ILogger<WhmCategoryService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponseDto>> GetCategorys()
        {
            try
            {
                var result = await _unitOfWork.WhmCategoryRepository.GetCategorys().ToListAsync().ConfigureAwait(false);
                return _mapper.Map<List<CategoryResponseDto>>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddCategory(AddCategoryRequestDto addCategory)
        {
            WhmCategory whmCategory = _mapper.Map<WhmCategory>(addCategory);
            try
            {
                _unitOfWork.WhmCategoryRepository.AddCategory(whmCategory);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public WhmCategory GetCategoryById(Guid categoryId)
        {
            try
            {
                return _unitOfWork.WhmCategoryRepository.GetCategoryById(categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<CategoryResponseDto> SearchCategoryByName(string categoryName)
        {
            try
            {
                var result = _unitOfWork.WhmCategoryRepository.SearchCategoryByName(categoryName).ToList();
                return _mapper.Map<List<CategoryResponseDto>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool UpdateCategory(UpdateCategoryRequest whmCategory)
        {
            try
            {
                if (whmCategory.CategoryId != Guid.Empty)
                {
                    var category = _unitOfWork.WhmCategoryRepository.GetCategoryById(whmCategory.CategoryId);
                    category.CategoryName = whmCategory.CategoryName;
                    category.CategoryDescription = whmCategory.CategoryDescription;
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }






            var result = _mapper.Map<WhmCategory>(whmCategory);
            try
            {
                _unitOfWork.WhmCategoryRepository.UpdateCategory(result);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
