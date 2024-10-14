using Whm.Middlewares;

namespace Whm.Api.Middlewares
{
    public static class ReformatExtension
    {
        public static IApplicationBuilder UseReformatExtension(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ReformatResponseMiddleware>();
        }
    }
}
