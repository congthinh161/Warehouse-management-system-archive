using AutoMapper;
using Whm.Data.Entities;
using Whm.Infrastructure.Enums;
using WHM.Data.Dtos.Responses;

namespace Whm.Application.AutoMapper
{
    public class DomainToResponseModelMappingProfile : Profile
    {
        public DomainToResponseModelMappingProfile()
        {
            CreateMap<WhmAttribute, AttributeResponseDto>();
            CreateMap<WhmCategory, CategoryResponseDto>();
            CreateMap<WhmAccount, UserInfoResponseDto>()
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.CreateDate.ToShortDateString()))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => Enum.Parse(typeof(SystemEnum.UserRoles), src.RoleId.ToString())));
            CreateMap<WhmSuplier, SupplierResponseDto>();
            CreateMap<WhmProduct, ProductResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryIdNavigation.CategoryName));
            CreateMap<WhmProduct, ProductAttributeResponseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryIdNavigation.CategoryName))
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.CategoryIdNavigation.WhmCategoryAttributes.Select(x => x.WhmAttribute)));
            CreateMap<WhmAttribute, AttributeInfoResponseDto>();
                
        }
    }
}
