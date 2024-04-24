using Microsoft.EntityFrameworkCore;
using WebApi8_Guilherme.Data;
using WebApi8_Guilherme.Services.Autor;
using WebApi8_Guilherme.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionada a refer�ncia da interface com o servi�o
builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddScoped<ILivroInterface, LivroService>();

//Conex�o a string de conex�o do appsettings
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
