using UMedia.WebAPI.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ApplyUMediaOptionConfigurations();

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
