using System.Net.Http.Headers;
using WHM.FE.Constants;
using WHM.FE.Middlewares;
using WHM.FE.Services;
using WHM.FE.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var serviceProvider = builder.Services?.BuildServiceProvider();

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AddPageRoute("/Common/Index","");
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
}); 

builder.Services.AddHttpClient(CommonConstant.API_NAME, (serviceProvider, client) =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiConfig:ApiUrl"]);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var httpContextAccessor = serviceProvider?.GetService<IHttpContextAccessor>();

    var bearerToken = httpContextAccessor?.HttpContext?.Session.GetString("JWT");

    if (bearerToken != null)
        client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", bearerToken));
});
builder.Services.AddScoped<IApiCallerGeneric, ApiCallerGeneric>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.ConfigureExceptionHandler();

app.Run();
