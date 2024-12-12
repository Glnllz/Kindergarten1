using Microsoft.EntityFrameworkCore;
using Kindergarten1.DataBases;
using Kindergarten1;

var builder = WebApplication.CreateBuilder(args);

// ��������� �������
builder.Services.AddControllers();

// ��������� �������� ���� ������
builder.Services.AddDbContext<DSADEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DSADEntities")));

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ��������� HTTP-��������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();