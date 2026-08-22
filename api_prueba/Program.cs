var builder = WebApplication.CreateBuilder(args);

// Agregar Controllers
builder.Services.AddControllers();

// Agregar OpenAPI nativo de .NET
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();