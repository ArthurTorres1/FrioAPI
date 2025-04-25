using FrioAPI.Api.Filters;
using FrioAPI.Application;
using FrioAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
            "https://frio-front.vercel.app",
            "http://localhost:3000"
        )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// Inje��o de depend�ncias
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection(); // HTTPS ativo apenas no ambiente de desenvolvimento
}
else
{
    // Desabilitar HTTPS para ambientes Docker/produ��o
    app.Urls.Add("http://0.0.0.0:5000"); // Aceita conex�es HTTP
}

app.UseAuthorization();

app.MapControllers();

app.Run();