using AutoMapper;

namespace Whm.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestModelToDomainMappingProfile());
                cfg.AddProfile(new DomainToResponseModelMappingProfile());
                cfg.AddProfile(new ResponseModelToDomainMappingProfile());
            });
        }
    }
}
