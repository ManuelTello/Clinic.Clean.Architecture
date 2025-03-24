using Net.Clinic.Application;
using Net.Clinic.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}
else { }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();