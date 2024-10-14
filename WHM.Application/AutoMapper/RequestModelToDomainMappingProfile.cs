using AutoMapper;
using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;

namespace Whm.Application.AutoMapper
{
    public class RequestModelToDomainMappingProfile : Profile
    {
        public RequestModelToDomainMappingProfile()
        {
            CreateMap<UserLoginRequestDto, WhmAccount>();
            CreateMap<UserRegisterRequestDto, WhmAccount>();
            CreateMap<AttributeRequestDto, WhmAttribute>();
            CreateMap<AddCategoryRequestDto, WhmCategory>();
            CreateMap<AddSupplierRequestDto, WhmSuplier>();
            CreateMap<UpdateCategoryRequest, WhmCategory>();
            CreateMap<AddCategoryAttributeRequestDto, WhmCategoryAttribute>();
            CreateMap<ProductRequestDto, WhmProduct>();
            CreateMap<AddProductInput, WhmProductInput>()
                .ForMember(dest => dest.SuplierId, opt => opt.MapFrom(src => src.SuplierId));
            CreateMap<AddProductInputDetailsDto, WhmProductInputDetail>();
            CreateMap<AddProductAttributeDataRequestDto, WhmAttributeValue>();
        }
    }
}
