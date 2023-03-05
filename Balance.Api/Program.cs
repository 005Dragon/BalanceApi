using Balance.Api;
using WebApiContrib.Core.Formatter.Csv;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

TransientInitializer.Initialize(builder);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddCsvSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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