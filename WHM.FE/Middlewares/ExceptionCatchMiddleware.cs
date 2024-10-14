using Microsoft.AspNetCore.Diagnostics;

namespace WHM.FE.Middlewares
{
    public static class ExceptionCatchMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();


                    if (contextFeature != null)
                    {

                        if (contextFeature.Error is UnauthorizedAccessException)
                        {
                            context.Response.Redirect("/");
                            return;
                        }

                        context.Response.Redirect("/Error");
                        return;
                    }
                });
            });

        }
    }
}
