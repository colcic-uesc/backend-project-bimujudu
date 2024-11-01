using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Services.Auth;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Configuração da autenticação JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UescColcicDBContext>();
builder.Services.AddScoped<IStudentsCRUD, StudentsCRUD>();
builder.Services.AddScoped<ISkillsCRUD, SkillsCRUD>();
builder.Services.AddScoped<IProfessorCRUD, ProfessorCRUD>();
builder.Services.AddScoped<IProjectCRUD, ProjectCRUD>();
builder.Services.AddScoped<IUsersCRUD, UsersCRUD>();
builder.Services.AddScoped<AuthService>();

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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<EventLoggingMiddleware>();
app.UseMiddleware<ResponseAppendMiddleware>();

app.MapControllers();

app.Run();
