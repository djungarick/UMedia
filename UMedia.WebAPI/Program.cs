using Ardalis.ListStartupServices;
using Serilog;
using UMedia.Application.Extensions;
using UMedia.Persistence.Extensions;
using UMedia.WebAPI.Extensions;

Environment.SetEnvironmentVariable("UMEDIA_BASE_DIRECTORY", AppContext.BaseDirectory);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Host.UseSerilog(
    static (hostBuilderContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom
            .Configuration(hostBuilderContext.Configuration);
    });

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

app.UseForwardedHeaders();

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
