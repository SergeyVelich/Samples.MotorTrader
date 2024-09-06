using Samples.Infrastructure.Api.ConfigValidation;
using Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;
using static Samples.MT.Common.Api.Constants;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add configurations to the container.
var platformDbConfiguration = services.AddConfigWithValidation<PlatformDbConfiguration>(configuration, ConfigurationSectionNames.PlatformDb);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db contexts
services.AddPlatformDbContext(platformDbConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();