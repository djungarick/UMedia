using Ardalis.ListStartupServices;
using UMedia.Application.Extensions;
using UMedia.Persistence.Extensions;
using UMedia.WebAPI.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddUMediaApplicationLayer();
builder.Services.AddUMediaPersistenceLayer(builder.Configuration);

builder.Services.ApplyUMediaOptionConfigurations();

builder.Services.Configure<ServiceConfig>(options
    =>
    {
        options.Services = new List<ServiceDescriptor>(builder.Services);
        options.Path = $"/{RouteConstants.RoutePrefix}/listservices";
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
    app.UseShowAllServicesMiddleware();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
