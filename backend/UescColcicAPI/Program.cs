using UescColcicAPI.Core;
using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UescColcicDBContext>();
builder.Services.AddScoped<IStudentsCRUD, StudentsCRUD>();
builder.Services.AddScoped<ISkillsCRUD, SkillsCRUD>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
