var builder = WebApplication.CreateBuilder(args);

// 1. Agregar el servicio de controladores
builder.Services.AddControllers();

// Configuración de Swagger (Opcional, para probar endpoints)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 2. Mapear las rutas de los controladores
app.MapControllers();

app.Run();