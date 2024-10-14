using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Whm.Application.AutoMapper;
using Whm.Data.EF;
using Whm.Infrastructure.Configurations;
using Whm.Infrastructure.Helpers;
using WHM.Application.Services;
using WHM.Application.Services.Interfaces;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace Whm.DependencyConfig
{
    public static class DependencyInjection
    {
        public static IServiceCollection CommonService(this IServiceCollection services, IConfiguration configuration)
        {
            //HttpContextAcessor
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql(configuration.GetConnectionString("Default"),
                                                            o => o.MigrationsAssembly("WHM.Data.EF")), ServiceLifetime.Scoped);

            //Config CORS
            services.AddCors(cors => cors.AddPolicy("WhmPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = AppSettings.ValidAudience,
                        ValidIssuer = AppSettings.ValidIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:AccessTokenSecret"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OwnerRole",
                    policy => policy.RequireRole(UserRoles.Owner.ToString(), UserRoles.Manager.ToString(), UserRoles.Employee.ToString()));

                options.AddPolicy("ManagerRole",
                    policy => policy.RequireRole(UserRoles.Manager.ToString(), UserRoles.Employee.ToString()));

                options.AddPolicy("EmployeeRole",
                    policy => policy.RequireRole(UserRoles.Employee.ToString()));
            });

            // Add services to the container.
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    //options.JsonSerializerOptions.MaxDepth = 5;
                }).ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        return ApiFormatError.CustomErrorResponse(context);
                    };
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "WHM Api",

                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddHealthChecks();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue; // if don't set default value is: 128 MB
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            return services;
        }

        public static IServiceCollection AutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<DomainToResponseModelMappingProfile>();
                config.AddProfile<RequestModelToDomainMappingProfile>();
                config.AddProfile<ResponseModelToDomainMappingProfile>();
            });

            services.AddScoped<IMapper>(builder => new Mapper(builder.GetRequiredService<AutoMapper.IConfigurationProvider>(), builder.GetService));
            return services;
        }

        public static IServiceCollection ProfilerService(this IServiceCollection services)
        {
            //Config Profiler
            services.AddMemoryCache();
            //URL: profiler/results-index
            services.AddMiniProfiler(config => config.RouteBasePath = "/profiler")
                .AddEntityFramework();

            return services;
        }

        public static IServiceCollection SignalRService(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }

        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IWhmAccountService, WhmAccountService>();
            services.AddScoped<IWhmAttributeService, WhmAttributeService>();
            services.AddScoped<IWhmProductInputService, WhmProductInputService>();
            services.AddScoped<IWhmProductOutputService, WhmProductOutputService>();
            services.AddScoped<IWhmCategoryService, WhmCategoryService>();
            services.AddScoped<IWhmSupplierService, WhmSupplierService>();
            services.AddScoped<IWhmCategoryAttributeService, WhmCategoryAttributeService>();
            services.AddScoped<IWhmProductService, WhmProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection CacheService(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = AppSettings.Redis;
            });

            return services;
        }

        public static IServiceCollection HttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient(AppSettings.OmdbName, client =>
            {
                client.BaseAddress = new Uri(AppSettings.OmdbUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
