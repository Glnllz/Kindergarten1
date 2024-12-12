using Microsoft.EntityFrameworkCore;
using Kindergarten1.DataBases;
using Kindergarten1;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы
builder.Services.AddControllers();

// Добавляем контекст базы данных
builder.Services.AddDbContext<DSADEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DSADEntities")));

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();